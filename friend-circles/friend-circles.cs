        }      
        int[] visited = new int[count];
        for(int i = 0 ; i < count ; i++)
        {
            if(visited[i] == 0)
            {
              DFS(visited,i);
              components++;
            }         
        }      
        return components;
        
    }
    private void AddEdge(int src,int dest)
    {
        if(src == dest) return;        
        Console.WriteLine($"adding edge between {src} and {dest}");
        adjList[src].Add(dest);        
    }
    
    private void DFS(int[] visited,int i)
    {
        visited[i] = 1;
        Console.WriteLine($"visited : {i}");
        foreach(int val in adjList[i])
        {
            if(visited[val] == 0)
            {
                DFS(visited,val);
            }
        }
    }
}
