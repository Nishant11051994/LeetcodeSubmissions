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
    public int FindDistance(TreeNode root, int p, int q) 
    {
        TreeNode lca = LCA(root,p,q);

        return Depth(lca,p) + Depth(lca,q);
    }
    private TreeNode LCA(TreeNode root, int p, int q)
    {
        if(root == null) return null;
        
        if(root.val == p || root.val == q) return root;
        
        TreeNode leftLCA = LCA(root.left,p,q);
        TreeNode rightLCA = LCA(root.right,p,q);
        
        if(leftLCA != null && rightLCA != null)
        {
            return root;
        }
        
        return leftLCA == null ? rightLCA : leftLCA;       
    }
    private int Depth(TreeNode node, int p)
    {
        if(node == null) return -1;
        
        if(node.val == p) return 0;
        
        int left = Depth(node.left,p);
        int right = Depth(node.right,p);
        
        if(left != -1)
        {
            return 1 + left;
        }
        if(right != -1)
        {
            return 1 +  right;
        }
        
        return -1;
    }
}