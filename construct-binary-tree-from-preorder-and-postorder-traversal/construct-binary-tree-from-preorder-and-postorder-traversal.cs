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
    public TreeNode ConstructFromPrePost(int[] pre, int[] post) 
    {
        if(pre == null || post == null || pre.Length == 0 || post.Length == 0) return null;
        
        return BuildTree(pre,0,pre.Length-1,post,0,post.Length-1);
    }
    private TreeNode BuildTree(int[] pre,int preStart,int preEnd,int[] post,int postStart,int postEnd)
    {
        if(preStart > preEnd)
        {
            return null;
        }
        if(preStart == preEnd)
        {
            return new TreeNode(pre[preStart]);
        }
        
        TreeNode root = new TreeNode(pre[preStart]);
        
        int leftSubtreeStartInPre = preStart+1;
        
        int succIndex = Array.IndexOf(post,pre[leftSubtreeStartInPre]);
        
        int leftSubTreeEndInPre = leftSubtreeStartInPre + (succIndex - postStart);
        
        TreeNode leftSubTree = BuildTree(pre,leftSubtreeStartInPre,leftSubTreeEndInPre,post,postStart,succIndex);
        
        TreeNode rightSubTree = 
        BuildTree(pre,leftSubTreeEndInPre+1,preEnd,post,succIndex+1,postEnd);    
        
        
        root.left = leftSubTree;
        root.right = rightSubTree;
            
        return root; 
        
    }
}










