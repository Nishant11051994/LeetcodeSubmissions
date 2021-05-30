public class Solution {
    public string ConvertToTitle(int columnNumber) 
    {
        StringBuilder sb = new StringBuilder();
        
        int n = columnNumber;
        
        while(n > 0)
        {
            n--;
            sb.Append((char)(n % 26 + 'A'));
            n = n / 26;
        }
        
        return new string(sb.ToString().Reverse().ToArray());
    }
}