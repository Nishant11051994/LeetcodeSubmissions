public class Coordinates
{
    public int row {get; set;}
    public int col {get; set;}
    public Coordinates(int row,int col)
    {
        this.row = row;
        this.col = col;
    }
}
public class Solution {
    int N = 0;
    public int SnakesAndLadders(int[][] board) 
    {
        if(board == null || board.Length == 0) return 0;        
        N = board.Length;             
        Dictionary<int,int> distance = new Dictionary<int,int>();
        Queue<int> queue = new Queue<int>();
        distance.Add(1,0);
        queue.Enqueue(1);
        while(queue.Count != 0)
        {
            int current = queue.Dequeue();
            if(current == N * N) return distance[N*N];
            for(int nextSpot = current + 1 ; nextSpot <= Math.Min(current + 6,N*N) ; nextSpot++)
            {
                Coordinates coor = SquareToCoordinated(nextSpot);
                
                int next = board[coor.row][coor.col] == -1 ? nextSpot : board[coor.row][coor.col];
                
                if(!distance.ContainsKey(next))
                {
                    distance.Add(next,distance[current]+1);
                    queue.Enqueue(next);
                }
            }
        }        
        return -1;              
    }
    private Coordinates SquareToCoordinated(int square)
    {
        int quotient = (square - 1) / N;
        int remaining  = (square - 1) % N;
        
        int currentRow = (N - 1) - quotient;
        int currentCol = 0;
        
        if(currentRow % 2 != N % 2)
        {
            currentCol = remaining;
        }
        else
        {
            currentCol = N - 1 - remaining;
        }
        
