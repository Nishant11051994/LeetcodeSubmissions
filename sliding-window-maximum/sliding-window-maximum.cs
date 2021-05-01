public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) 
    {
        if(nums == null || nums.Length == 0) return new List<int>().ToArray();
        
        LinkedList<int> list = new LinkedList<int>();
        
        int maxId = -1;
        
        for(int i = 0 ; i < k ; i++)
        {
            if(maxId < 0 || nums[i] > nums[maxId])
            {
                maxId = i;
            }
            
            FixWindow(list,nums,i,k);
            list.AddLast(i);
        }
        
        if(maxId < 0)
        {
            return new int[0];
        }
        
        int[] res = new int[nums.Length - k + 1];
        res[0] = nums[maxId];
        
        for(int i = k ; i < nums.Length ; i++)
        {
            FixWindow(list,nums,i,k);
            list.AddLast(i);
            res[i-k+1] = nums[list.First.Value];
        }
        
        return res;
        
        
        
        
    }
    private void FixWindow(LinkedList<int> window, int[] nums, int i, int k)
    {
        if(window.Count > 0 && window.First.Value <= i-k)
        {
            window.RemoveFirst();
        }
        
        while(window.Count > 0 && nums[i] >= nums[window.Last.Value])
        {
            window.RemoveLast();
        }
    }
}