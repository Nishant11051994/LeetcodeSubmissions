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
    public int DeepestLeavesSum(TreeNode root) 
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        List<int> curr = new List<int>();
        queue.Enqueue(root);
        queue.Enqueue(null);
        bool IsLastLevel = true;
        while(queue.Count != 0)
        {
            TreeNode temp = queue.Dequeue();             
            if(temp != null)
            {
                curr.Add(temp.val);
                if(temp.left != null) 
                {
                    queue.Enqueue(temp.left);
                    IsLastLevel = false;
                }
                if(temp.right != null)
                {
                    queue.Enqueue(temp.right);
                    IsLastLevel = false;
                }
            }
            else
            {
                if(IsLastLevel)
                {
                    break;
                }
                IsLastLevel = true;
                curr.Clear();
                if(queue.Count != 0)
                {
                    queue.Enqueue(null);
                }
            }
        }        
        int sum = 0;
        foreach(int item in curr)
        {
            sum += item;
        }
        return sum;
    }
}