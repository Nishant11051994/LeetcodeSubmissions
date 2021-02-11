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
 */
public class Solution {
    int maxNodes = 0;
    public int DiameterOfBinaryTree(TreeNode root) 
    {
        if(root == null) return 0;
        CountNodes(root);       
        return maxNodes - 1;
    }
    private int CountNodes(TreeNode root)
    {
        if(root == null) return 0;
        
        int left = CountNodes(root.left);
        int right = CountNodes(root.right);
        
        maxNodes = Math.Max(maxNodes,left+right+1);
        
        return 1 + Math.Max(left,right);       
    }
}
