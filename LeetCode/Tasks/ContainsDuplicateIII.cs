namespace LeetCode.Tasks
{
    internal class ContainsDuplicateIII
    {
        public bool ContainsNearbyAlmostDuplicate(int[] nums, int indexDiff, int valueDiff)
        {
            var tree = new SortedSet<int>();
            tree.Add(nums[0]);

            var counts = new Dictionary<int, int>();
            counts[nums[0]] = 1;

            for (var i = 1; i < nums.Length; i++)
            {
                var cur = nums[i];

                var good = tree.GetViewBetween(cur - valueDiff, cur + valueDiff);
                if (good.Any())
                {
                    return true;
                }
                if (i >= indexDiff)
                {
                    var expired = nums[i - indexDiff];

                    --counts[expired];
                    if (counts[expired] == 0)
                    {
                        tree.Remove(expired);
                        counts.Remove(expired);
                    }
                }
                if (counts.ContainsKey(cur))
                {
                    ++counts[cur];
                }
                else
                {
                    counts[cur] = 1;
                    tree.Add(cur);
                }
            }
            return false;
        }
    }
}
