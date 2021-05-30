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
    private int diameter = 0;
    public int DiameterOfBinaryTree(TreeNode root) 
    {
        LongestPath(root);
        return diameter;
    }
    private int LongestPath(TreeNode root)
    {
        if(root == null)
        {
            return 0;
        }
        
        int leftPath = LongestPath(root.left);
        int rightPath = LongestPath(root.right);
        
        diameter = Math.Max(diameter, leftPath + rightPath);
        
        return (Math.Max(leftPath,rightPath) + 1);
    }
}