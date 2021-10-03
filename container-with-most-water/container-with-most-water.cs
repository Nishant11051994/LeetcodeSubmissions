public class Solution {
    public int MaxArea(int[] height) 
    {
        if(height == null || height.Length == 0) return 0;
        
        int start = 0;
        int end = height.Length-1;
        int maxArea = 0;
        
        while(start <= end)
        {
            int currArea = Math.Min(height[end],height[start])*(end-start);
            
            maxArea = Math.Max(currArea,maxArea);
            
            if(height[start] < height[end])
            {
                start++;
            }
            else
            {
                end--;
            }                       
        }
        
        return maxArea;
    }
}