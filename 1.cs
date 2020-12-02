/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    TreeNode prev = null;
    bool isValid = true;
    public bool IsValidBST(TreeNode root) 
    {
        if(root == null) return true;
        
        InOrder(root);
        
        return isValid;
        
    }
    private void InOrder(TreeNode root)
    {
        if(root == null)
        {
            return;
        }
        InOrder(root.left);
        if(prev!=null && root.val <= prev.val)
        {
            isValid = false;
            return;
        }
        prev = root;
        InOrder(root.right);
    }
    
}
