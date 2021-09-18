public class Edge
{
    public int src { get; set;}
    public int dest { get; set;}
    public int weight { get; set;}
    public Edge(int a,int b,int c)
    {
        this.src = a;
        this.dest = b;
        this.weight = c;
    }
}

public class Solution {
    public int MinCostConnectPoints(int[][] points) 
    {
        if(points == null || points.Length == 0)
        {
            return 0;
        }
        
        int size = points.Length;
        int count = size - 1;
        int result = 0;
        MinHeap heap = new MinHeap(999999);
        bool[] visited = new bool[size];
        
        for(int i = 1 ; i < size ; i++)
        {
            int wt = Math.Abs(points[0][0]-points[i][0]) + Math.Abs(points[0][1] - points[i][1]);
            Edge e = new Edge(0,i,wt);
            heap.Insert(e);
        }
        
        visited[0] = true;
        
        while(heap.length > 0 && count > 0)
        {
            Edge ed = heap.DeleteAndReturnMin();
            int src = ed.src;
            int dest = ed.dest;
            int weight = ed.weight;
            //Console.WriteLine($"{src}:{dest}:wt:{weight}");
            if(!visited[dest])
            {
                result += weight;
                visited[dest] = true;
                for(int j = 0 ; j < size; j++)
                {
                    if(!visited[j])
                    {
                        int dist = Math.Abs(points[dest][0]-points[j][0]) + Math.Abs(points[dest][1] - points[j][1]);
                        heap.Insert(new Edge(dest,j,dist));
                    }
                }
                count--;
            }
        }
        
        return result;
    }
}
public class MinHeap
{
    Edge[] arr;
    public int length;
    public MinHeap(int n)
    {
        arr = new Edge[n];
        length = 0;
    }
    public Edge DeleteAndReturnMin()
    {
        if(length > 0)
        {
            Edge val = arr[0];
            arr[0] = arr[length-1];
            length--;
            Heapyfy(0);
            return val;
        }
        return null;
    }
    public void Heapyfy(int i)
    {
        while( i < length)
        {
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            int min = i;
            if(left < length && arr[left].weight < arr[min].weight)
            {
                min = left;
            }
            if(right < length && arr[right].weight < arr[min].weight)
            {
                min = right;
            }
            if(min != i)
            {
                Edge temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
                i = min;
            }
            else break;
        }
    }
    public void Insert(Edge e)
    {
        int index = length++;
        arr[index] = e;
        
        while(index > 0)
        {
            int parent  = (index - 1)/2;
            if(parent >= 0 && arr[parent].weight > arr[index].weight)
            {
                Edge temp = arr[index];
                arr[index] = arr[parent];
                arr[parent] = temp;
                index = parent;
            }
            else
            {
                break;
            }
        }     
    }
}