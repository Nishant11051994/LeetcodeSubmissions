// Greedy apporach to solve this problem
public class Solution {
    private Dictionary<int,string> map = new Dictionary<int,string>()
    {
        {1000,"M"},
        {900,"CM"},
        {500,"D"},
        {400,"CD"},
        {100,"C"},
        {90,"XC"},
        {50,"L"},
        {40,"XL"},
        {10,"X"},
        {9,"IX"},
        {5,"V"},
        {4,"IV"},
        {1,"I"}
    };
    public string IntToRoman(int num) 
    {
       StringBuilder sb = new StringBuilder();     
       while(num > 0)
       {
           foreach(var item in map)
           {
               while(item.Key <= num)
               {
                   num -= item.Key;
                   sb.Append(item.Value);
               }
           }
       }
       return sb.ToString();           
    }
}