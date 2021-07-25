public class Solution {
    public int CountBalls(int lowLimit, int highLimit) 
    {
        int[] arr = new int[50];
        
        for(int i = lowLimit ; i <= highLimit ; i++)
        {
            int sum = SumOfDigits(i);
            Console.WriteLine(sum);
            arr[sum]++;
        }
        return arr.Max();
        
    }
    private int SumOfDigits(int x)
    {
        int sum = 0;
        while(x >= 10)
        {
            sum += x % 10;
            x /= 10;
        }
        sum += x;
        return sum;
    }
}