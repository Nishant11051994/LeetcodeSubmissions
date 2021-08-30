public class Solution {

    int[] nums;
    Random random = new Random();
    public Solution(int[] nums) {
        this.nums = nums;
    }
    
    /** Resets the array to its original configuration and return it. */
    public int[] Reset() {
        return this.nums;
    }
    
    /** Returns a random shuffling of the array. */
    public int[] Shuffle() 
    {
        int n = nums.Length;
        
        int[] copied = new int[n];
        
        nums.CopyTo(copied,0);
        
        for(int i = 0 ; i < n ; i++)
        {
            int rand = random.Next(i+1);
            
            int temp = copied[rand];
            copied[rand] = copied[i];
            copied[i] = temp;
        }
        
        return copied;
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(nums);
 * int[] param_1 = obj.Reset();
 * int[] param_2 = obj.Shuffle();
 */