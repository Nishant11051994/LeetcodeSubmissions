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
            parents[rootA] = rootB;
            weights[rootA] += weights[rootB];
        }
        else
        {
            parents[rootB] = rootA;
            weights[rootB] += weights[rootA];
        }
    }
    public int Find(int a)
    {
        while(a != parents[parents[a]])
        {
            a = parents[parents[a]];
        }
        return a;
    }
    public bool HasSameParent(int a,int b)
    {
        int rootA = Find(a);
        int rootB = Find(b);
        return rootA == rootB;
    }
}

public class Solution {
    public bool ValidTree(int n, int[][] edges) 
    {
        DisjointSet set = new DisjointSet(n);
        HashSet<int> hash  = new HashSet<int>();
        for(int i = 0 ; i < edges.Length ; i++)
        {
            int a = edges[i][0];
            int b = edges[i][1];
            if(set.HasSameParent(a,b))
            {
                return false;
            }
            else
            {
                set.Union(a,b);
            }
        }
        for(int i = 0 ; i < n ; i++)
        {
            int root = set.Find(i);
            if(hash.Count == 0)
            {
                hash.Add(root);
            }
            else if(hash.Count > 0 && !hash.Contains(root))
            {
                return false;
            }
        }
        return true;
    }
}


















