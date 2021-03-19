public class Solution {
    public IList<string> RemoveComments(string[] source) 
    {
        IList<string> result = new List<string>();
        if(source == null) 
        {
            return result;
        }        
        bool multilineComment = false;
        StringBuilder sb = new StringBuilder();
        foreach(string s in source)
        {
            if(!multilineComment)
            {
              sb = new StringBuilder(); 
            }          
            bool inlineComment = false;
            int i = 0;
            while(i < s.Length)
            {
                if(i < s.Length-1)
                {
                    //Console.WriteLine($"s[i] is {s[i]}, multiline is {multilineComment}, inline is {inlineComment} and sb is {sb.ToString()}");
                    if(!inlineComment && s[i] == '/' && s[i+1] == '*' && !multilineComment)
                    {
                        multilineComment = true;
                        i = i + 2;
                        continue;
                    }
                    else if(s[i] == '/' && s[i+1] == '/')
                    {
                        if(!multilineComment)
                        {
                           inlineComment = true;
                           i = i + 2;
                           continue;
                        }
                    }
                    else if(!inlineComment && s[i] == '*' && s[i+1] == '/' && multilineComment)
                    {
                        multilineComment = false;
                        i = i + 2;
                        continue;
                    }
                }               
                if(!multilineComment && !inlineComment)
                {
                    sb.Append(s[i]);
                }
                i++;
            }
            string newStr = sb.ToString();
            if(newStr != string.Empty && !multilineComment)
            result.Add(newStr);
        }
        
        return result;
    }
}