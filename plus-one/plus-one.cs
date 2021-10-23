public class Solution {
    public int[] PlusOne(int[] digits) 
    {
        for(int i = digits.Length-1 ; i >= 0 ; i--)
        {
            if(digits[i] == 9)
            {
                digits[i] = 0;
            }
            else
            {
                digits[i]++;    
                return digits;
            }
        }
        
        digits = new int[digits.Length+1];
        digits[0] = 1;
        
        return digits;
    }
}