public class Solution {
    public IList<IList<int>> Subsets(int[] nums) 
    {
        if(nums == null || nums.Length == 0) return null;
        
        IList<IList<int>> result = new List<IList<int>>();
        
        BackTrack(nums,new List<int>(),result,0);
        
        return result;
    }
    private void BackTrack(int[] nums,List<int> curr,IList<IList<int>> result,int index)
    {
        result.Add(new List<int>(curr));
        for(int i = index ; i < nums.Length ; i++)
        {
            curr.Add(nums[i]);
            BackTrack(nums,curr,result,i+1);
            curr.RemoveAt(curr.Count-1);
        }
    }
}