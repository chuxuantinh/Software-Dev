using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace WordCruncher
{
    public class WordCruncher
    {
        private List<Node> permutation = new List<Node>();

        public WordCruncher(string[] input, string target)
        {
            permutation = GeneratePermutations(input.OrderBy(s => s), target);
        }

        private List<Node> GeneratePermutations(IEnumerable<string> input, string target)
        {
            if (string.IsNullOrEmpty(target) || input.Count() == 0)
            {
                return null;
            }

            List<Node> returnValues = null;
            foreach (var key in input)
            {
                if (target.StartsWith(key))
                {
                    if (returnValues == null)
                    {
                        returnValues = new List<Node>();
                    }

                    var node = new Node()
                    {
                        Key = key,
                        Value = GeneratePermutations(input.Except(new string[] { key }), target.Substring(key.Length))
                    };

                    if (node.Value == null && node.Key != target)
                    {
                        continue;
                    }

                    returnValues.Add(node);
                }
            }

            return returnValues;
        }

        public IEnumerable<IEnumerable<string>> GetPaths()
        {
            List<string> way = new List<string>();
            foreach (var key in VisitPath(permutation, new List<string>()))
            {
                if (key == null)
                {
                    yield return way;
                    way.Clear();
                }
                else
                {
                    way.Add(key);
                }
            }
        }

        private IEnumerable<string> VisitPath(List<Node> permutation, List<string> path)
        {
            if (permutation  == null)
            {
                foreach (var pathItem in path)
                {
                    yield return pathItem;
                }

                yield return null;
            }
            else
            {
                foreach (Node node in permutation)
                {
                    path.Add(node.Key);
                    foreach (var item in VisitPath(node.Value, path))
                    {
                        yield return item;
                    }
                    path.RemoveAt(path.Count - 1);
                }
            }
        }
    }
}
