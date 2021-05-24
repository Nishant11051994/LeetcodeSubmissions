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
    
    public bool HasNext() 
    {
        return index < list.Count-1;
    }
    
    public int Next() 
    {
        index++;
        return list[index];
    }
    
    public bool HasPrev() 
    {
        return index > 0;
    }
    
    public int Prev()
    {
        index--;
        return list[index];
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
 * bool param_1 = obj.HasNext();
 * int param_2 = obj.Next();
 * bool param_3 = obj.HasPrev();
 * int param_4 = obj.Prev();
 */