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
    Node parent = null;
    Node result = null;
    bool found = false;
    public Node InorderSuccessor(Node x) 
    {
       FindParent(x);
       Console.WriteLine($"parent is {parent.val}");
       FindSucc(parent,x);
       return found?result:null;       
    }
    private void FindParent(Node x)
    {
        if( x != null && x.parent == null)
        {
            parent = x;
            return;
        }
        FindParent(x.parent);
    }
    private Node FindSucc(Node root,Node p)
    {
        if(root == null) return null;
        
        if(result == null && root.val > p.val && p != root)
        {
            found = true;
            result = root;
        }
        if(result != null && root.val > p.val && root.val < result.val)
        {
            found = true;
            result = root;
        }
        if(p.val < root.val)
        {
            FindSucc(root.left,p);
        }
        else if(p.val >= root.val)
        {
            FindSucc(root.right,p);
        }
        return result;
    }
    
}