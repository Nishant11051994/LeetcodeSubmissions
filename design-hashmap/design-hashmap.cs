public class Map
{
    public int Key {get; set;}
    public int Value {get; set;}
    public Map(int x,int y)
    {
        Key = x;
        Value = y;
    }
}


public class Bucket
{
    private List<Map> bucket;
    public Bucket()
    {
       bucket = new List<Map>();
    }
    public void Add(int key,int value)
    {
       bool found = false;
       foreach(Map map in bucket)
       {
           if(map.Key == key)
           {
               found = true;
               map.Value = value;
           }
       }
       if(!found)
       {
           bucket.Add(new Map(key,value));
       }
        
    }
    public int Retrieve(int key)
    {
        foreach(Map map in bucket)
        {
            if(map.Key == key)
            {
                return map.Value;
            }
        }
        return -1;
    }
    public void Delete(int key)
    {
        Map curr = null;
        foreach(Map map in bucket)
        {
            if(map.Key == key)
            {
                curr = map;
                break;
            }
        }
        if(curr != null)
        {
            bucket.Remove(curr);
        }
    }   
}



public class MyHashMap {

    private int key_space;
    private List<Bucket> hash_table;
    /** Initialize your data structure here. */
    public MyHashMap() 
    {
        key_space = 2069;
        hash_table = new List<Bucket>();
        for(int i = 0 ; i < key_space ; i++)
        {
            hash_table.Add(new Bucket());
        }
    }
    
    /** value will always be non-negative. */
    public void Put(int key, int value) 
    {
        int hash_key = key % key_space;
        hash_table[hash_key].Add(key,value);
    }
    
    /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
    public int Get(int key) 
    {
        int hash_key = key % key_space;
        return hash_table[hash_key].Retrieve(key);
    }
    
    /** Removes the mapping of the specified value key if this map contains a mapping for the key */
    public void Remove(int key) 
    {
        int hash_key = key % key_space;
        hash_table[hash_key].Delete(key);
    }
}

/**
 * Your MyHashMap object will be instantiated and called as such:
 * MyHashMap obj = new MyHashMap();
 * obj.Put(key,value);
 * int param_2 = obj.Get(key);
 * obj.Remove(key);
 */