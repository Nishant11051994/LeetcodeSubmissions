/**
 * The Read4 API is defined in the parent class Reader4.
 *     int Read4(char[] buf4);
 */

public class Solution : Reader4 {
    /**
     * @param buf Destination buffer
     * @param n   Number of characters to read
     * @return    The number of actual characters read
     */
    public int Read(char[] buf, int n) 
    {
        int totalCharactersRead = 0;
        int index = 0;
        int curr = -1;
        bool indexReached = false;
        do
        {
            char[] buf4 = new char[4];
            curr = Read4(buf4);           
            totalCharactersRead += curr;
            Console.WriteLine($"curr is {curr} and totalCharactersRead is {totalCharactersRead}");
            if(curr != 0)
            {
                 for(int i = 0 ; i < curr ; i++)
                    {                       
                      if(index >= n)
                       {
                         indexReached = true;
                         break;
                       }
                       else
                       {
                         buf[index++] = buf4[i];
                       }                
                     }
            }           
            if(indexReached)
            {
                break;
            }
            Console.WriteLine($"index is {index}");
           
        }while(totalCharactersRead < n && curr != 0);
          
        return index;
    }
}