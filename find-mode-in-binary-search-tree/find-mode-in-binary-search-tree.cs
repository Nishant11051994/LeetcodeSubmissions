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
    Dictionary<int,int> freqMap;
    public int[] FindMode(TreeNode root) 
    {
        freqMap = new Dictionary<int,int>();
        
        InOrder(root);
        
        int maxCount = freqMap.Values.Max();
        
        Console.WriteLine(maxCount);
        
        List<int> result = new List<int>();
        
        foreach(var item in freqMap)
        {
            if(item.Value == maxCount)
            {
                result.Add(item.Key);
            }
        }
        
        return result.ToArray();
    }
    private void InOrder(TreeNode root)
    {
        if(root == null) return;
        
        InOrder(root.left);
        if(!freqMap.ContainsKey(root.val))
        {
            freqMap.Add(root.val,0);
        }
        freqMap[root.val]++;
        InOrder(root.right);
    }
}