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
    public ListNode DeleteDuplicates(ListNode head) 
    {
        if(head == null) return head;
        
        ListNode prev = head;
        ListNode curr = head.next;
        
        while(curr != null)
        {
            while(curr != null && prev.val == curr.val)
            {
                curr = curr.next;
            }
            prev.next = curr;
            prev = curr;
            curr = curr?.next;
        }
        
        return head;
    }
}