public class Solution {
    private Dictionary<string,int> map = new Dictionary<string,int>()
    {
        {"M",1000},
        {"CM",900},
        {"D",500},
        {"CD",400},
        {"C",100},
        {"XC",90},
        {"L",50},
        {"XL",40},
        {"X",10},
        {"IX",9},
        {"V",5},
        {"IV",4},
        {"I",1}
    };
    public int RomanToInt(string s) 
    {
        int result = 0;
        for(int i = 0 ; i < s.Length ; i++)
        {
            if(i < s.Length-1 && map.ContainsKey(s.Substring(i,2)))
            {
                result += map[s.Substring(i,2)];
                i++;
                continue;
            }
            result += map[s[i].ToString()];
        }
        return result;
    }
}