/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node parent;
}
*/

public class Solution {
    Node root = null;
    public Node LowestCommonAncestor(Node p, Node q) 
    {
        FindRoot(q);
        return LCA(p,q,root);
    }
    private void FindRoot(Node q)
    {
        if(q.parent == null)
        {
            root = q;
            return;
        }
        FindRoot(q.parent);
    }
    private Node LCA(Node p, Node q, Node root)
    {       
        if(root == p || root == q || root == null) return root;
        
        Node left = LCA(p,q,root.left);
        Node right = LCA(p,q,root.right);
        
        if(left != null && right != null) return root;
        
        return left == null ? right : left;       
    }
}