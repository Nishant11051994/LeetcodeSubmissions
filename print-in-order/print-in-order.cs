
using System.Threading;
public class Foo {

    ManualResetEvent mre1;
    ManualResetEvent mre2;
    public Foo() 
    {
       mre1 = new ManualResetEvent(false);
       mre2 = new ManualResetEvent(false);
    }

    public void First(Action printFirst) {
        
        // printFirst() outputs "first". Do not change or remove this line.
        printFirst();
        mre1.Set();
    }

    public void Second(Action printSecond) {
        mre1.WaitOne();
        // printSecond() outputs "second". Do not change or remove this line.
        printSecond();
        mre2.Set();
    }

    public void Third(Action printThird) {
        mre2.WaitOne();
        // printThird() outputs "third". Do not change or remove this line.
        printThird();
    }
}