public class Trie
{
    int alphabetCount = 27;
    Trie[] links;
    bool isEndOfString;
    int time;
    static Trie root;
    public Trie()
    {
        links = new Trie[alphabetCount];
        isEndOfString = false;
    }
    public void Insert(string word,int time)
    {
        root = this;
        Trie temp = root;
        for(int i = 0 ; i < word.Length ; i++)
        {
             int index = word[i] - 'a';
            if(word[i] ==' ')
            {
                index = 26;
            }
           
            if(temp.links[index] == null)
            {
                temp.links[index] = new Trie();
            }
        }
        temp.isEndOfString = true;
        temp.time = time;
    }
    public bool Search(string word)
    {
        root = this;
        Trie temp = root;
        for(int i = 0 ; i < word.Length ; i++)
        {
            int index = word[i] - 'a';
            if(temp.links[index] == null)
            {
                return false;
            }
            temp = temp.links[index];
        }
        return temp.isEndOfString;
    }
    public bool StartsWith(string word)
    {
        root = this;
        Trie temp = root;
        for(int i = 0 ; i < word.Length ; i++)
        {
            int index = word[i] - 'a';
            if(temp.links[index] == null)
            {
                return false;
            }
            temp = temp.links[index];
        }
        return true;
    }
    public IList<string> GetAllSuffixes(char s)
    {
        root = this;
        Trie temp = root;
        int index = s - 'a';
        if(s == '{')
        {
            index = 26;
        }
        if(temp.links[index] == null) return null;
        
        IList<string> result = new List<string>();
            
        RecurseOverAllLinks(""+s,result,temp.links[index],s);
        
        return result;
    }
    private void RecurseOverAllLinks(string curr,IList<string> result,Trie temp, char c)
    {
        
         int index = c - 'a';
        
        if(temp.links[index] == null) return;
                
         curr = curr + 'c';
        
        if(temp.isEndOfString)
        {
            result.Add(curr);
        }                
        Trie[] childs = temp.links[index].links;
        
        for(int i = 0 ; i < childs.Length ; i++)
        {
            RecurseOverAllLinks(curr,result,childs[i], (char)(i + 'a'));      
        }        
    }
}
public class Node
{
    public string sentence;
    public int times;
    
    public Node(string s,int t)
    {
        sentence = s;
        times = t;
    }
}
public class AutocompleteSystem {

    Dictionary<string,int>[] map;
    private string currSentence = "";
    public AutocompleteSystem(string[] sentences, int[] times) 
    {
       map = new Dictionary<string,int>[26];
       for(int i = 0 ; i < 26 ; i++)
       {
           map[i] = new Dictionary<string,int>();
       }
       for(int i = 0 ; i < sentences.Length ; i++)
       {
           map[sentences[i][0] - 'a'].Add(sentences[i],times[i]);
       }
    }
    
    public IList<string> Input(char c) 
    {
        IList<string> result = new List<string>();
        
        if(c == '#')
        {
           if(!map[currSentence[0] - 'a'].ContainsKey(currSentence))
           {
               map[currSentence[0] - 'a'].Add(currSentence,0);               
           }
            map[currSentence[0] - 'a'][currSentence]++;         
           currSentence = "";
        }
        else
        {
            List<Node> list = new List<Node>();
            currSentence += c;
            foreach(var key in map[currSentence[0] - 'a'].Keys)
            {
                if(key.StartsWith(currSentence))
                {
                    list.Add(new Node(key,map[currSentence[0] - 'a'][key]));
                }
            }
            
            list.Sort((a,b) => a.times == b.times ? a.sentence.CompareTo(b.sentence) : b.times - a.times);
            
            for(int i = 0 ; i < Math.Min(3,list.Count) ; i++)
            {
                result.Add(list[i].sentence);
            }
            
        }   
        return result;
    }
}

/**
 * Your AutocompleteSystem object will be instantiated and called as such:
 * AutocompleteSystem obj = new AutocompleteSystem(sentences, times);
 * IList<string> param_1 = obj.Input(c);
 */