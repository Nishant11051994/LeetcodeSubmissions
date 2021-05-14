public class Solution {
    public IList<string> FindWords(char[][] board, string[] words) 
    {
        List<string> list = new List<string>();
        
       for(int k = 0 ; k < words.Length ; k++)
        {
          for(int i = 0 ;  i < board.Length; i++)
           {
            for(int j = 0 ; j < board[0].Length; j++)
            {
                if(board[i][j] == words[k][0] &&  IsFound(board,i,j,words[k],0))
                {  
                    if(!list.Contains(words[k]))
                    list.Add(words[k]);
                }               
            }            
          }    
        }        
        return list;
    }
    private bool IsSafe(char[][] board,int row,int col,string word,int index)
    {
        if(row < board.Length && row >=0 && col < board[0].Length && col >=0 && index < word.Length && board[row][col] == word[index])
        {  
            return true;
        }
        return false;
    }
    private bool IsFound(char[][] board,int row,int col,string word,int index)
    {
           if(index == word.Length) return true;
        
           if(!IsSafe(board,row,col,word,index)) return false;
            int indexOrignal = index;     
        
            board[row][col] = ' ';    
        
            bool ret = IsFound(board,row+1,col,word,index+1)||
            IsFound(board,row,col+1,word,index+1)||
            IsFound(board,row-1,col,word,index+1)||
            IsFound(board,row,col-1,word,index+1);

        
            board[row][col] = word[indexOrignal];
        
        return ret;
    }
}