public class Solution {
    public int[] FindDiagonalOrder(int[][] mat) 
    {
        int m = mat.Length;
        int n = mat[0].Length;
        
        List<int> result = new List<int>();
        bool rev = false;
        if(mat == null || mat.Length == 0) return null;
        
        // Row wise
        List<int> curr = new List<int>();
        for(int i = 0 ; i < m ; i++)
        {
            int j = 0;
            int indexSum = i + j; 
            int curri = i;
            while( curri >= 0 && j < n && curri+j == indexSum)
            {
                curr.Add(mat[curri--][j++]);
            }
            if(rev)
            {
                curr.Reverse();
            }
            result.AddRange(new List<int>(curr));
            curr.Clear();
            rev = !rev;
        }
        
        //Col wise
        for(int j = 1 ; j < n ; j++)
        {
            int i = m-1;
            int indexSum = i + j; 
            int currj = j;
            while( i >= 0 && currj < n && i+currj == indexSum)
            {
                curr.Add(mat[i--][currj++]);
            }
            if(rev)
            {
                curr.Reverse();
            }
            result.AddRange(new List<int>(curr));
            curr.Clear();
            rev = !rev;
        }
        
        foreach(int p in result)
        {
            Console.WriteLine(p);
        }
        return result.ToArray();
    }
}