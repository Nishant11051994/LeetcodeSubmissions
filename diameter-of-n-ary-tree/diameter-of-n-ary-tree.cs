/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> children;
    
    public Node() {
        val = 0;
        children = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        children = new List<Node>();
    }
    
    public Node(int _val, List<Node> _children) {
        val = _val;
        children = _children;
    }
}
*/

public class Solution {
    int diameter = 0;
    public int Diameter(Node root) 
    {
        LongestPath(root);
        
        return diameter;
    }
    private int LongestPath(Node root)
    {
        if(root == null) return 0;
        
        List<int> paths = new List<int>();
        
        foreach(Node node in root.children)
        {
            int longestLength = LongestPath(node);
            Console.WriteLine(longestLength);
            paths.Add(longestLength);
        }
        
        if(paths.Count == 1)
        {
            diameter = Math.Max(diameter,paths[0]);
        }
        
        for(int i = 0 ; i < paths.Count ; i++)
        {
            for(int j = 0 ; j < paths.Count ; j++)
            {
                if(i != j)
                {
                    diameter = Math.Max(diameter,paths[i]+paths[j]);
                }
            }
        }
        
        int length = 1;
        if(paths.Count > 0)
        {
            return paths.Max() + length;
        }        
        return length;
    }
}