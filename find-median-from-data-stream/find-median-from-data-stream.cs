public class MinHeap
{
    public int[] arr;
    public int length;
    public MinHeap()
    {
        arr = new int[10000];
        length = 0;
    }
    public void Heapify(int i)
    {
        while(i < length)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int min = i;
            if(left < length && arr[min] > arr[left])
            {
                min = left;
            }
            if(right < length && arr[min] > arr[right])
            {
                min = right;
            }
            if(min != i)
            {
                int temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
                i = min;
            }
            else
                break;
        }
    }
    public void Insert(int num)
    {
        int i = length++;
        arr[i] = num;
        while(i > 0)
        {
            int parent = (i - 1)/2;
            if(parent >= 0 && arr[parent] > arr[i])
            {
                int temp = arr[parent];
                arr[parent] = arr[i];
                arr[i] = temp;
                i = parent;
            }
            else
                break;
        }
    }
    public int GetAndRemoveMin()
    {
        int min = -1;
        if(length > 0)
        {
            min = arr[0];
            arr[0] = arr[length-1];
            length--;
            Heapify(0);
        }        
        return min;
    }
    public int GetMin()
    {
        int min = -1;
        if(length > 0)
        {
            min = arr[0];
        }        
        return min;
    }
}
public class MaxHeap
{
    public int[] arr;
    public int length;
    public MaxHeap()
    {
        arr = new int[10000];
        length = 0;
    }
    public void Heapify(int i)
    {
        while(i < length)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int max = i;
            if(left < length && arr[max] < arr[left])
            {
                max = left;
            }
            if(right < length && arr[max] < arr[right])
            {
                max = right;
            }
            if(max != i)
            {
                int temp = arr[max];
                arr[max] = arr[i];
                arr[i] = temp;
                i = max;
            }
            else
                break;
        }
    }
    public void Insert(int num)
    {      
        int i = length++;
        arr[i] = num;
        while(i > 0)
        {
            int parent = (i - 1)/2;
            if(parent >= 0 && arr[parent] < arr[i])
            {
                int temp = arr[parent];
                arr[parent] = arr[i];
                arr[i] = temp;
                i = parent;
            }
            else
                break;
        }
    }
    public int GetAndRemoveMax()
    {
        int max = -1;
        if(length > 0)
        {
            max = arr[0];
            arr[0] = arr[length-1];
            length--;
            Heapify(0);
        }        
        return max;
    }
     public int GetMax()
    {
        int max = -1;
        if(length > 0)
        {
            max = arr[0];
        }        
        return max;
    }
}
public class MedianFinder 
{
    /** initialize your data structure here. */
    MinHeap hi;
    MaxHeap lo;
    public MedianFinder() 
    {
        hi = new MinHeap();
        lo = new MaxHeap();
    }
    
    public void AddNum(int num) 
    {
        lo.Insert(num);
        
        int lomax = lo.GetAndRemoveMax();
        
        hi.Insert(lomax);
        
        if(lo.length < hi.length)
        {
            int himin = hi.GetAndRemoveMin();
            lo.Insert(himin);
        }
    }
    
    public double FindMedian() 
    {
        double result = 0.0;
        if(lo.length > hi.length)
        {
            result = lo.GetMax();
        }
        else
        {
            int sum = lo.GetMax() + hi.GetMin();
            double median = sum * 0.5;
            result = median;
        }
         
        return result;
    }
}


/**
 * Your MedianFinder object will be instantiated and called as such:
 * MedianFinder obj = new MedianFinder();
 * obj.AddNum(num);
 * double param_2 = obj.FindMedian();
 */