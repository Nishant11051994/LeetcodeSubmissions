public class Trie {
    int alphabet_count = 26;
    Trie[] links;
    bool isEndOfString;
    static Trie root;
    /** Initialize your data structure here. */
    public Trie() 
    {
        links = new Trie[26];
        isEndOfString = false;
    }
    
    /** Inserts a word into the trie. */
    public void Insert(string word) 
    {
      root = this;
      Trie temp = root;
      int length = word.Length;
      for(int i = 0 ; i < length ;i++)
      {
          int index = word[i] - 'a';
          if(temp.links[index]==null)
          {
             temp.links[index] = new Trie();
          }      
          temp = temp.links[index];
      }
        temp.isEndOfString = true;
    }
    
    /** Returns if the word is in the trie. */
    public bool Search(string word) 
    {
        root = this;
        Trie temp = root;
        int length = word.Length;
        for(int i = 0 ; i < length ;i++)
        {
          int index = word[i] - 'a';
          if(temp.links[index]==null)
          {
             return false;
          }      
          temp = temp.links[index];
        }
        return temp.isEndOfString;
    }
    
    /** Returns if there is any word in the trie that starts with the given prefix. */
    public bool StartsWith(string prefix) 
    {
       root = this;
       Trie temp = root;
       int length = prefix.Length;
        for(int i = 0 ; i < length ;i++)
        {
          int index = prefix[i] - 'a';
          if(temp.links[index]==null)
          {
             return false;
          }      
          temp = temp.links[index];
        }
        return true;
    }
}
public class Solution {
    public IList<IList<string>> SuggestedProducts(string[] products, string searchWord) 
    {
        IList<IList<string>> result = new List<IList<string>>();
        
        Array.Sort(products);
        
        StringBuilder sb = new StringBuilder();
        
        for(int i = 0 ; i < searchWord.Length ; i++)
        {
            sb.Append(searchWord[i]);
            List<string> curr = new List<string>();
            for(int j = 0 ; j < products.Length ; j++)
            {
                if(products[j].StartsWith(sb.ToString()) && curr.Count < 3)
                {
                    curr.Add(products[j]);
                }
            }
            result.Add(curr);
        }
        
        return result;
    }
}