public class Trie
{
    int count = 26;
    public Trie[] children;
    public Trie()
    {
        children = new Trie[count];
    }
    public void Insert(string word)
    {
        Trie temp = this;
        for(int i = 0 ; i < word.Length ; i++)
        {
            int index = word[i] - 'a';
            if(temp.children[index] == null)
            {
                temp.children[index] = new Trie();
            }
            temp = temp.children[index];
        }
    }
    public bool StartsWith(string word)
    {
        Trie temp = this;
        for(int i = 0 ; i < word.Length ; i++)
        {
            int index = word[i] - 'a';
            if(temp.children[index] == null)
            {
                return false;
            }
            temp = temp.children[index];
        }
        return true;
    }
}
public class Solution {
    HashSet<string> list = new HashSet<string>();
    HashSet<string> set;
    bool[,] visited;
    public IList<string> FindWords(char[][] board, string[] words) 
    {       
        if(board == null || board.Length == 0 || words == null || words.Length == 0) return null;
        
        // Constructing Trie
        Trie root = new Trie();
        
        set = new HashSet<string>(words);
        foreach(string s in words)
        {
            root.Insert(s);
        }        
        for(int i = 0 ; i < board.Length ; i++)
        {
            for(int j = 0 ; j < board[i].Length ; j++)
            {
               visited = new bool[board.Length,board[0].Length];
               IsFound(board,i,j,root,"");
            }
        }                 
        return list.ToList();      
    }
    private bool IsSafe(char[][] board,int row,int col)
    {
        if(row < board.Length && row >=0 && col < board[0].Length && col >=0 && !visited[row,col])
        {  
            return true;
        }
        return false;
    }
    private void IsFound(char[][] board,int row,int col,Trie root,string prefix)
    {               
           if(!IsSafe(board,row,col)) return;
        
           char currChar = board[row][col];
           prefix += board[row][col];
        
           if(!root.StartsWith(prefix)) return;
        
           if(set.Contains(prefix)) list.Add(prefix);    
        
            visited[row,col] = true;    
        
            IsFound(board,row+1,col,root,prefix);
            IsFound(board,row,col+1,root,prefix);
            IsFound(board,row-1,col,root,prefix);
            IsFound(board,row,col-1,root,prefix);
                   
            visited[row,col] = false;
    }
}