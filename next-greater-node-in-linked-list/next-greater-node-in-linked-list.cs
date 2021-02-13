/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    public int[] NextLargerNodes(ListNode head) 
    {
       List<int> result = new List<int>();
        
       if(head == null) return result.ToArray();
        
       Dictionary<int,List<int>> nodeIndexMap = new Dictionary<int,List<int>>();
    
       ListNode temp = head;
       int index = 0;
       while(temp != null)
       {
           if(!nodeIndexMap.ContainsKey(temp.val))
           {
               nodeIndexMap.Add(temp.val,new List<int>());
           }
           nodeIndexMap[temp.val].Add(index++);
           temp = temp.next;
           result.Add(0);
       }
        
       Stack<ListNode> stack = new Stack<ListNode>();
       temp = head;
       while(temp != null)
       {
            //Console.WriteLine($"temp is {temp.val}");
            if(stack.Count == 0 || stack.Peek().val > temp.val)
            {
                  stack.Push(temp); 
            }               
            else
            {
                while(stack.Count != 0 && stack.Peek().val < temp.val)
                {
                   ListNode popped = stack.Pop();
                   int indexToInsert = nodeIndexMap[popped.val].First();
                   nodeIndexMap[popped.val].RemoveAt(0);
                   result[indexToInsert] = temp.val;
                } 
                stack.Push(temp);
             } 
           //Console.WriteLine($"stack top is {stack.Peek().val}");
           temp = temp.next;
       }
       return result.ToArray();
        
    }
}