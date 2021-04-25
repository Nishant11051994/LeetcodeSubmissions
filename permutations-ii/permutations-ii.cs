public class Solution {
    public IList<IList<int>> PermuteUnique(int[] nums) 
    {
        Array.Sort(nums);
        IList<IList<int>> result = new List<IList<int>>();
        Recurse(nums,result,new List<int>(),new bool[nums.Length]);
        return result;
    }
    private void Recurse(int[] nums,IList<IList<int>> result,List<int> curr,bool[] used)
    {
       if(curr.Count == nums.Length)
        {
            result.Add(new List<int>(curr));
        }
        else
        {
            for(int i = 0 ; i < nums.Length ; i++)
            {
                if(used[i] || i > 0 && nums[i] == nums[i-1] && !used[i-1]) continue;
                used[i] = true;
                curr.Add(nums[i]);
                Recurse(nums,result,curr,used);
                used[i] = false;
                curr.RemoveAt(curr.Count-1);
            }
        }
    }
}