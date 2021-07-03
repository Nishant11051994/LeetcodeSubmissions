/**
 * // This is BinaryMatrix's API interface.
 * // You should not implement it, or speculate about its implementation
 * class BinaryMatrix {
 *     public int Get(int row, int col) {}
 *     public IList<int> Dimensions() {}
 * }
 */

class Solution {
    int ROW = 0;
    int COL = 0;
    public int LeftMostColumnWithOne(BinaryMatrix binaryMatrix) 
    {
        IList<int> dimensions = binaryMatrix.Dimensions();
        ROW = dimensions[0];
        COL = dimensions[1];
        
        int leftMostColumnWithOne = COL;
        
        for(int i = 0 ; i < ROW ; i++)
        {
           int currColumn = FindLeftMostOne(i,binaryMatrix);
            Console.WriteLine(currColumn);
           if(currColumn != -1)
           {
               leftMostColumnWithOne = Math.Min(leftMostColumnWithOne,currColumn);
           }
        }       
        return leftMostColumnWithOne == COL ? -1 : leftMostColumnWithOne;
        
    }
    private int FindLeftMostOne(int row,BinaryMatrix binaryMatrix)
    {
        int left = 0;
        int right = COL-1;
        int finalColumn = -1;
        
        while(left <= right)
        {
            int mid = left + (right-left)/2;
            if(binaryMatrix.Get(row,mid) == 1)
            {
                finalColumn =  mid;
                right = mid-1;
            }
            else
            {
                left = mid + 1;
            }
        }
        
        return finalColumn;            
        }
    }