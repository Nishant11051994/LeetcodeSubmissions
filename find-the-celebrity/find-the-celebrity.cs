/* The Knows API is defined in the parent class Relation.
      bool Knows(int a, int b); */

public class Solution : Relation {
    public int FindCelebrity(int n) 
    {
        int celebrityCount = 0;
        int celeb = -1;
        for(int i = 0 ; i < n ; i++)
        {
            bool follow = false;
            for(int j = 0 ; j < n ; j++)
            {
                if(i != j && Knows(i,j))
                {
                    Console.WriteLine($"i is {i}");
                    follow = true;
                    break;
                }
            }
            if(!follow)
            {
                Console.WriteLine($"--i is {i}");
                celeb = i;
                celebrityCount++;
            }
        }
        Console.WriteLine($"count is {celebrityCount} and celeb is {celeb}");
            if(celeb ==  -1) return -1;
            bool followBack = true;
            for(int j = 0 ; j < n ; j++)
            {
                if(celeb != j && !Knows(j,celeb))
                {
                    //Console.WriteLine($"i is {i}");
                    followBack = false;
                    break;
                }
            }
        return celebrityCount == 1 && followBack ? celeb : -1;
    }
}