public class Solution {
    public int[] AsteroidCollision(int[] asteroids)
    {
        if(asteroids == null || asteroids.Length == 0) return asteroids;
        
        Stack<int> stack = new Stack<int>();
        
        for(int i = 0 ; i < asteroids.Length ; i++)
        {
                int curr = asteroids[i];
                while(stack.Count > 0 && curr != 0 && WillCollide(stack.Peek(),curr))
                {
                    int popped = stack.Pop();
                    curr = Explosion(popped,curr);
                }
                if(curr != 0)        
                stack.Push(curr);
        }
        
        int[] result = stack.ToArray();
        Array.Reverse(result);
        return result;
    }
    private bool WillCollide(int a,int b)
    {
        if(a > 0 && b > 0 || a < 0 && b < 0) return false;
        
        if(a < 0 && b > 0) return false;
        
        return true;
    }
    private int Explosion(int a,int b)
    {
        if(a == -1 * b) return 0;
        
        if(Math.Abs(a) > Math.Abs(b)) return a;
        
        return b;
    }
}