/*
// Definition for a QuadTree node.
public class Node {
    public bool val;
    public bool isLeaf;
    public Node topLeft;
    public Node topRight;
    public Node bottomLeft;
    public Node bottomRight;

    public Node() {
        val = false;
        isLeaf = false;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val, bool _isLeaf) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = null;
        topRight = null;
        bottomLeft = null;
        bottomRight = null;
    }
    
    public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
        val = _val;
        isLeaf = _isLeaf;
        topLeft = _topLeft;
        topRight = _topRight;
        bottomLeft = _bottomLeft;
        bottomRight = _bottomRight;
    }
}
*/

/*
public class Solution {
    public Node Construct(int[][] grid) 
    {
        if(grid == null || grid.Length == 0) return null;
        
        return ConstructHelper(grid,0,grid[0].Length-1,0,grid[0].Length-1);       
    }
    private Node ConstructHelper(int[][] grid,int columnBeginIndex,int columnEndIndex,int rowStartIndex,int rowEndIndex)
    {
        if(columnBeginIndex == columnEndIndex || AreAllCellValuesSame(grid,columnBeginIndex,columnEndIndex,rowStartIndex,rowEndIndex))
        {
            return new Node(grid[rowStartIndex][columnBeginIndex] == 1,true);
        }
        int colMid = (columnEndIndex + columnBeginIndex)/2;
        int rowMid = (rowEndIndex + rowStartIndex)/2;
        
        return new Node(false,false,
                       ConstructHelper(grid,columnBeginIndex,colMid,rowStartIndex,rowMid),
                       ConstructHelper(grid,columnBeginIndex,colMid,rowMid+1,rowEndIndex),
                       ConstructHelper(grid,colMid+1,columnEndIndex,rowStartIndex,rowMid),
                       ConstructHelper(grid,colMid+1,columnEndIndex,rowMid+1,rowEndIndex));
               
    }
    private bool AreAllCellValuesSame(int[][] grid,int columnBeginIndex,int columnEndIndex,int rowStartIndex,int rowEndIndex)
    {
        for(int row = rowStartIndex; row <= rowEndIndex ; row++)
        {
            for(int col = columnBeginIndex ; col <= columnEndIndex ; col++)
            {
                if(grid[row][col] != grid[rowStartIndex][columnBeginIndex])
                {
                    return false;
                }
            }
        }
        return true;
    }    
}

*/
class Solution {
    public Node Construct(int[][] grid) {
        if (grid == null || grid.Length == 0) {
            return null;
        }
       return constructHelper(grid, 0, 0, grid[0].Length - 1, grid[0].Length - 1); 
    }
    
    private Node constructHelper(int[][] grid, int columnBeginIndex, int rowBeginIndex, int columnEndIndex, int rowEndIndex) {
        if (columnBeginIndex == columnEndIndex || areAllCellValuesSame(grid, columnBeginIndex, rowBeginIndex, columnEndIndex, rowEndIndex)) {
            return new Node(grid[rowBeginIndex][columnBeginIndex] == 1, true);   
        }
        int colMid = (columnEndIndex + columnBeginIndex) / 2;
        int rowMid = (rowEndIndex + rowBeginIndex) / 2;
        return new Node(
            false, 
            false, 
            constructHelper(grid, columnBeginIndex, rowBeginIndex, colMid, rowMid),
            constructHelper(grid, 1 + colMid, rowBeginIndex, columnEndIndex, rowMid),
            constructHelper(grid, columnBeginIndex, 1 + rowMid, colMid, rowEndIndex),
            constructHelper(grid, 1 + colMid, 1 + rowMid, columnEndIndex, rowEndIndex) );
    }
    
    private bool areAllCellValuesSame(int[][] grid, int columnBeginIndex, int rowBeginIndex, int columnEndIndex, int rowEndIndex) {
        for (int row = rowBeginIndex; row <= rowEndIndex; row++) {
            for (int col = columnBeginIndex; col <= columnEndIndex; col++) {
                if (grid[row][col] != grid[rowBeginIndex][columnBeginIndex]) {
                    return false;
                }
            }
        }
        return true;
    }
    
}
















