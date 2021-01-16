/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    ListNode head;
    public TreeNode SortedListToBST(ListNode head) 
    {
        if(head == null) return null;
        
        int count = 0;
        ListNode temp = head;
        while(temp!=null)
        {
            count++;
            temp = temp.next;
        }
        this.head = head;
        return InOrder(0,count-1);
    }
    private TreeNode InOrder(int l,int r)
    {
        if( l > r) return null;
        
        int m = (l+r)/2;
        TreeNode left = InOrder(l,m-1);
        
        TreeNode node = new TreeNode(this.head.val);
        node.left = left;
        
        this.head = head.next;
                        
        TreeNode right = InOrder(m+1,r);
        node.right = right;
        return node;
    }
}
​
​
​
​
​
​
​
​
​
