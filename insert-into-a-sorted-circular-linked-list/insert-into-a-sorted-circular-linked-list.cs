/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
        next = null;
    }

    public Node(int _val, Node _next) {
        val = _val;
        next = _next;
    }
}
*/

public class Solution {
   public Node Insert(Node head, int insertVal) {
        if(head == null) {
            Node newNode = new Node(insertVal);
            newNode.next = newNode;
            return newNode;
        }
        Node node = head;
        
        while(node.next != head) {
            if(node.val <= node.next.val) {
                if(insertVal >= node.val && insertVal <= node.next.val) {
                    break;
                }
            } else {
                if(insertVal >= node.val || insertVal <= node.next.val) {
                    break;
                }
            }
            node = node.next;
        }
        
        Node next = node.next;
        node.next = new Node(insertVal, next);
        return head;
    }
}