/* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

public class Solution : Relation {
    public int FindCelebrity(int n) 
    {
        int celeb = -1;
        int celebrityCount = 0;
        for(int i = 0 ; i < n ; i++)
        {
            bool followSomeone = false;
            for(int j = 0 ; j < n ; j++)
            {
                if(Knows(i,j) && i != j)
                {
                    followSomeone = true;
                    break;
                }
            }
            if(!followSomeone)
            {
                celeb = i;
                celebrityCount++;
            }
        }
        
        Console.WriteLine(celeb);
        if(celeb ==  -1) return -1;
        
        bool allFollow = true;
        for(int i = 0 ; i < n ; i++)
        {
            if(celeb != i && !Knows(i,celeb))
            {
                allFollow = false;
                break;
            }
        }
               
        return celebrityCount == 1  && allFollow ? celeb : -1;
    }
}