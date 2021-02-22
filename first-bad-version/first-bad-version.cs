/* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

public class Solution : VersionControl {
    public int FirstBadVersion(int n) 
    {
        int left = 0;
        int right = n;
        int versionNumber = -1;
        while(left <= right)
        {
            int mid = left + (right - left)/2;
            if(IsBadVersion(mid))
            {
                versionNumber = mid;
                right = mid - 1;
            }
            else
            {
                left = mid + 1;
            }
        }
        
        return versionNumber == 0 ? -1 : versionNumber;
        
    }
}