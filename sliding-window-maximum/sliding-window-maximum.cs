public class Node
{
    public int Value {get; set;}
    public int Index {get; set;}
    public Node(int val,int i)
    {
        Value = val;
        Index = i;
    }
}



public class Solution {
    Node[] arr;
    int length;
    public int[] MaxSlidingWindow(int[] nums, int k) 
    {
        
       if(nums == null || nums.Length == 0) return null;
        
       int n = nums.Length;
                              
       arr = new Node[n];
        
       length = 0;
        
       
       List<int> result = new List<int>();
        
       for(int i = 0; i < k ; i++)
       {
           Insert(new Node(nums[i],i));
       }

       result.Add(GetMax().Value);
        
       for(int i = 1 ; i <= n-k ; i++)
       {
           while(GetMax() != null && GetMax().Index < i)
           {
               DeleteMax();
           }
           Insert(new Node(nums[i+k-1],i+k-1));
           result.Add(GetMax().Value);
       }
        
       return result.ToArray(); 
    }    
    private Node GetMax()
    {
        if(length > 0)
        {
            Node max = arr[0];
            return max;
        }
        return null;
    }
    private Node DeleteMax()
    {
        if(length > 0)
        {
            Node max = arr[0];
            arr[0] = arr[length-1];
            length--;
            Heapify(0);
            return max;
        }
        return null;
    }
    private void Heapify(int i)
    {
        while(i < length)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int max = i;
            if(left < length && arr[max].Value < arr[left].Value)
            {
                max = left;
            }
            if(right < length && arr[max].Value < arr[right].Value)
            {
                max = right;
            }
            if( i != max)
            {
                Node temp = arr[max];
                arr[max] = arr[i];
                arr[i] = temp;
                i = max;
            }
            else break;
        }
    }
    private void Insert(Node node)
    {
        Console.WriteLine(node.Value);
        int i = length++;
        arr[i] = node;
        while( i > 0)
        {
            int parent = (i - 1)/2;
            if(parent >= 0 && arr[parent].Value < arr[i].Value)
            {
                Node temp = arr[parent];
                arr[parent] = arr[i];
                arr[i] = temp;
                i = parent;
            }
            else break;
        }
    }
}