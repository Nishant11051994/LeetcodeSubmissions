public class Solution {
    public IList<IList<int>> Permute(int[] nums) 
    {
        IList<IList<int>> result = new List<IList<int>>();
        Recurse(nums,result,new List<int>());
        return result;
    }
    private void Recurse(int[] nums,IList<IList<int>> result,List<int> curr)
    {
        if(curr.Count == nums.Length)
        {
            result.Add(new List<int>(curr));
        }
        for(int i = 0 ; i < nums.Length ; i++)
        {
            if(curr.Contains(nums[i])) continue;
            curr.Add(nums[i]);
            Recurse(nums,result,curr);
            curr.RemoveAt(curr.Count-1);
        }
    }
}