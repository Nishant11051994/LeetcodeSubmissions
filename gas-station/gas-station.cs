public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost) 
    {
        if(gas == null || gas.Length == 0 || cost == null || cost.Length == 0) return 0;
        
        int currentGas = 0;
        
        for(int i = 0 ; i < gas.Length ; i++)
        {
            currentGas = gas[i];
            int j = i;
            bool traveled = false;
            while(currentGas >= cost[j])
            {
               // Console.WriteLine($"currentGas is {currentGas}, cost[{j}] is {cost[j]} and j is {j}");       
            if(j == i && traveled)
            {
                return i;
            }
                currentGas -= cost[j];                
                j = (j+1)%gas.Length;
                currentGas += gas[j];
                traveled = true;
            }
            
        }        
        return -1;
    }
}