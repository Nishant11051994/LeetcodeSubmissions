public class LRUCache {

    int capacity = 0;
    Dictionary<int,int> keyAndValue = new Dictionary<int,int>();
    Dictionary<int,LinkedListNode<int>> keyAndNode  = new Dictionary<int,LinkedListNode<int>>();
    LinkedList<int> list = new LinkedList<int>(); 
    public LRUCache(int capacity) 
    {
        this.capacity = capacity;
    }
    
    public int Get(int key) 
    {
        if(keyAndValue.ContainsKey(key))
        {   
            int val = keyAndValue[key];
            Remove(key);
            Add(key,val);
            return keyAndValue[key];
        }
        return -1;
    }
    
    public void Put(int key, int value) 
    {
        if(keyAndNode.ContainsKey(key))
        {
            keyAndNode[key].Value = value;
            Remove(key);
            Add(key,value);            
        }
        else
        {
            if(keyAndNode.Count == capacity)
            {
                LinkedListNode<int> firstNode = list.First;
                keyAndValue.Remove(firstNode.Value);
                keyAndNode.Remove(firstNode.Value);
                list.RemoveFirst();                
            }   
            Add(key,value);
        }      
    }
    public void Add(int key,int val)
    {
        LinkedListNode<int> currNode = new LinkedListNode<int>(key);
        keyAndValue.Add(key,val);
        keyAndNode.Add(key,currNode);
        list.AddLast(currNode);
    }
    public void Remove(int key)
    {
        LinkedListNode<int> currNode = keyAndNode[key];
        list.Remove(currNode);
        keyAndNode.Remove(key);
        keyAndValue.Remove(key);
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */