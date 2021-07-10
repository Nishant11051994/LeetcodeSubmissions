public class Solution {
    public string ReorganizeString(string S) 
    {
        if(string.IsNullOrEmpty(S)) return S;
        
        Dictionary<char,int> freqMap = new Dictionary<char,int>();
               
        for(int i = 0 ; i < S.Length ; i++)
        {
            if(!freqMap.ContainsKey(S[i]))
            {
                freqMap.Add(S[i],0);
            }
            freqMap[S[i]]++;
        }
        Heap heap = new Heap(freqMap.Count);
        int j = 0;
        foreach(var item in freqMap)
        {
            heap.arr[j++] = new Map(item.Key,item.Value);
        }
        
        for(int i = (heap.length-1)/2 ; i >= 0 ; i--)
        {
            heap.Heapify(i);
        }
        
        string s = "";
        
        while(heap.length > 0)
        {
            Map max = heap.GetAndDeleteMax();
            if(s.Length == 0 || s[s.Length-1] != max.c)
            {
                s += max.c.ToString();
                Console.WriteLine(s);
                Console.WriteLine($"Heap length is : {heap.length}");
                max.freq--;
                if(max.freq != 0)
                {
                    heap.Insert(max);
                }
            }
            else if(s[s.Length-1] == max.c && heap.length == 0)
            {
                return "";
            }
            else if(s[s.Length-1] == max.c)
            {
                heap.Insert(max);
            }           
        }      
        return s;
        
    }
}
public class Map
{
    public char c;
    public int freq;
    public Map(char c, int freq)
    {
        this.c = c;
        this.freq = freq;
    }
}
public class Heap
{
    public Map[] arr;
    public int length;
    public Heap(int n)
    {
        arr = new Map[n];
        length = n;
    }
    public Map GetAndDeleteMax()
    {
        if(length < 0) return null;
        
        Map max = arr[0];
        
        arr[0] = arr[length-1];
        
        length--;
        
        Heapify(0);
        
        return max;
    }
    public void Heapify(int i)
    {
        while(i < length)
        {
            int left  = 2 * i + 1;
            int right = 2 * i + 2;
            int max = i;
            if(left < length && arr[left].freq > arr[max].freq)
            {
                max = left;
            }
            if(right < length && arr[right].freq > arr[max].freq)
            {
                max = right;
            }
            if( max != i)
            {
                Map temp = arr[max];
                arr[max] = arr[i];
                arr[i] = temp;
                i = max;
            }
            else break;
        }
    }
    public void Insert(Map num)
    {
        int i = length++;
        arr[i] = num;
        while( i > 0)
        {
            int parent = i-1/2;
            int min = i;
            if(parent > 0 && arr[parent].freq < arr[i].freq)
            {
                min = parent;
            }
            if(min != i)
            {
                Map temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
                i = min;
            }
            else break;
        }
    }
}