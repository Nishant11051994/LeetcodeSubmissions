public class Solution {
    public string StrWithout3a3b(int a, int b) 
    {
        
        StringBuilder sb = new StringBuilder();
        
        while(a > 0 || b > 0)
        {
            bool writeA = false;
            int L = sb.Length;
            if(L >=2 && sb[L-2] == sb[L-1])
            {
               if(sb[L-1] == 'b')
               {
                   writeA = true;
               }              
            }
            else
            {
               if(a >= b)
               writeA = true;
            }
            
            if(writeA)
            {
                a--;
                sb.Append('a');
            }
            else
            {
                b--;
                sb.Append('b');
            }          
        }
        
        return sb.ToString();       
    }
    
}