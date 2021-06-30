/**
 * This is the interface for the expression tree Node.
 * You should not remove it, and you can define some classes to implement it.
 */

public abstract class Node {
    public abstract int evaluate();
    // define your fields here
};
public class ExpressionNode : Node
{
    public string val { get; set;}
    public ExpressionNode left {get; set;}
    public ExpressionNode right { get; set;}
    
    public ExpressionNode(string val)
    {
       this.val = val;
    }
    public override int evaluate()
    {
       if(left == null && right == null)
       {
          return Convert.ToInt32(val);
       }
       else
       {
          int leftVal = left.evaluate();
          int rightVal = right.evaluate();
          int res = 0;
          
          if(val == "+")
          {
              res = leftVal + rightVal;
          }
          else if(val == "-")
          {
              res = leftVal - rightVal;
          }
          else if(val == "*")
          {
              res = leftVal * rightVal;
          }
          else if(val == "/")
          {
              res = leftVal / rightVal;
          }
          Console.WriteLine($"res is {res}, left is {leftVal}, right is {rightVal}");
          return res;
       }       
    }
}


/**
 * This is the TreeBuilder class.
 * You can treat it as the driver code that takes the postinfix input 
 * and returns the expression tree represnting it as a Node.
 */

public class TreeBuilder {
    public Node buildTree(string[] postfix) 
    {
        if(postfix == null || postfix.Length == 0) return null;
        
        Stack<ExpressionNode> stack = new Stack<ExpressionNode>();
        HashSet<string> opts = new HashSet<string>();
        opts.Add("+");
        opts.Add("-");
        opts.Add("*");
        opts.Add("/");
        
        foreach(string item in postfix)
        {
           if(opts.Contains(item))
           {
              ExpressionNode n1 = stack.Pop();
              ExpressionNode n2 = new ExpressionNode(item);
              ExpressionNode n3 = stack.Pop();
              
              n2.left = n3;
              n2.right = n1;
              
              stack.Push(n2);             
           }
           else
           {
             stack.Push(new ExpressionNode(item));
           }
        }
        
        return stack.Pop();
        
    }
}


/**
 * Your TreeBuilder object will be instantiated and called as such:
 * TreeBuilder obj = new TreeBuilder();
 * Node expTree = obj.buildTree(postfix);
 * int ans = expTree.evaluate();
 */