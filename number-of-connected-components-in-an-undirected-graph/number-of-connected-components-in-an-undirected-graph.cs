public class DisjointSet
{
    int[] parents;
    int[] weights;
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
    public void Union(int a,int b)
    {
        int rootA = Find(a);
        int rootB = Find(b);
        
        if(rootA == rootB) return;
        
        if(weights[rootA] > weights[rootB])
        {
            parents[rootB] = rootA;
            weights[rootA] += weights[rootB];
        }
        else
        {
            parents[rootB] = rootA;
            weights[rootA] += weights[rootB];
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
}
public class Solution {
    public int CountComponents(int n, int[][] edges) 
    {
        DisjointSet set = new DisjointSet(n);
        for(int i = 0; i < edges.Length ; i++)
        {
            set.Union(edges[i][0],edges[i][1]);
        }
        
        HashSet<int> hash = new HashSet<int>();
        int connectedComponents = 0;
        for(int i = 0 ; i < n ; i++)
        {
            int root = set.Find(i);
            if(!hash.Contains(root))
            {
                connectedComponents++;
                hash.Add(root);
            }
        }
        return connectedComponents;
        
    }
}

















