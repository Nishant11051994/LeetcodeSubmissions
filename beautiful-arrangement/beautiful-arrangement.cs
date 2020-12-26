public class Solution {
    public int CountArrangement(int N) 
    {
        if(N == 0) return 0;
        
        int[] arr = new int[N];
        for(int i = 0; i < N ; i++)
        {
          arr[i] = i+1;    
        }        
        IList<IList<int>> result = new List<IList<int>>();        
        Permute(result,new List<int>(),arr);       
        return result.Count;        
    }
    private void Permute(IList<IList<int>> result,List<int> curr,int[] arr)
    {
        if(curr.Count == arr.Length)
        {
             result.Add(new List<int>(curr));           
        }
        else
        {
            for(int i = 0 ; i < arr.Length ; i++)
            {
                 if(curr.Contains(arr[i])) continue;
                 int insertIndex = curr.Count;
                 if(arr[i] % (insertIndex+1) == 0 || (insertIndex+1) % arr[i] ==0)
                 {
                    curr.Add(arr[i]);
                    Permute(result,curr,arr);
                    curr.RemoveAt(curr.Count-1);
                 }              
            }
        }
    }
   /* private bool IsBeautifulArrangement(int[] arr)
    {↔}
    */
}
