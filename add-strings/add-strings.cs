public class Solution {
    public string AddStrings(string num1, string num2) 
    {
       StringBuilder sb = new StringBuilder();
       int carry = 0;
       int len1 = num1.Length-1;
       int len2 = num2.Length-1;
       int i = len1,j = len2;
       while(i >= 0 || j >= 0)
       {
           int a = i >= 0 ? num1[i] - '0': 0;
           int b = j >= 0 ? num2[j] - '0': 0;
           int sum = a + b + carry;
           carry = sum / 10;
           int val = sum % 10;
           sb.Append(val);
           i--;
           j--;           
       }
       if(carry!=0)
       {
           sb.Append(carry.ToString());
       }
       string result = sb.ToString();
       char[] arr = result.ToArray();
       Array.Reverse(arr);
       return new string(arr);       
    }
}