namespace _02.FitGym
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FitGym : IGym
    {
        private Dictionary<int, Member> members;
        private Dictionary<int, Trainer> trainers;

        public FitGym()
        {
            this.members = new Dictionary<int, Member>();
            this.trainers = new Dictionary<int, Trainer>();
        }

        public void AddMember(Member member)
        {
            if (this.members.ContainsKey(member.Id))
            {
                throw new ArgumentException();
            }

            this.members[member.Id] = member;
        }

        public void HireTrainer(Trainer trainer)
        {
            if (this.trainers.ContainsKey(trainer.Id))
            {
                throw new ArgumentException();
            }

            this.trainers[trainer.Id] = trainer;
        }

        public void Add(Trainer trainer, Member member)
        {
            if (!this.Contains(member))
            {
                this.AddMember(member);
            }

            if (!this.Contains(trainer) || member.Trainer != null)
            {
                throw new ArgumentException();
            }

            member.Trainer = trainer;
            trainer.Members.Add(member);
        }

        public bool Contains(Member member)
        {
            return this.members.ContainsKey(member.Id);
        }

        public bool Contains(Trainer trainer)
        {
            return this.trainers.ContainsKey(trainer.Id);
        }

        public Trainer FireTrainer(int id)
        {
            if (!this.trainers.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            foreach (Member member in this.trainers[id].Members)
            {
                member.Trainer = null;
            }

            Trainer temp = this.trainers[id];
            this.trainers.Remove(id);

            return temp;
        }

        public Member RemoveMember(int id)
        {
            if (!this.members.ContainsKey(id))
            {
                throw new ArgumentException();
            }

            Member member = this.members[id];

            Trainer trainer = member.Trainer;
            if (trainer != null)
            {
                trainer.Members.Remove(member);
            }

            Member temp = member;
            this.members.Remove(id);

            return temp;
        }

        public int MemberCount => this.members.Count;

        public int TrainerCount => this.trainers.Count;

        public IEnumerable<Member>
            GetMembersInOrderOfRegistrationAscendingThenByNamesDescending()
        {
            IEnumerable<Member> query = this.members.Values
                .OrderBy(m => m.RegistrationDate)
                .ThenBy(m => m.Name)
                .ToArray();

            return query;
        }

        public IEnumerable<Trainer> GetTrainersInOrdersOfPopularity()
        {
            IEnumerable<Trainer> query = this.trainers.Values
                .OrderBy(t => t.Popularity)
                .ToArray();

            return query;
        }

        public IEnumerable<Member>
            GetTrainerMembersSortedByRegistrationDateThenByNames(Trainer trainer)
        {
            IEnumerable<Member> query = trainer.Members
                .OrderBy(m => m.RegistrationDate)
                .ThenBy(m => m.Name)
                .ToArray();

            return query;
        }

        public IEnumerable<Member>
            GetMembersByTrainerPopularityInRangeSortedByVisitsThenByNames(int lo, int hi)
        {
            IEnumerable<Member> query = this.members.Values
                .Where(m => m.Trainer.Popularity >= lo && m.Trainer.Popularity <= hi)
                .OrderBy(m => m.Visits)
                .ThenBy(m => m.Name)
                .ToArray();

            return query;
        }

        public Dictionary<Trainer, HashSet<Member>>
            GetTrainersAndMemberOrderedByMembersCountThenByPopularity()
        {
            Dictionary<Trainer, HashSet<Member>> dictionary = new Dictionary<Trainer, HashSet<Member>>();

            IEnumerable<Trainer> query = this.trainers.Values
                .OrderBy(t => t.Members.Count)
                .ThenBy(t => t.Popularity)
                .ToArray();

            foreach (Trainer trainer in query)
            {
                dictionary[trainer] = trainer.Members;
            }

            return dictionary;
        }
    }
}