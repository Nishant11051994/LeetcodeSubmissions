public class Solution {
    public int NumPairsDivisibleBy60(int[] time) 
    {
        if(time == null || time.Length == 0) return 0;
        
        int count = 0;
        
        int[] remainders = new int[60];
        
        for(int i = 0 ; i < time.Length ; i++)
        {
            if(time[i] % 60 == 0)
            {
                count += remainders[0];
            }
            else
            {
                count += remainders[60 - time[i] % 60];
            }
            
            remainders[time[i] % 60]++;
        }
        
        return count;
    }
}
