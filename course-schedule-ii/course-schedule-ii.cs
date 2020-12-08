        {
            foreach(int val in adjencyList[i])
            {
                indegree[val]++;
            }
        }
        Queue<int> queue = new Queue<int>();
        for(int i =  0; i < n ; i++)
        {
            if(indegree[i] == 0)
            {
                queue.Enqueue(i);
            }
        }   
        int count = 0;
        
        while(queue.Count!=0)
        {
            int curr = queue.Dequeue();
            Console.WriteLine(curr);
            result.Add(curr); 
            count++;
            List<int> list = adjencyList[curr];
            foreach(int val in list)
            {
                if(--indegree[val] == 0)
                {
                    queue.Enqueue(val);
                }
            }
        }        
        if(count == n)
        {
            return result.ToArray();
        }
        int[] empty = new int[0];
        return empty;
    }
}
