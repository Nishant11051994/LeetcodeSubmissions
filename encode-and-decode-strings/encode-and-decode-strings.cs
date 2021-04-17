public class Codec {

    // Encodes a list of strings to a single string.
    public string encode(IList<string> strs) 
    {
        StringBuilder sb = new StringBuilder();
        
        foreach(string s in strs)
        {
            if(s.Contains(","))
            {
               for(int i = 0 ; i < s.Length ; i++)
               {
                   if(s[i] == ',')
                   {
                       sb.Append("comma");
                   }
                   else
                   {
                       sb.Append(s[i]);
                   }
               }
            }
            else
            {
               sb.Append(s);              
            }
            sb.Append(",");
        }
        
        sb.Remove(sb.Length-1,1);
        string result = sb.ToString();
        Console.WriteLine($"result is {result}");
        return result;
    }

    // Decodes a single string to a list of strings.
    public IList<string> decode(string s) 
    {
        string[] arr = s.Split(",");
        IList<string> result = new List<string>();
        for(int i = 0 ; i < arr.Length ; i++)
        {
            if(arr[i].Contains("comma"))
            {
                result.Add(DecodeCommaString(arr[i]));
            }
            else
            {
                result.Add(arr[i]);
            }
        }
        return result;
    }
    private string DecodeCommaString(string s)
    {
        HashSet<int> set = new HashSet<int>();
        for(int i = 0 ; ; i += "comma".Length)
        {
            i = s.IndexOf("comma",i);
            if(i == -1)
            {
                break;
            }
            set.Add(i);
        }
        
        StringBuilder sb = new StringBuilder();
        int j = 0 ;
        while(j < s.Length)
        {
            if(set.Contains(j))
            {
                sb.Append(",");
                j = j + 5;
            }
            else
            {
                sb.Append(s[j++]);
            }
        }        
        return sb.ToString();
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(strs));