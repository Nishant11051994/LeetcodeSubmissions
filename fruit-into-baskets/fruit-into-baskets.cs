public class Solution {
    // Same as https://leetcode.com/problems/longest-substring-with-at-most-k-distinct-characters/ bu k is 2
    public int TotalFruit(int[] tree) 
    {
        if(tree == null || tree.Length == 0) return 0;
        
        int start = 0;
        int end = 0;
        int k = 2;
        int maxFruits = 0;
        
        Dictionary<int,int> fruitFreq = new Dictionary<int,int>();
        
        while(end < tree.Length)
        {
            if(!fruitFreq.ContainsKey(tree[end]))
            {
                fruitFreq.Add(tree[end],0);
            }
            fruitFreq[tree[end]]++;
            
            while(fruitFreq.Count > k)
            {
                fruitFreq[tree[start]]--;
                if(fruitFreq[tree[start]] == 0) fruitFreq.Remove(tree[start]);
                start++;                
            } 
            maxFruits = Math.Max(end-start+1,maxFruits);
            end++;          
        }        
        return maxFruits;       
    }
}
