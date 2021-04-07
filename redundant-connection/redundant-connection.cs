public class DisjointSet
{
    private int[] parents;
    private int[] weights;
    public DisjointSet(int n)
    {
        parents = new int[n+1];
        weights = new int[n+1];
        for(int i = 0 ; i <= n ; i++)
        {
            parents[i] = i;
            weights[i] = i;
        }
    }
    public void Union(int a,int b)
    {
        int rootA = Find(a);
        int rootB = Find(b);
        
        if(a == b) return;
        
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
    public int Find(int a)
    {
        while(a != parents[a])
        {
            parents[a] = parents[parents[a]];
            a = parents[a];
        }
        return a;
    }
    public bool IsInSameGroup(int a,int b)
    {
        return Find(a) == Find(b);
    }
}

public class Solution {
    public int[] FindRedundantConnection(int[][] edges) 
    {
        int n = edges.Length;
        DisjointSet set = new DisjointSet(n);
        
        int[] result = new int[2];
        
        for(int i = 0 ; i < edges.Length ; i++)
        {
            int a = edges[i][0];
            int b = edges[i][1];
            if(set.IsInSameGroup(a,b))
            {
                result = edges[i]; 
                continue;
            }    
            set.Union(a,b);
        }
        return result;
    }
}



















