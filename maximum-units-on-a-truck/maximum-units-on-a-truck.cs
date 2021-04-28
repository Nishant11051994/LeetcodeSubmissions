public class Solution {
    public int MaximumUnits(int[][] boxTypes, int truckSize) 
    {
        boxTypes = boxTypes.OrderByDescending(x => x[1]).ToArray();
        
        int remainingTruckSize = truckSize;
        
        int maxUnits = 0;
        
        for(int i = 0 ; i < boxTypes.Length ; i++)
        {
            if(remainingTruckSize >= boxTypes[i][0])
            {
                maxUnits +=  boxTypes[i][0] * boxTypes[i][1];
                remainingTruckSize -= boxTypes[i][0];
            }
            else
            {
                maxUnits +=  remainingTruckSize * boxTypes[i][1];
                remainingTruckSize = 0;
            }            
            if(remainingTruckSize == 0)
            {
                break;
            }
        }
        return maxUnits;
    }
}