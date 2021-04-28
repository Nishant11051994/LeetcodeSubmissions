public class Solution {
    public char SlowestKey(int[] releaseTimes, string keysPressed) 
    {
       
        List<char> longPresses = new List<char>();
        
        int n = releaseTimes.Length;
        
        Dictionary<char,int> dict = new Dictionary<char,int>();
        
        for(int i = 0  ; i < n ; i++)
        {
            if(i == 0)
            {
                dict.Add(keysPressed[i],releaseTimes[0]);
            }
            else
            {
                if(dict.ContainsKey(keysPressed[i]))
                {
                     if(releaseTimes[i] - releaseTimes[i-1] >  dict[keysPressed[i]])
                     dict[keysPressed[i]] = releaseTimes[i] - releaseTimes[i-1];
                }
                else
                {
                     dict.Add(keysPressed[i], releaseTimes[i] - releaseTimes[i-1]);
                }
            }
        }              
        dict = dict.OrderByDescending(x => x.Value).ThenByDescending(x => x.Key).ToDictionary(x => x.Key,x => x.Value);
        
        return dict.First().Key;
        
    }
}