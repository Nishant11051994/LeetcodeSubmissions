public class RandomizedSet {

    List<int> list;
    Dictionary<int,int> map;
    Random random;
    /** Initialize your data structure here. */
    public RandomizedSet() 
    {
        list = new List<int>();
        map = new Dictionary<int,int>();
        random = new Random();
    }
    
    /** Inserts a value to the set. Returns true if the set did not already contain the specified element. */
    public bool Insert(int val) 
    {
        if(!map.ContainsKey(val))
        {
            map.Add(val,list.Count);
            list.Add(val);
            return true;
        }
        return false;
    }
    
    /** Removes a value from the set. Returns true if the set contained the specified element. */
    public bool Remove(int val) 
    {
        int valIndex;
        if(map.TryGetValue(val,out valIndex))
        {
            // get the last element in List
           int lastElementIndex = list.Count-1;
           int lastElement = list[lastElementIndex];
           
           // Move the value to be removed to last index
           list[lastElementIndex] = val; 
           map[val] = lastElementIndex;
            
           //Move the cached element to correct position
           list[valIndex] = lastElement;
           map[lastElement] = valIndex;
            
           // Remove the last Element
           list.RemoveAt(list.Count-1);
           map.Remove(val);
            
           return true;            
        }
        return false;       
    }
    
    /** Get a random element from the set. */
    public int GetRandom() 
    {
        return list[random.Next(list.Count)];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */