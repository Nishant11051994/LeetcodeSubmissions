public class Solution {
    public bool SearchMatrix(int[][] matrix, int target) 
    {
        if(matrix == null || matrix.Length == 0) return false;
        
        int n = matrix.Length;
        int m = matrix[0].Length;
        
        int start = 0;
        int end = n * m - 1;
        
        while(start <= end)
        {
            int idx = (start+end)/2;
            int pivot = matrix[idx / m][idx % m];
            if(pivot == target)
            {
                return true;
            }
            else if(target < pivot)
            {
                end = idx - 1;            
            }
            else
            {
                start = idx + 1;
            }
        }
        
        return false;
    }
}
