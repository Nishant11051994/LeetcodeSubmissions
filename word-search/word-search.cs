public class Solution {
    public bool Exist(char[][] board, string word) 
    {
        if(board == null || board.Length == 0) return false;
        
        for(int i = 0 ; i < board.Length ; i++)
        {
            for(int j = 0 ; j < board[i].Length ; j++)
            {
                if(board[i][j] == word[0])
                {
                    if(Recurse(board,"",word,i,j,0))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private bool IsSafe(char[][] board,int i, int j)
    {
        if(i >= 0 && i < board.Length && j >=0 && j < board[i].Length)
        {
            return true;
        }
        return false;
    }
    private bool Recurse(char[][] board,string curr, string target, int i,int j, int targetIndex)
    {
        if(curr == target)
        {
            return true;
        }
        if(IsSafe(board,i,j) && target[targetIndex] == board[i][j])
        {
            char c = board[i][j];
            board[i][j] = '-';
            if(Recurse(board,curr+c,target,i+1,j,targetIndex+1)||
            Recurse(board,curr+c,target,i-1,j,targetIndex+1)||
            Recurse(board,curr+c,target,i,j+1,targetIndex+1)||
            Recurse(board,curr+c,target,i,j-1,targetIndex+1))
            {
                return true;
            }
            board[i][j] = c;
        }   
        return false;
    }
}