public class Solution {
    public bool CanFormArray(int[] arr, int[][] pieces) 
    {
        if(arr == null || arr.Length == 0 || pieces == null || pieces.Length == 0) return false;
        int i = 0;
        while(i < arr.Length)
        {
            int j = 0;
            bool isPresent = false;
            while(j < pieces.Length)
            {
                if(pieces[j][0] == arr[i])
                {
                    isPresent = true;
                    for(int k = 0 ; k < pieces[j].Length ; k++)
                    {
                        if(pieces[j][k]!=arr[i++])
                        {
                            return false;
                        }
                    }
                    break;
                }
                else
                {
                    j++;
                }
            }
            if(!isPresent) return false;
        }
        return true;
    }
}
