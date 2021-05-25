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
    List<TreeNode> list = new List<TreeNode>();
    public void RecoverTree(TreeNode root) 
    {
        if(root == null) return;
        
        InOrder(root);
        
        for(int i = 0 ; i < list.Count ; i++)
        {
            for(int j = 0 ; j < list.Count-1-i ; j++)
            {
                if(list[j].val > list[j+1].val)
                {
                    int temp = list[j].val;
                    list[j].val = list[j+1].val;
                    list[j+1].val = temp;
                }
            }
        }
    }
    private void InOrder(TreeNode root)
    {
        if(root == null) return;
        InOrder(root.left);
        list.Add(root);
        InOrder(root.right);
    }
}