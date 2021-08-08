public class MovingAverage {

    /** Initialize your data structure here. */
    int size;
    Queue<int> queue;
    int currSum;
    public MovingAverage(int size) 
    {
        queue = new Queue<int>();
        this.size = size;
        currSum = 0;
    }
    
    public double Next(int val) 
    {
        if(queue.Count < size)
        {
            currSum += val;
            queue.Enqueue(val);
        }
        else
        {
            currSum -= queue.Dequeue();
            currSum += val;
            queue.Enqueue(val);
        }
        return (double)currSum / queue.Count;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */