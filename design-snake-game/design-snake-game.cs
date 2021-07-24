public class Coordinate
{
    public int x;
    public int y;
    public Coordinate(int x,int y)
    {
        this.x = x;
        this.y = y;
    }
}

public class SnakeGame {

    /** Initialize your data structure here.
        @param width - screen width
        @param height - screen height 
        @param food - A list of food positions
        E.g food = [[1,1], [1,0]] means the first food is positioned at [1,1], the second is at [1,0]. */
    int width = 0;
    int height = 0;
    LinkedList<(int,int)> snake;
    HashSet<(int,int)> snakeSet;
    int[][] food;
    int foodIndex;
    public SnakeGame(int width, int height, int[][] food) 
    {
        this.food = food;
        this.height = height;
        this.width = width;
        snakeSet = new HashSet<(int,int)>();
        snake = new LinkedList<(int,int)>();
        (int,int) curr = (0,0);
        snakeSet.Add(curr);
        snake.AddLast(curr);
    }
    
    /** Moves the snake.
        @param direction - 'U' = Up, 'L' = Left, 'R' = Right, 'D' = Down 
        @return The game's score after the move. Return -1 if game over. 
        Game over when snake crosses the screen boundary or bites its body. */
    public int Move(string direction) 
    {
        (int,int) snakeHead = snake.First.Value;
        int newHeadRow = snakeHead.Item1;
        int newHeadCol = snakeHead.Item2;
        
        switch(direction)
        {
            case "U":
                   newHeadRow--;
                   break;
            case "D":
                   newHeadRow++;
                   break;
            case "L":
                   newHeadCol--;
                   break;
            case "R":
                   newHeadCol++;
                   break;                       
        }
        
        (int,int) newHead = (newHeadRow,newHeadCol);
        (int,int) currTail = snake.Last.Value;
        
        bool bitesItself = snakeSet.Contains(newHead) && !(currTail.Item1 == newHead.Item1 && currTail.Item2 == newHead.Item2);
        
        if(!IsInBoundary(newHeadRow,newHeadCol) || bitesItself) return -1;
        
        if((foodIndex < food.Length) && (food[foodIndex][0] == newHeadRow) && (food[foodIndex][1] == newHeadCol))
           {
               foodIndex++;
           }
        else
        {
            snake.RemoveLast();
            snakeSet.Remove(currTail);
        }
        
        snake.AddFirst(newHead);
        snakeSet.Add(newHead);
        
        return snake.Count - 1;
        
    }
    private bool IsInBoundary(int newRow,int newCol)
    {
        if(newRow >= 0 && newRow < height && newCol >= 0 && newCol < width)                       return true;
        
        return false;
    }
}

/**
 * Your SnakeGame object will be instantiated and called as such:
 * SnakeGame obj = new SnakeGame(width, height, food);
 * int param_1 = obj.Move(direction);
 */