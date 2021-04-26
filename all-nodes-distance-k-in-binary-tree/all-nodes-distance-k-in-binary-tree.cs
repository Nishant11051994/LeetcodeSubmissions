/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    Dictionary<int,List<int>> graph;
    public IList<int> DistanceK(TreeNode root, TreeNode target, int K) 
    {
        graph = new Dictionary<int,List<int>>();
        PopulateGraph(root);
        
        IList<int> result = new List<int>();
        
        int level = 0;
        
        Queue<int> queue = new Queue<int>();
        Dictionary<int,bool> visited = new Dictionary<int,bool>();
        foreach(var item in graph)
        {
            visited.Add(item.Key,false);
        }
        queue.Enqueue(target.val);
        visited[target.val] = true;
        bool include = false;
        
        while(queue.Count != 0)
        {
            int size = queue.Count;
            for(int i = 0; i < size ; i++)
            {
                if(level == K)
                {
                    include  = true;
                }
                int temp = queue.Dequeue();
                if(include)
                {
                    result.Add(temp);
                }
                foreach(var item in graph[temp])
                {
                    if(!visited[item])
                    {
                         queue.Enqueue(item);
                         visited[item] = true;
                    }               
                }
            }
            if(include) break;
            level++;
             
        }      
        return result;
        
    }
    private void PopulateGraph(TreeNode root)
    {
        if(root == null)
        {
            return;
        }
        if(!graph.ContainsKey(root.val))
        {
           graph.Add(root.val,new List<int>());
        }
        if(root.left != null)
        {
            graph[root.val].Add(root.left.val);
            if(!graph.ContainsKey(root.left.val))
            {
                graph.Add(root.left.val,new List<int>());
            }
            graph[root.left.val].Add(root.val);
        }
        if(root.right != null)
        {
            graph[root.val].Add(root.right.val);
            if(!graph.ContainsKey(root.right.val))
            {
                graph.Add(root.right.val,new List<int>());
            }
            graph[root.right.val].Add(root.val);
        }
        PopulateGraph(root.left);
        PopulateGraph(root.right);            
    }
}