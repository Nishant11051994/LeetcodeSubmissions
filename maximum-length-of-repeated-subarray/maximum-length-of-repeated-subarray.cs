public class Solution {
    public int FindLength(int[] nums1, int[] nums2) 
    {
        if(nums1.Length == 0 && nums2.Length == 0) return 0;
        
        int maxLength = 0;
        
        for(int i = 0 ; i < nums1.Length; i++)
        {
            for(int j = 0 ; j < nums2.Length ; j++)
            {
                int currLength = 0;
                if(nums1[i] == nums2[j])
                {
                    int p = i;
                    int q = j;
                    while(p < nums1.Length && q < nums2.Length && nums1[p] == nums2[q])
                    {
                        currLength++;
                        p++;
                        q++;
                    }
                }
                maxLength = Math.Max(currLength,maxLength);
            }
        }
        return maxLength;
    }
}