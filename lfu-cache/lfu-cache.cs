public class LFUCache {
    private int capacity;
    private int minFrequency = Int32.MaxValue;
    Dictionary<int,int> keyAndValue = new Dictionary<int,int>();
    Dictionary<int,int> keyAndFrequency = new Dictionary<int,int>();
    Dictionary<int,LinkedList<int>> freqencyAndKeyLinkedList = new Dictionary<int,LinkedList<int>>();
    Dictionary<int,LinkedListNode<int>> keyAndLinkedNode = new Dictionary<int,LinkedListNode<int>>();

    public LFUCache(int capacity) 
    {
        this.capacity = capacity;
    }
    
    public int Get(int key) 
    {
        if(!keyAndValue.ContainsKey(key))
        {
            return -1;
        }
        AddFrequency(key);
        return keyAndValue[key];
    }
    
    public void Put(int key, int value) 
    {
        if(this.capacity <= 0) return;
        
        if(keyAndLinkedNode.ContainsKey(key))
        {
            // existing
            keyAndValue[key] = value;
            AddFrequency(key);
        }
        else
        {
            //new
            var currCapacity = keyAndLinkedNode.Count;
            if(currCapacity == capacity)
            {
                //full : remove the least usage one
                var minKeyLinkedList = freqencyAndKeyLinkedList[minFrequency];
                var removedKey = minKeyLinkedList.First();
                
                minKeyLinkedList.RemoveFirst();
                
                // Clean up
                if(minKeyLinkedList.Count == 0)
                {
                    freqencyAndKeyLinkedList.Remove(minFrequency);
                }
                
                // Clean up
                keyAndLinkedNode.Remove(removedKey);
                keyAndFrequency.Remove(removedKey);
                keyAndValue.Remove(removedKey);               
            }
            
            var newLinkedNode = new LinkedListNode<int>(key);
            minFrequency = 1;
            
            keyAndLinkedNode[key] = newLinkedNode;
            keyAndFrequency[key] = 1;
            keyAndValue[key] = value;
            
            if(!freqencyAndKeyLinkedList.ContainsKey(1))
            {
                freqencyAndKeyLinkedList[1] = new LinkedList<int>();
            }
            freqencyAndKeyLinkedList[1].AddLast(newLinkedNode);         
        }
        
        
    }
    
    private void AddFrequency(int key)
    {
        // 1. Add 1
        var currFrequency = keyAndFrequency[key];
        var nextFrequency = currFrequency + 1;
        keyAndFrequency[key] = nextFrequency;
        
        // remove from current frequency
        var curLinkedNode = keyAndLinkedNode[key];
        freqencyAndKeyLinkedList[currFrequency].Remove(curLinkedNode);
        
        
        if(!freqencyAndKeyLinkedList[currFrequency].Any())
        {
            if(minFrequency == currFrequency)
            {
                minFrequency++;
            }
            freqencyAndKeyLinkedList.Remove(currFrequency);
        }
        
        // move the current key to the last
        if(!freqencyAndKeyLinkedList.ContainsKey(nextFrequency))
        {
            freqencyAndKeyLinkedList[nextFrequency] = new LinkedList<int>();
        }
        freqencyAndKeyLinkedList[nextFrequency].AddLast(curLinkedNode);
    }
}

/**
 * Your LFUCache object will be instantiated and called as such:
 * LFUCache obj = new LFUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */