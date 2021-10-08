public class Cell
{
    public int row { get; set;}
    public int col { get; set;}
    public Cell(int a,int b)
    {
        row = a;
        col = b;
    }
}

public class Solution {
    public int[][] directions = new int[8][]
    {
        new int[2]{0,1},
        new int[2]{0,-1},
        new int[2]{1,0},
        new int[2]{-1,0},
        new int[2]{-1,-1},
        new int[2]{1,-1},
        new int[2]{1,1},
        new int[2]{-1,1}
    };
    public int ShortestPathBinaryMatrix(int[][] grid) 
    {
      if(grid == null || grid.Length == 0) return 0;   
          
      if(grid[0][0] == 1) return -1;
        
      return BFS(grid); 
    }
    private List<Cell> GetNeighbours(int row,int col,int[][] grid)
    {
        List<Cell> neighbours = new List<Cell>();
        for(int i = 0 ; i < directions.Length ; i++)
        {
            int newRow = row + directions[i][0];
            int newCol = col + directions[i][1];
            
            if(newRow < 0 || newCol < 0 || newRow >= grid.Length || newCol >= grid[0].Length || grid[newRow][newCol]!=0)
            {
                continue;
            }  
            neighbours.Add(new Cell(newRow,newCol));
        }
        return neighbours;
    }
    private int BFS(int[][] grid)
    {
        Queue<Cell> queue = new Queue<Cell>();
        
        int path = 0;
        bool lastFound = false;
        queue.Enqueue(new Cell(0,0));
        grid[0][0] = 1;
        
        while(queue.Count != 0)
        {
           Cell c = queue.Dequeue();
           int distance = grid[c.row][c.col];
           if(c.row == grid.Length-1 && c.col == grid[0].Length-1) return distance;
            
           foreach(Cell cell in GetNeighbours(c.row,c.col,grid))
           {
               queue.Enqueue(cell);
               grid[cell.row][cell.col] = distance + 1;
           }            
        }
        
        return -1;
    }
}