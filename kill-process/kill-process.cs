

public class Solution {
    Dictionary<int,List<int>> tree;
    List<int> result;
    public IList<int> KillProcess(IList<int> pid, IList<int> ppid, int kill) 
    {
        result = new List<int>();
        
        if(pid == null || pid.Count == 0) return result;
                
        tree = new Dictionary<int,List<int>>();
        
        int rootId = -1;
        
        for(int i = 0 ; i < pid.Count ; i++)
        {
            tree.Add(pid[i],new List<int>());
        }  
        
        for(int i = 0 ; i < ppid.Count ; i++)
        {
            if(ppid[i] != 0)
            {
                tree[ppid[i]].Add(pid[i]);
            }
            else
            {
                rootId = pid[i];
            }
        } 
        
        DFS(kill);
        
        return result;
    }
    private void DFS(int killId)
    {
        result.Add(killId);
        
        foreach(var id in tree[killId])
        {
            DFS(id);
        }
    }
}