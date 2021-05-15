public class Solution {
    public string Multiply(string num1, string num2) 
    {
        int l1 = num1.Length-1;
        int l2 = num2.Length-1;
        
        int[] result = new int[l1 + l2 +2];
        int kStart = result.Length-1;
        int carry = 0;
        int i = l1;
        int j = l2;
        
        while( j >= 0)
        {
            int k = kStart;
            while( i >= 0)
            {
                int op1 = num1[i] - '0';
                int op2 = num2[j] - '0';
                int prod = op1 * op2 + carry;
                int sum = result[k] + prod;
                result[k] = sum % 10;
                carry = sum / 10;
                i--;
                k--;
            }
            if(carry > 0)
            {
                result[k] += carry;
                carry = 0;
            }
            kStart--;
            j--;
            i = l1;
        }
        
        StringBuilder sb = new StringBuilder();
        foreach(int num in result)
        {
            if(num != 0 || sb.Length > 0)
            {
                sb.Append(num);
            }
        }
        return sb.Length == 0 ? "0" : sb.ToString();
        
    }
}