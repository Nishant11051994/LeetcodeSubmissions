public class Map
{
    public int key;
    public int val;
    public Map(int key,int val)
    {
        this.key = key;
        this.val = val;
    }
}
​
public class MyHashMap {
  
    List<Map> list;
    /** Initialize your data structure here. */
    public MyHashMap() 
    {
        list = new List<Map>();
    }
    
    private Map ContainsKey(int num)
    {
        foreach(Map item in list)
        {
            if(item.key == num)
            {
                return item;
            }
        }
        return null;
    }
    /** value will always be non-negative. */
    public void Put(int key, int value) 
    {
        Map curr = ContainsKey(key);
        if(curr!=null)
        {
            curr.val = value;
        }
        else
        {
            list.Add(new Map(key,value));
