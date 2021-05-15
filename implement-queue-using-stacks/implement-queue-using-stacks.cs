public class MyQueue {

    /** Initialize your data structure here. */
    Stack<int> mainStack;
    Stack<int> tempStack;
    int lastElementInMainStack = -1;
    public MyQueue() 
    {
        mainStack = new Stack<int>();
        tempStack = new Stack<int>();
    }
    
    /** Push element x to the back of queue. */
    public void Push(int x) 
    {
        if(mainStack.Count == 0)
        {
            lastElementInMainStack = x;
        }
        mainStack.Push(x);
    }
    
    /** Removes the element from in front of queue and returns that element. */
    public int Pop() 
    {
        MoveToTemp(lastElementInMainStack);
        
        if(tempStack.Count != 0)
        lastElementInMainStack = tempStack.Peek();
        
        int popped = mainStack.Pop();
        
        MoveFromTemp();
        
        return popped;
    }
    private void MoveToTemp(int target)
    {
        while(mainStack.Peek() != target)
        {
            int curr = mainStack.Pop();
            tempStack.Push(curr);
        }
    }
    private void MoveFromTemp()
    {
        while(tempStack.Count != 0)
        {
            mainStack.Push(tempStack.Pop());
        }
    }
    
    /** Get the front element. */
    public int Peek() 
    {
        return lastElementInMainStack;
    }
    
    /** Returns whether the queue is empty. */
    public bool Empty() 
    {
        return mainStack.Count == 0 ? true : false;
    }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */