/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {

    StringBuilder sb = new StringBuilder();
    // Encodes a tree to a single string.
    public string serialize(TreeNode root) 
    {
        PreOrder(root);
        string serialized = sb.ToString();
        serialized = serialized.Remove(serialized.Length-1);
        Console.WriteLine(serialized);
        return serialized;
    }
    private void PreOrder(TreeNode root)
    {
        if(root == null)
        {
            sb.Append("null,");
            return;
        }       
        sb.Append(root.val.ToString() + ",");
        PreOrder(root.left);
        PreOrder(root.right);
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) 
    {
        List<string> list = data.Split(",").ToList();
        return Assemble(list);        
    }
    private TreeNode Assemble(List<string> list)
    {
        if(list[0] == "null")
        {
            list.RemoveAt(0);
            return null;
        }
        int data = Convert.ToInt32(list[0]);
        list.RemoveAt(0);
        TreeNode node = new TreeNode(data);
        node.left = Assemble(list);
        node.right = Assemble(list);
        return node;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));