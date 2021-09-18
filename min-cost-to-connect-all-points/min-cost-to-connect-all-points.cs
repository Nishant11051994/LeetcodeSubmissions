public class Edge
{
    public int src {get; set;}
    public int dest {get; set;}
    public int weight {get; set;}
    public Edge(int a,int b,int c)
    {
        src = a;
        dest = b;
        weight = c;
    }
}
public class DisjointSet
{
    public int[] parents;
    public int[] weights;
    public DisjointSet(int n)
    {
        parents = new int[n];
        weights = new int[n];
        for(int i = 0 ; i < n ; i++)
        {
            parents[i] = i;
            weights[i] = i;
        }
    }
    public int Find(int a)
    {
        while( a != parents[a])
        {
            a = parents[parents[a]];
        }
        return a;
    }
    public void Union(int a,int b)
    {
        int rootA = Find(a);
        int rootB = Find(b);
        
        if(weights[rootA] > weights[rootB])
        {
            parents[rootB] = rootA;
            weights[rootA] += weights[rootB];
        }
        else
        {
            parents[rootA] = rootB;
            weights[rootB] += weights[rootA];
        }
    }
}
public class Solution {
    public int MinCostConnectPoints(int[][] points) 
    {
        DisjointSet set = new DisjointSet(points.Length);
        
        List<Edge> edges = new List<Edge>();
        
        int result = 0;
        int numberOfEdges = 0;
        
        for(int i = 0 ; i < points.Length ; i++)
        {
            for(int j = i + 1; j < points.Length ; j++)
            {
                int wt = (Math.Abs(points[i][0] - points[j][0]) + Math.Abs(points[i][1] - points[j][1]));
                edges.Add(new Edge(i,j,wt));
            }
        }
        edges = edges.OrderBy(x => x.weight).ToList();
        
        foreach(Edge e in edges)
        {
            if(set.Find(e.src) != set.Find(e.dest))
            {
                result += e.weight;
                numberOfEdges++;
                set.Union(e.src,e.dest);
            }
            if(numberOfEdges == points.Length-1)
            {
                break;
            }
        }
        
        return result;
    }
}