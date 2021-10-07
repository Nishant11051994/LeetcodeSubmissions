public enum Dir
{
   NORTH,
   WEST,
   SOUTH,
   EAST
}
public class Coor
{
  public int x {get; set;}
  public int y {get; set;}
  public Coor(int a,int b)
  {
    this.x = a;
    this.y = b;
  }
  public Coor(Coor a)
  {
    this.x = a.x;
    this.y = a.y;
  }
}

public class Solution {
    Dir currentDir = Dir.NORTH;
    Coor pos;
    int max = 0;
    public int RobotSim(int[] commands, int[][] obstacles) 
    {
        if(commands == null || commands.Length == 0) return 0;
        
        pos = new Coor(0,0);
        
        HashSet<string> set = new HashSet<string>();
        
        for(int i = 0 ; i < obstacles.Length ; i++)
        {
            set.Add(obstacles[i][0].ToString() + "," + obstacles[i][1].ToString());
        }
        
        for(int i = 0 ; i < commands.Length ; i++)
        {
          if(commands[i] == -1)
          {
            TurnRight();
          }
          else if(commands[i] == -2)
          {
            TurnLeft();
          }
          else
          {          
            Coor curr = new Coor(pos.x,pos.y);
            for(int k = 0 ; k < commands[i] ; k++)
            {
               max = Math.Max((int)(pos.x*pos.x + pos.y*pos.y),max); 
               Move(curr,1);
               string s = curr.x.ToString() + "," + curr.y.ToString();
               if(set.Contains(s))
               {
                   break;
               }
               else
               {
                 pos.x = curr.x;
                 pos.y = curr.y;
               }
            }
          }
        } 
        max = Math.Max((int)(pos.x*pos.x + pos.y*pos.y),max); 
        return max;       
    }
    private void TurnLeft()
    {
      switch(currentDir)
      {
         case Dir.NORTH:
         {
            currentDir = Dir.WEST;
            break;
         }
         case Dir.WEST:
         {
            currentDir = Dir.SOUTH;
            break;
         }
         case Dir.SOUTH:
         {
            currentDir = Dir.EAST;
            break;
         }
         case Dir.EAST:
         {
            currentDir = Dir.NORTH;
            break;
         }
      }
    }
    private void TurnRight()
    {
      switch(currentDir)
      {
         case Dir.NORTH:
         {
            currentDir = Dir.EAST;
            break;
         }
         case Dir.WEST:
         {
            currentDir = Dir.NORTH;
            break;
         }
         case Dir.SOUTH:
         {
            currentDir = Dir.WEST;
            break;
         }
         case Dir.EAST:
         {
            currentDir = Dir.SOUTH;
            break;
         }
      }
    }
    private void Move(Coor curr,int dist)
    {
       switch(currentDir)
       {
          case Dir.NORTH:
          {
             curr.y += dist;
             break;
          }
          case Dir.WEST:
          {
             curr.x -= dist;
             break;
          }
          case Dir.SOUTH:
          {
             curr.y -= dist;
             break;
          }
          case Dir.EAST:
          {
             curr.x += dist;
             break;
          }
       }
    }
}