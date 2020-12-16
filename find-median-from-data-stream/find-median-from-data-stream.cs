       {
           list.Insert(index,num);
       }
       else
       {
            //index = ~index;
            if(index == list.Count())
            {
                list.Add(num);
            }
           else
           {
               list.Insert(index,num);
           }
       }
    }
    private int FindIndex(int num)
    {
        int start = 0;
        int end = list.Count-1;
        Console.WriteLine($"end is {end}");
        while(start <= end)
        {
            int mid = start + (end - start)/2;
            Console.WriteLine(mid);
            if(list[mid] < num)
            {
                start = mid + 1;
            }
            else
            {
                end = mid - 1;
            }
        }
        return start;
    }
    
    public double FindMedian() 
    {  
        int listLength = list.Count;
        double median = 0;
        if(listLength % 2 == 0)
        {
            int listHalfLength = listLength/2;
            median = ((double)(list[listHalfLength-1] + (double) list[listHalfLength])/2);
        }
        else
        {
            median = (double)list[listLength/2];
