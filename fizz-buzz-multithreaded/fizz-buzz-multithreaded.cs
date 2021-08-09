using System.Threading;

public class FizzBuzz {
    private int n;
    private int x;
    private Semaphore semNum;
    private Semaphore semFizz;
    private Semaphore semBuzz;
    private Semaphore semFizzBuzz;
    public FizzBuzz(int n) 
    {
        this.x = 1;
        this.n = n;
        semNum = new Semaphore(1,1);
        semFizz = new Semaphore(0,1);
        semBuzz = new Semaphore(0,1);
        semFizzBuzz = new Semaphore(0,1);        
    }

    // printFizz() outputs "fizz".
    public void Fizz(Action printFizz) 
    {
        while(x <= n)
        {
            semFizz.WaitOne();
            
            
            if(x > n) return;
            
            if(x % 3 == 0)
            {
                printFizz();
                x++;
            }
            
            Release(x);
        }
    }

    // printBuzzz() outputs "buzz".
    public void Buzz(Action printBuzz) 
    {
        while(x <= n)
        {
            semBuzz.WaitOne();
            
            
            if(x > n) return;
            
            if(x % 5 == 0)
            {
                printBuzz();
                x++;
            }
            
            Release(x);
        }
    }

    // printFizzBuzz() outputs "fizzbuzz".
    public void Fizzbuzz(Action printFizzBuzz) 
    {
        while(x <= n)
        {
            semFizzBuzz.WaitOne();
            
            
            if(x > n) return;
            
            if(x % 15 == 0)
            {
                printFizzBuzz();
                x++;
            }
            
            Release(x);
        }
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Number(Action<int> printNumber) 
    {
        while(x <= n)
        {
            semNum.WaitOne();
            
            
            if(x > n) return;
            
            if(x % 3 != 0 && x % 5 != 0)
            {
                printNumber(x);
                x++;
            }
            
            Release(x);
        }
    }
    private void Release(int i)
    {
        if(i > n)
        {
            semNum.Release();
            semFizz.Release();
            semBuzz.Release();
            semFizzBuzz.Release();
            return;
        }
        
        if( i % 15 == 0)
        {
            semFizzBuzz.Release();
        }
        else if( i % 3 == 0)
        {
            semFizz.Release();
        }
        else if(i % 5 == 0)
        {
            semBuzz.Release();
        }
        else
        {
            semNum.Release();
        }
        
    }
}