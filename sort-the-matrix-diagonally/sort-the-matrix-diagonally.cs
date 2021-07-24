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

public class Solution {
    public int[][] DiagonalSort(int[][] mat) 
    {
        if(mat == null || mat.Length == 0) return mat;
        
        int rowCount = mat.Length;
        int colCount = mat[0].Length;
        
        Dictionary<Coordinate,List<int>> map1 = new Dictionary<Coordinate,List<int>>();
        Dictionary<Coordinate,List<int>> map2 = new Dictionary<Coordinate,List<int>>();
        
        int j = 0;
        for(int i = 0 ; i < colCount ; i++)
        {
            map1.Add(new Coordinate(j,i),new List<int>());
            map2.Add(new Coordinate(j,i),new List<int>());
        }
        j = 0;
        for(int i = 1 ; i < rowCount ; i++)
        {
            map1.Add(new Coordinate(i,j),new List<int>());
            map2.Add(new Coordinate(j,i),new List<int>());
        }
        
        foreach(Coordinate c in map1.Keys)
        {
           int p = c.x;
           int q = c.y;
           List<int> curr = new List<int>();
           while(p < rowCount && q < mat[p].Length)
           {
               curr.Add(mat[p][q]);
               p++;
               q++;
           }
           curr.Sort();
           map2[c] = curr;
           foreach(int l in curr)
           {
               Console.WriteLine(l);
           }
           Console.WriteLine();
        }
        
        foreach(Coordinate c in map1.Keys)
        {
           int p = c.x;
           int q = c.y;
           int index = 0;
           while(p < rowCount && q < mat[p].Length)
           {
               mat[p][q] = map2[c][index++];
               p++;
               q++;
           }
        }
        
        return mat;
        
    }
}