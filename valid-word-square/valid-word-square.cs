public class Solution {
    public bool ValidWordSquare(IList<string> words) 
    {
        if(words == null || words.Count == 0) return false;
                                
        int length = words.Count;
        
        for(int i = 0 ; i < words.Count ; i++)
        {
            string s = "";
            for(int j = 0 ; j < words.Count && i < words[j].Length ; j++)
            {    
                Console.WriteLine($"{words[j][i]},i is {i}, j is {j}, words[i].Length");
                s += words[j][i];
            } 
            Console.WriteLine($"--");
            if(!s.Equals(words[i]))
            {
                return false;
            }
        }
        return true;
    }
}