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
    int countOfGoodNodes = 0;
    public int GoodNodes(TreeNode root) 
    {
        PreOrder(root,root.val);
        return countOfGoodNodes;
    }
    private void PreOrder(TreeNode root,int maxValue)
    {
        if(root == null)
        {
            return;
        }
        if(root.val >= maxValue)
        {
           countOfGoodNodes++; 
           maxValue = root.val;
        }
        PreOrder(root.left,maxValue);
        PreOrder(root.right,maxValue);
    }
}






