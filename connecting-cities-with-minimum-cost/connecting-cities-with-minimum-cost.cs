public class DisjointSet 
{
    private int[] parents;
    private int[] weights;
    
    public DisjointSet(int n)
    {
        parents = new int[n+1];
        weights = new int[n+1];
        // Setting initial parent node to itself
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
        
        if(rootA == rootB)
        {
            return;
        }
        // Take Union 
        if(this.weights[rootA] > this.weights[rootB])
        {
            this.parents[rootB] = rootA;
            this.weights[rootA] += this.weights[rootB];
        }
        else
        {
            this.parents[rootA] = rootB;
            this.weights[rootB] += this.weights[rootA];
        }   
    }    
    public int Find(int a)
    {
        while(a != this.parents[a])
        {
            // Path compression extra step
            this.parents[a] = this.parents[parents[a]];
            a = this.parents[a];
        }
        return a;
    }
    public bool IsInSameGroup(int a,int b)
    {
        return Find(a) == Find(b);
    }    
}
public class Solution {
    public int MinimumCost(int N, int[][] connections) 
    {
        DisjointSet disjointSet = new DisjointSet(N);
        
       // Array.Sort(connections,(a,b) => a[2] - b[2]);
        connections = connections.OrderBy(x => x[2]).ToArray();
        
        
        int totalEdges = 0;
        
        int totalCost = 0;
        
        for(int i = 0 ; i < connections.Length ; i++)
        {
            int a = connections[i][0];
            int b = connections[i][1];
            
            if(disjointSet.IsInSameGroup(a,b))
            {
                continue;
            }
            disjointSet.Union(a,b);
            totalCost += connections[i][2];
            totalEdges++;            
        }
        // if all edges are connected Minimum Spanning Tree will have N-1 edges
        if(totalEdges == N-1)
        {
            return totalCost;
        }
        else
        {
            return -1;
        }       
    }
}