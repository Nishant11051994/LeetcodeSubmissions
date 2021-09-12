public class Solution {
    public int MaximalSquare(char[][] matrix) 
    {
        int[][] mat = new int[matrix.Length][];
        bool atLeastOne = false;
        for(int i = 0 ; i < matrix.Length ; i++)
        {
            mat[i] = new int[matrix[i].Length];
        }
        for(int i = 0 ; i < matrix.Length ; i++)
        {
            for(int j = 0 ; j < matrix[i].Length ; j++)
            {
                if(matrix[i][j] == '1')
                {
                    mat[i][j] = 1;
                }
                else
                {
                    mat[i][j] = 0;
                }
            }
        }
        int largestArea = 0;
        for(int i = 0 ; i < matrix.Length ; i++)
        {
            for(int j = 0 ; j < matrix[0].Length ; j++)
            {
                if(i != 0 && j!= 0 && mat[i][j] == 1)
                {
                    atLeastOne = true;
                    mat[i][j] += Math.Min(mat[i-1][j-1],Math.Min(mat[i-1][j],mat[i][j-1]));
                    largestArea = Math.Max(largestArea,mat[i][j]);
                }
                if(mat[i][j] == 1)  atLeastOne = true;
            }
        }
        
        if(!atLeastOne) return 0;
        
        return largestArea > 0 ? largestArea * largestArea : 1;
    }
}