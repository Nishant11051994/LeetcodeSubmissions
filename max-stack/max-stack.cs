public class MaxStack {

    /** initialize your data structure here. */
    Stack<int> mainStack;
    Stack<int> tempStack;
    int maxValue = Int32.MinValue;
    public MaxStack() 
    {
        mainStack = new Stack<int>();
        tempStack = new Stack<int>();
    }
    
    public void Push(int x) 
    {
        maxValue = Math.Max(x,maxValue);
        mainStack.Push(x);
    }
    
    public int Pop() 
    {
        int popped = -1;
        if(mainStack.Peek() == maxValue)
        {
            popped = mainStack.Pop();
            FindNewMax();
            return popped;
        }
        return mainStack.Pop();       
    }
    private void FindNewMax()
    {
        int currMax = Int32.MinValue;
        foreach(int ele in mainStack)
        {
            currMax = Math.Max(currMax,ele);
        }
        maxValue = currMax;
    }
    public int Top() 
    {
        return mainStack.Peek();
    }
    
    public int PeekMax() 
    {
        return maxValue;
    }
    
    public int PopMax() 
    {
        while(mainStack.Peek() != maxValue)
        {
            tempStack.Push(mainStack.Pop());
        }
        int popped = mainStack.Pop();
        while(tempStack.Count != 0)
        {
            mainStack.Push(tempStack.Pop());
        }
        FindNewMax();       
        return popped;
        
    }
}

/**
 * Your MaxStack object will be instantiated and called as such:
 * MaxStack obj = new MaxStack();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.PeekMax();
 * int param_5 = obj.PopMax();
 */