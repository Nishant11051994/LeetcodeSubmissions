public class Solution {
    public void Solve(char[][] board) 
    {
        if(board == null || board.Length == 0) return;
        
        for(int i = 0 ; i < board.Length ; i++)
        {
            for(int j = 0; j < board[0].Length ; j++)
            {
               if((i == 0 || i == board.Length-1) || (j == 0 || j == board[0].Length-1))
               {
                   Console.WriteLine($"Border {i},{j}");
                   if(board[i][j] == 'O')
                   {
                       Flip(i,j,board);
                   }                  
               }
            }
        }
        for(int i = 0 ; i < board.Length ; i++)
        {
            for(int j = 0; j < board[0].Length ; j++)
            {
               if(board[i][j] != 'K')
                {
                   board[i][j] = 'X';
                }
            }
        }
        for(int i = 0 ; i < board.Length ; i++)
        {
            for(int j = 0; j < board[0].Length ; j++)
            {
                if(board[i][j] == 'K')
                {
                   board[i][j] = 'O';
                }
            }
        }
    }
    private bool IsSafe(int x,int y,char[][] board)
    {
        if(x >= 0 && y >= 0 && x < board.Length && y < board[x].Length && board[x][y] == 'O')
        {
            return true;
        }
        return false;
    }
    private void Flip(int x,int y,char[][] board)
    {
        if(IsSafe(x,y,board))
        {
            Console.WriteLine($"Making {x},{y} as K");
            board[x][y] = 'K';
            Flip(x+1,y,board);
            Flip(x,y+1,board);
            Flip(x-1,y,board);
            Flip(x,y-1,board);           
        }
    }
}