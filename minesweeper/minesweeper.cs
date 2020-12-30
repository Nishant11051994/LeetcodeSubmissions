            {7,'7'},
            {8,'8'}
        };
        queue.Enqueue(new Coordinates(click[0],click[1]));
        while(queue.Count!=0)
        {
            Coordinates curr = queue.Dequeue();
            if(board[curr.x][curr.y] == 'M') 
            {
                board[curr.x][curr.y] = 'X';
                break;
            }
            if(board[curr.x][curr.y] == 'E')
            {
            List<Coordinates> adjacent = CheckifAdjacentMinesPresent(board,curr.x,
                                                                     curr.y,out int count);
               // Console.WriteLine($"Mine count for {curr.x},{curr.y} is {count}, and adjacent count is {adjacent.Count}");
                if(count!=0)
                {
                    //Console.WriteLine((char)count);
                    board[curr.x][curr.y] =  map[count];              
                }
                else
                {
                    board[curr.x][curr.y] = 'B';
                    foreach(Coordinates c in adjacent)
                    {
                       // Console.WriteLine($"Coordinates {c.x},{c.y} added to the queue");
                        queue.Enqueue(c);
                    }
                }
            }            
        }
        
        return board;        
    }
    private bool IsSafe(int x,int y,char[][] board)
    {
        if(x >= 0 && y >= 0 && x < board.Length && y < board[x].Length)
        {
            return true;
        }
        return false;
