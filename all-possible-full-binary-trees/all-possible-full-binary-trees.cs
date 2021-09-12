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
    public IList<TreeNode> AllPossibleFBT(int n) 
    {
        IList<TreeNode> result = new List<TreeNode>();
        
        if(n == 0) return result;
        
        if(n == 1) {result.Add(new TreeNode(0)); return result;}
        
        for(int i = 1 ; i < n ; i += 2)
        {
            IList<TreeNode> leftSubTrees = AllPossibleFBT(i);
            IList<TreeNode> rightSubTrees = AllPossibleFBT(n-i-1);
            
            foreach(TreeNode left in leftSubTrees)
            {
                foreach(TreeNode right in rightSubTrees)
                {
                    TreeNode root = new TreeNode(0);
                    root.left = left;
                    root.right = right;
                    result.Add(root);
                }
            }
            
        }
        return result;        
    }
}