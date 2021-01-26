    {
        adjencyListIdeal[src].Add(dest);
        adjencyListIdeal[dest].Add(src);
        
        adjencyListGiven[src].Add(dest);
    }
    private void DFS(int root,bool[] visited)
    {
        if(visited[root])
        {
            return;
        }
        visited[root] = true;
        foreach(int val in adjencyListIdeal[root])
        {
            if(!visited[val] && adjencyListGiven[root].Contains(val))
            {
                Console.WriteLine(val);
                count++;
            }          
            DFS(val,visited);
        }
    }
}
