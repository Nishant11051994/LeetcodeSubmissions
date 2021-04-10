public class Solution {
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts) 
    {
        if(h == 0 && w == 0) return 0;
        
        Array.Sort(horizontalCuts);
        Array.Sort(verticalCuts);
        
        List<int> horiList = horizontalCuts.ToList();
        List<int> verList  = verticalCuts.ToList();
        int modulo = (int)Math.Pow(10, 9) + 7;
        
        if(horiList[0] != 0)
        {
            horiList.Insert(0,0);
        }
        if(horiList[horiList.Count-1] != h)
        {
            horiList.Add(h);
        }
        if(verList[0] != 0)
        {
            verList.Insert(0,0);
        }
        if(verList[verList.Count-1] != w)
        {
            verList.Add(w);
        }
               
        int maxHeight = 0;
        int maxWidth = 0;
        
        for(int i = 1 ; i < horiList.Count ; i++)
        {
            if(horiList[i] - horiList[i-1] > maxHeight)
            {
                maxHeight = horiList[i] - horiList[i-1];
            }
        }
        
        for(int i = 1 ; i < verList.Count ; i++)
        {
            if(verList[i] - verList[i-1] > maxWidth)
            {
                maxWidth = verList[i] - verList[i-1];
            }
        }
        int result = (int)((long)maxHeight * maxWidth % modulo);
        return result;
    }
}