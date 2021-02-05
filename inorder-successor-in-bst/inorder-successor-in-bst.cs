/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    TreeNode succ = null;
    public TreeNode InorderSuccessor(TreeNode root, TreeNode p) 
    {
        if(root == null) return null;
        
        PreOrder(root,p);
        
        return succ;
    }
    private void PreOrder(TreeNode root,TreeNode p)
    {
        if(root == null) return;
        
        if(root.val > p.val)
        {
            if(succ == null || succ.val > root.val)
            {
                succ = root;
            }
        }        
        PreOrder(root.left,p);
        PreOrder(root.right,p);        
    }
}