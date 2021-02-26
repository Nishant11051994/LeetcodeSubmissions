public class Points
{
    public int x;
    public int y;
    public Points(int a,int b)
    {
        x = a;
        y = b;
    }
}

public class Solution {
    char currDirection = 'N';
    Points points;
    public bool IsRobotBounded(string instructions) 
    {
        if(string.IsNullOrEmpty(instructions)) return false;       
        
        points = new Points(0,0);
        
        for(int i = 0 ; i < instructions.Length ; i++)
        {
            if(instructions[i] == 'G')
            {
                MoveOneUnit();
            }
            else
            {
                ChangeDirection(instructions[i]);
            }
        }
        
        if(currDirection != 'N' || points.x == 0 && points.y == 0)
        {
            return true;
        }
        
        return false;       
    }
    private void MoveOneUnit()
    {
        switch(currDirection)
        {
            case 'N':
            points.y = points.y + 1; break;
            case 'S':
            points.y = points.y - 1; break;
            case 'W':
            points.x = points.x - 1; break;
            case 'E':
            points.x = points.x + 1; break;
        }
    }
    private void ChangeDirection(char direc)
    {
       switch(currDirection)
       {
           case 'N' :
           if(direc == 'L')
           {
               currDirection = 'W';
           }
           else
           {
               currDirection = 'E';
           }
           break;
           case 'S' :
           if(direc == 'L')
           {
               currDirection = 'E';
           }
           else
           {
               currDirection = 'W';
           }
           break;
           case 'E' :
           if(direc == 'L')
           {
               currDirection = 'N';
           }
           else
           {
               currDirection = 'S';
           }
           break;
           case 'W' : 
           if(direc == 'L')
           {
               currDirection = 'S';
           }
           else
           {
               currDirection = 'N';
           }
           break;
       }
    }
}