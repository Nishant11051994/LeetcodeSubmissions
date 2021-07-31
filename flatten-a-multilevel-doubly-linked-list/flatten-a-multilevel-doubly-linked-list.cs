/*
// Definition for a Node.
public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;
}
*/

public class Solution {
    public Node Flatten(Node head) 
    {
        if(head == null) return null;
        
        DFS(head);
        
        return head;
        
    }
    private Node DFS(Node head)
    {
        var curr = head;
        
        while(curr != null && curr.child == null)
        {
            curr = curr.next;
        }
        
        if(curr != null)
        {
            Node nxt = curr.next;
            Node childHead = DFS(curr.child);
            curr.child = null;
            childHead.prev = curr;
            curr.next = childHead;
            
            Node currChild = childHead;
            while(currChild.next != null)
            {
                currChild = currChild.next;
            }
            currChild.next = nxt;
            if(nxt != null)
            {
                nxt.prev = currChild;
            }
            DFS(nxt);
        }
        return head;
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
}