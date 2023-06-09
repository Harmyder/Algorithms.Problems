using System.Diagnostics;

namespace LeetCode.Tasks
{
    public class MinReverseOperations
    {
        private const int kBanned = -1;

        public int[] Solve(int n, int p, int[] banned, int k)
        {
            var res = new int[n];

            if (k == 1)
            {
                for (var i = 0; i < n; i++)
                {
                    res[i] = kBanned;
                }

                res[p] = 0;

                return res;
            }

            foreach (var b in banned)
            {
                res[b] = kBanned;
            }

            var bounds = new Bounds(p, p);

            var isOddStep = k % 2 == 0;
            var indent = isOddStep ? 1 : 2;
            var maxHop = k - 1;
            var epoch = 1;

            while(0 < bounds.Left || bounds.Right < n - 1)
            {
                var newBounds = new Bounds(Math.Max(0, bounds.Left - maxHop), Math.Min(n - 1, bounds.Right + maxHop));
                var actualNewBounds = Fill(bounds, newBounds, res, indent, epoch);

                if (isOddStep)
                {
                    epoch++;
                    Fill(bounds, newBounds, res, 2, epoch);
                }
                else
                {
                    Fill(bounds, newBounds, res, 1, kBanned);
                    epoch++;
                }

                if (bounds.Left == actualNewBounds.Left && bounds.Right == actualNewBounds.Right)
                {
                    for (var i = 0; i < n; i++)
                    {
                        if (res[i] == 0)
                        {
                            res[i] = kBanned;
                        }
                    }

                    res[p] = 0;

                    break;
                }

                bounds = actualNewBounds;
            }

            //var maxLeft = 

            return res;
        }

        private Bounds Fill(Bounds bounds, Bounds newBounds, int[] res, int indent, int epoch)
        {
            var left = bounds.Left;
            for (var i = bounds.Left - indent; i >= newBounds.Left; i -= 2)
            {
                if (res[i] != kBanned)
                {
                    res[i] = epoch;
                    left = i;
                }
            }
            
            var right = bounds.Right;
            for (var i = bounds.Right + indent; i <= newBounds.Right; i += 2)
            {
                if (res[i] != kBanned)
                {
                    res[i] = epoch;
                    right = i;
                }
            }

            return new Bounds(left, right);
        }

        [DebuggerDisplay("({Left}, {Right})")]
        private class Bounds
        {
            public Bounds(int left, int right)
            {
                Left = left;
                Right = right;
            }
            public int Left;
            public int Right;
        }

        //return Internal(n + 1, p + 1, new[] { 0 }.Concat(banned.Select(x => x + 1)).ToArray(), k).Skip(1).ToArray();

        public int[] Internal(int n, int p, int[] banned, int k)
        {
            Array.Sort(banned);
            var oddPositions = Enumerable.Range(0, n / 2).Select(x => x * 2 + 1).ToArray();
            var evenPositions = Enumerable.Range(0, (n + 1) / 2).Select(x => x * 2).ToArray();

            var oddBanned = Merge(oddPositions, banned);
            var evenBanned = Merge(evenPositions, banned);

            var evenTree = new Tree(n, oddBanned);
            var oddTree = new Tree(n, evenBanned);
            var trees = new[] { evenTree, oddTree };

            var bounds = new (int Left, int Right)[] { (n, -1), (n, -1) };

            var evenCover = new SortedSet<int>();
            var oddCover = new SortedSet<int>();
            (p % 2 == 0 ? evenCover : oddCover).Add(p);
            var covers = new[] { evenCover, oddCover };

            bounds[(p + k + 1) % 2] = (Math.Min(p - (k - 1), 0), Math.Max(p + (k - 1), n - 1));

            var epoch = 1;

            while (bounds.Any(x => x.Left < x.Right))
            {
                for (var evenoddness = 0; evenoddness < 2; evenoddness++)
                {
                    var bound = bounds[evenoddness];
                    var tree = trees[evenoddness];
                    var cover = covers[evenoddness];

                    var current = bound.Left;
                    while (current < bound.Right)
                    {
                        current = tree.FindNext(current - 1);

                    }
                }
            }

            return null;
        }

        private List<int> Merge(int[] first, int[] second)
        {
            var res = new List<int>(Math.Max(first.Length, second.Length));
            var i = 0;
            var j = 0;
            while (i < first.Length && j < second.Length)
            {
                if (first[i] == second[j])
                {
                    i++;
                    j++;
                    res.Add(first[i]);
                }
                else if (first[i] < second[j])
                {
                    i++;
                    res.Add(first[i]);
                }
                else
                {
                    j++;
                    res.Add(second[j]);
                }
            }
            for (; i < first.Length; i++)
            {
                res.Add(first[i]);
            }
            for (; j < second.Length; j++)
            {
                res.Add(second[j]);
            }
            return res;
        }

        private class Tree
        {
            private readonly int _depth;
            private readonly Node _root;

            public Tree(int n, IReadOnlyList<int> banned)
            {
                _depth = ComputeDepth(n);

                _root = new Node();

                var currBannedIndex = 0;
                for (int i = 0; i < n; i++)
                {
                    if (banned[currBannedIndex] != i)
                    {
                        Add(i);
                    }
                }
            }

            public int FindNext(int i)
            {
                var path = BuildPath(i);

                var currentIndex = path.Count - 1;
                while (currentIndex != 0 && (path[currentIndex - 1].Left != path[currentIndex] || path[currentIndex - 1].Right == null))
                {
                    currentIndex--;
                }

                path.RemoveRange(currentIndex, path.Count - currentIndex);
                path.Add(path[currentIndex].Right);
                while (path.Last().HasChildren)
                {
                    if (path.Last().Left != null) path[path.Count - 1] = path.Last().Left;
                    else path[path.Count - 1] = path.Last().Right;
                }

                return PathToNumber(path);
            }

            public void Remove(int i)
            {
                var path = BuildPath(i);

                if (path.Count < _depth)
                {
                    throw new ArgumentException();
                }

                // We can't ascent to the root here as we have starting leaf accessible in 0 steps.
                do
                {
                    var current = path[path.Count - 1];
                    var parent = path[path.Count - 2];
                    parent.RemoveChild(current);
                    path.RemoveAt(path.Count - 1);
                }
                while (!path.Last().HasChildren);
            }

            private int PathToNumber(List<Node> path)
            {
                var number = 0;
                for (var i = 0; i < path.Count - 1; ++i)
                {
                    if (path[i].Right == path[i + 1])
                    {
                        number += 1 << (_depth - 1 - i);
                    }
                }
                return number;
            }

            private List<Node> BuildPath(int i)
            {
                var path = new List<Node>(_depth);
                path[0] = _root;
                var subTreeLeavesCount = 1 << _depth;
                for (var level = 1; level < _depth; level++)
                {
                    if (subTreeLeavesCount < i)
                    {
                        if (path.Last().Right == null) break;
                        i -= subTreeLeavesCount;
                        path.Add(path.Last().Right);
                    }
                    else
                    {
                        if (path.Last().Left == null) break;
                        path.Add(path.Last().Left);
                    }
                    subTreeLeavesCount /= 2;
                }
                return path;
            }

            private void Add(int i)
            {
                var subTreeLeavesCount = 1 << _depth;
                var currNode = _root;
                for (var level = 1; level < _depth; level++)
                {
                    if (subTreeLeavesCount < i)
                    {
                        i -= subTreeLeavesCount;
                        if (currNode.Right == null) currNode.Right = new Node();
                        currNode = currNode.Right;
                    }
                    else
                    {
                        if (currNode.Left == null) currNode.Left = new Node();
                        currNode = currNode.Left;
                    }
                    subTreeLeavesCount /= 2;
                }
            }

            private int ComputeDepth(int n)
            {
                var res = 1;
                while ((n >>= 1) != 0) res++;
                return res;
            }

            private class Node
            {
                public Node Left { get; set; }
                public Node Right { get; set; }
                public bool HasChildren => Left != null || Right != null;
                public void RemoveChild(Node node)
                {
                    if (Left == node) Left = null;
                    else if (Right == node) Left = null;
                    else throw new InvalidOperationException();
                }
            }
        }
    }
}
