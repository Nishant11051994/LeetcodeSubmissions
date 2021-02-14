public class Cache
{
    public int key;
    public int value;
    public Cache(int x,int y)
    {
        key = x;
        value = y;
    }
}
public class LRUCache {
    int capacity;
    Dictionary<int,LinkedListNode<Cache>> map;
    LinkedList<Cache> list;
    public LRUCache(int capacity) 
    {
        this.capacity = capacity;
        map = new Dictionary<int,LinkedListNode<Cache>>();
        list = new LinkedList<Cache>();
    }    
    public int Get(int key) 
    {
        if(map.ContainsKey(key))
        {
            int val = map[key].Value.value;
            Remove(key,val);
            AddNode(key,val);
            return val;
        }
        return -1;        
    }    
    public void Put(int key, int value) 
    {
        if(!map.ContainsKey(key) && map.Count == capacity)
        {
            RemoveLast();
        }
        else
        {
            Remove(key,value);         
        }  
        AddNode(key,value);
    }
    public void Remove(int key,int value)
    {
        if(map.ContainsKey(key))
         {
            var node = map[key];
            list.Remove(node);
         }
    }
    public void AddNode(int key,int value)
    {
        LinkedListNode<Cache> newNode = new LinkedListNode<Cache>(new Cache(key,value));
        map[key] = newNode;
        list.AddFirst(newNode); 
    }
    public void RemoveLast()
    {
       LinkedListNode<Cache> lastNode = list.Last;
       list.RemoveLast();
       int keyToBeRemoved = lastNode.Value.key;
       map.Remove(keyToBeRemoved);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */