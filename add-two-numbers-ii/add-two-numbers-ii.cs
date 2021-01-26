            {
                sum += list1.val;
            }
            if(list2!=null)
            {
                sum += list2.val;
            }
            sum += remainder;
            remainder = sum / 10;
            sum = sum % 10;
            Console.WriteLine($"sum is {sum} and remainder is {remainder}");            
            ListNode node = new ListNode(sum);
            temp.next = node;
            temp = temp.next;
            list1 = list1?.next;
            list2 = list2?.next;
        }
        if(remainder!=0)
        {
            ListNode node = new ListNode(remainder);
            temp.next = node;
        }
        
        return ReverseList(dummyHead.next);
    }
    private ListNode ReverseList(ListNode l1)
    {
        ListNode curr = l1;
        ListNode prev = null;
        while(curr != null)
        {
            ListNode nxt = curr.next;
            curr.next = prev;
            prev = curr;
            curr = nxt;
        }
        
