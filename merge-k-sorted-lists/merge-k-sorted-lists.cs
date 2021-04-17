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
    public ListNode MergeKLists(ListNode[] lists) 
    {
        if(lists == null || lists.Length == 0) return null;
        
        return Merge(lists,0,lists.Length-1);
    }
    private ListNode Merge(ListNode[] lists,int start,int end)
    {
        if(start >= end)
        {
            return lists[start];
        }
        int mid = (start + end)/2;
        ListNode left = Merge(lists,start,mid);
        ListNode right = Merge(lists,mid+1,end);
        return MergeLists(left,right);
    }
    
    
    
    private ListNode MergeLists(ListNode l1,ListNode l2)
    {
        if(l1 == null && l2 == null) return null;
        
        if(l1 == null) return l2;
        
        if(l2 == null) return l1;
        
        ListNode dummyHead = new ListNode(-1);
        ListNode temp = dummyHead;
        dummyHead.next = temp;
        
        ListNode temp1 = l1;
        ListNode temp2 = l2;
        
        while(temp1 != null && temp2 != null)
        {
            if(temp1.val < temp2.val)
            {
                temp.next = temp1;
                temp1 = temp1.next;
            }
            else
            {
                temp.next = temp2;
                temp2 = temp2.next;
            }
            temp = temp.next;
        }
        while(temp1 != null)
        {
            temp.next = temp1;
            temp = temp.next;
            temp1 = temp1.next;       
        }
        while(temp2 != null)
        {
            temp.next = temp2;
            temp = temp.next;
            temp2 = temp2.next;                      
        }        
        return dummyHead.next;
    }
}