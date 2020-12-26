namespace _02.FitGym
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FitGym : IGym
    {
        List<Member> members = new List<Member>();
        List<Trainer> trainers = new List<Trainer>();
        Dictionary<Trainer, HashSet<Member>> byTrainer = new Dictionary<Trainer, HashSet<Member>>();

        public void AddMember(Member member)
        {
            if (members.Contains(member))
            {
                throw new ArgumentException();
            }
            members.Add(member);
        }

        public void HireTrainer(Trainer trainer)
        {
            if (trainers.Contains(trainer))
            {
                throw new ArgumentException();
            }
            trainers.Add(trainer);
        }

        public void Add(Trainer trainer, Member member)
        {
            if (!trainers.Contains(trainer))
            {
                throw new ArgumentException();
            }

            if (member.Trainer != null)
            {
                throw new ArgumentException();
            }

            if (!byTrainer.ContainsKey(trainer))
            {
                byTrainer[trainer] = new HashSet<Member>();
            }

            //if (byTrainer[trainer].Contains(member))
            //{
            //    throw new ArgumentException();
            //}

            if (!members.Contains(member))
            {
                this.AddMember(member);
                byTrainer[trainer].Add(member);
                member.Trainer = trainer;//?
                trainer.Members.Add(member);
            }
            else
            {
                byTrainer[trainer].Add(member);
                member.Trainer = trainer;//?
                trainer.Members.Add(member);
            }
        }

        public bool Contains(Member member)
        {
            return members.Contains(member);
        }

        public bool Contains(Trainer trainer)
        {
            return trainers.Contains(trainer);
        }

        public Trainer FireTrainer(int id)
        {
            if (!trainers.Any(t => t.Id == id))
            {
                throw new ArgumentException();
            }

            var trainerToRemove = trainers.FirstOrDefault(t => t.Id == id);

            trainers.Remove(trainerToRemove);
            

            if (byTrainer.ContainsKey(trainerToRemove))
            {
                foreach (var member in byTrainer[trainerToRemove])
                {
                    member.Trainer = null;
                }

                byTrainer.Remove(trainerToRemove);
            }

            return trainerToRemove;
        }

        public Member RemoveMember(int id)
        {
            if (!members.Any(m => m.Id == id))
            {
                throw new ArgumentException();
            }

            var memberToRemove = members.FirstOrDefault(m => m.Id == id);
            var trainer = memberToRemove.Trainer;
            members.Remove(memberToRemove);

            if (trainer != null)
            {
                byTrainer[trainer].Remove(memberToRemove);

                if (byTrainer[trainer].Count == 0)
                {
                    byTrainer.Remove(trainer);
                }
            }

            //foreach (var trainer in trainers)
            //{
            //    if (!byTrainer.ContainsKey(trainer))
            //    {
            //        continue;
            //    }

            //    if (byTrainer[trainer].Contains(memberToRemove))
            //    {
            //        byTrainer[trainer].Remove(memberToRemove);

            //        if (byTrainer[trainer].Count == 0)
            //        {
            //            byTrainer.Remove(trainer);
            //        }
            //    }
            //}

            return memberToRemove;
        }

        public int MemberCount { get => members.Count; }
        public int TrainerCount { get => trainers.Count; }

        public IEnumerable<Member> 
            GetMembersInOrderOfRegistrationAscendingThenByNamesDescending()
        {
            return members.OrderBy(m => m.RegistrationDate).ThenByDescending(m => m.Name).ToList();
        }

        public IEnumerable<Trainer> GetTrainersInOrdersOfPopularity()
        {
            return trainers.OrderBy(t => t.Popularity).ToList();
        }

        public IEnumerable<Member> 
            GetTrainerMembersSortedByRegistrationDateThenByNames(Trainer trainer)
        {
            return byTrainer[trainer].OrderBy(m => m.RegistrationDate).ThenBy(m => m.Name).ToList();
        }

        public IEnumerable<Member> 
            GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(int lo, int hi)
        {
            //var trainersByPopularity = trainers.Where(t => lo <= t.Popularity && t.Popularity <= hi).ToList();
            //var result = new List<Member>();
            //foreach (var trainer in trainersByPopularity)
            //{
            //    result.AddRange(byTrainer[trainer]);
            //}
            //result.OrderBy(m => m.Visits).ThenBy(m => m.Name).ToList();
            //return result;

            return byTrainer.Where(t => lo <= t.Key.Popularity && t.Key.Popularity <= hi).SelectMany(t => t.Value).OrderBy(m => m.Visits).ThenBy(m => m.Name).ToList();
        }

        public Dictionary<Trainer, HashSet<Member>> 
            GetTrainersAndMemberOrderedByMembersCountThenByPopularity()
        {
            return byTrainer.OrderBy(k => k.Value.Count()).ThenBy(t => t.Key.Popularity).ToDictionary(k => k.Key, v => v.Value);
        }
    }
}