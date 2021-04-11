public class DisjointSets
{
    int[] parents;
    int[] weights;
    public DisjointSets(int n)
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
    public int NumberOfComponents()
    {
        HashSet<int> set = new HashSet<int>();
        int components = 0;
        for(int i = 0 ; i < parents.Length ; i++)
        {
            int root = Find(i);
            if(!set.Contains(root))
            {
                components++;
                set.Add(root);
            }
        }
        return components;
    }
}

public class Solution {
    public int FindCircleNum(int[][] isConnected) 
    {
        int n = isConnected.Length;
        DisjointSets set = new DisjointSets(n);
        
        for(int i = 0; i < n ; i++)
        {
            for(int j = 0 ; j < isConnected[i].Length ; j++)
            {
                if(i != j && isConnected[i][j] == 1)
                {
                    set.Union(i,j);
                }
            }
        }        
        return set.NumberOfComponents();       
    }
}
























