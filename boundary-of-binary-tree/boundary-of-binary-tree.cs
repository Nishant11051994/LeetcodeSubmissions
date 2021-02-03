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
    public IList<int> BoundaryOfBinaryTree(TreeNode root) 
    {
        var result = new List<int>();
        if (root == null) return result;
        if (root.left == null && root.right == null)
        {
            result.Add(root.val);
            return result;
        }
        result.Add(root.val);

        Left(root.left, result);
        Leaves(root, result);
        Right(root.right, result);
        return result;
    }

    private void Left(TreeNode root,  IList<int> result)
    {
        if (root == null) return;
        if (root.left == null && root.right == null) return;

        result.Add(root.val);

        if (root.left != null) Left(root.left, result);
        else                   Left(root.right, result);
    }

    private void Leaves(TreeNode root, IList<int> result)
    {
        if (root == null) return ;
        if (root.left == null && root.right == null)
        {
            result.Add(root.val);
        }

        Leaves(root.left, result);
        Leaves(root.right, result); 
    }

    private void Right(TreeNode root, IList<int> result)
    {
        if (root == null) return;

        if (root.left == null && root.right == null) return;

        var right = root;
        if (root.right != null) Right(root.right, result);
        else if (root.right == null) Right(root.left, result);

        result.Add(right.val);
    }
}














