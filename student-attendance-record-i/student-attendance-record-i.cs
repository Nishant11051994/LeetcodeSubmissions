public class Solution {
    public bool CheckRecord(string s) 
    {
        if(string.IsNullOrEmpty(s)) return false;
        
        int lateDays = 0;
        int absentDays = 0;
        int i = 0;
        
        while(i < s.Length)
        {
            if(s[i] == 'A')
            {
                absentDays++;
            }
            else if(s[i] == 'L')
            {
                if(i > 0 && s[i-1] != 'L')
                {
                   lateDays = 1; 
                }
                else
                {
                    lateDays += 1;
                }
            }
            if(lateDays >= 3)
            {
                return false;
            }
            i++;
        }
        
        return absentDays < 2;
    }
}