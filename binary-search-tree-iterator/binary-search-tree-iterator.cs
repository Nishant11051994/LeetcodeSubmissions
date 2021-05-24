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
public class BSTIterator {

    List<int> list = new List<int>();
    int index = -1;
    public BSTIterator(TreeNode root) 
    {
        InOrderTraversal(root);
    }
    
    public int Next() 
    {
        index++;
        return list[index];
    }
    
    public bool HasNext() 
    {
        return index < list.Count-1;
    }
    private void InOrderTraversal(TreeNode root)
    {
        if(root == null) return;
        InOrderTraversal(root.left);
        list.Add(root.val);
        InOrderTraversal(root.right);
    }
}

/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */