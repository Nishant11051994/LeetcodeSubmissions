/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 preorder = [3,9,20,15,7]
 inorder = [9,3,15,20,7]
 
    3
  9   20
     15 7
     
 
 
 */
public class Solution {
    Dictionary<int,int> indexMap = new Dictionary<int,int>();
    int preIndex = 0;
    public TreeNode BuildTree(int[] preorder, int[] inorder) 
    {
        int index = 0;
        foreach(int val in inorder)
        {
            indexMap.Add(val,index++);
        }
        return Build(preorder,0,inorder.Length);
    }
    private TreeNode Build(int[] preorder,int instart,int inend)
    {
        if(instart == inend)
        {
            return null;
        }
        
        int rootValue = preorder[preIndex];
        
        TreeNode root = new TreeNode(rootValue);
        
        int inIndex = indexMap[rootValue];
        
        preIndex++;
        
        root.left = Build(preorder,instart,inIndex);
        
        root.right = Build(preorder,inIndex+1,inend);
        
        return root;
    }
    
}






