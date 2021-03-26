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
    public IList<TreeNode> GenerateTrees(int n) 
    {
        return Recurse(1,n);
    }
    private IList<TreeNode> Recurse(int start,int end)
    {
                
        IList<TreeNode> nodes = new List<TreeNode>();
        
        if(start > end)
        {
            nodes.Add(null);
            return nodes;
        }
        
        for(int i = start ; i <= end ; i++)
        {
            IList<TreeNode> left = Recurse(start,i-1);
            
            IList<TreeNode> right = Recurse(i+1,end);
            
            foreach(TreeNode nodeLeft in left)
            {
                foreach(TreeNode nodeRight in right)
                {
                    TreeNode newNode  = new TreeNode(i);
                    
                    newNode.left = nodeLeft;
                    
                    newNode.right = nodeRight;
                    
                    nodes.Add(newNode);
                }
            }                              
        }
        return nodes;       
    }
}