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
    IList<TreeNode> forest = new List<TreeNode>();
    HashSet<int> set = new HashSet<int>();
    public IList<TreeNode> DelNodes(TreeNode root, int[] to_delete) 
    {
        if(root == null) return forest;
        foreach(int val in to_delete)
        {
            set.Add(val);
        }
        PreOrder(root,null);
        return forest;       
    }
    private TreeNode PreOrder(TreeNode root,TreeNode parent)
    {
        if(root == null) return null;
        
        TreeNode current = set.Contains(root.val) ? null : root;
        
        root.left = PreOrder(root.left,current);
        root.right = PreOrder(root.right,current);
        
        if(parent == null && current != null) forest.Add(root);
        return current;
    }
}








