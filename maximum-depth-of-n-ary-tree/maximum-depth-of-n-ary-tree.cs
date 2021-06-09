/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, IList<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    public int MaxDepth(Node root) 
    {
        if(root == null) return 0;
        int max = 0;
        foreach(Node node in root.children)
        {
            max = Math.Max(MaxDepth(node),max);
        }
        return max+1;
    }
}