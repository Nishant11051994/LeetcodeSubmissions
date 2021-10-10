public class StockPrice {

    SortedList<int,int> maxPrice;
    SortedList<int,int> minPrice;
    Dictionary<int,int> timePrice;
    int latestTime = -1;
    public StockPrice() 
    {
        maxPrice = new SortedList<int,int>(Comparer<int>.Create((x,y) => y.CompareTo(x)));
        minPrice = new SortedList<int,int>();
        timePrice = new Dictionary<int,int>();
    }
    
    public void Update(int timestamp, int price) 
    {
        latestTime = Math.Max(latestTime,timestamp);
        
        if(timePrice.ContainsKey(timestamp))
        {
            var oldValue = timePrice[timestamp];
            Remove(maxPrice,oldValue);
            Remove(minPrice,oldValue);
        }
        
        timePrice[timestamp] = price;
        Add(maxPrice,price);
        Add(minPrice,price);
        
    }
    
    public int Current() 
    {
        return timePrice[latestTime];
    }
    
    public int Maximum() 
    {
        return maxPrice.First().Key;
    }
    
    public int Minimum() 
    {
        return minPrice.First().Key;
    }
    public void Add(SortedList<int,int> list,int num)
    {
        if(list.ContainsKey(num))
        {
            list[num]++;
        }
        else
        {
            list.Add(num,1);
        }
    }
    public void Remove(SortedList<int,int> list,int num)
    {
        if(list.ContainsKey(num))
        {
            if(list[num] == 1)
            {
                list.Remove(num);
            }
            else
            {
                list[num]--;
            }
        }
    }
}

/**
 * Your StockPrice object will be instantiated and called as such:
 * StockPrice obj = new StockPrice();
 * obj.Update(timestamp,price);
 * int param_2 = obj.Current();
 * int param_3 = obj.Maximum();
 * int param_4 = obj.Minimum();
 */