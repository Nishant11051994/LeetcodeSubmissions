public class DisjointSets
{
    int[] parents;
    int[] weights;
    public DisjointSets(int n)
    {
        parents = new int[n];
        weights = new int[n];
        
        for(int i = 0 ; i < n ; i++)
        {
            parents[i] = i;
            weights[i] = i;
        }
    }
    public void Union(int a,int b)
    {
        int rootA = Find(a);
        int rootB = Find(b);
        
        if(rootA == rootB) return;
        
        if(weights[rootA] > weights[rootB])
        {
            parents[rootB] = rootA;
            weights[rootA] += weights[rootB];
        }
        else
        {
            parents[rootA] = rootB;
            weights[rootB] += weights[rootA];
        }
    }
    public int Find(int a)
    {
        while(a != parents[a])
        {
            parents[a] = parents[parents[a]];
            a = parents[a];
        }
        return a;
    }
}
public class Solution {
    public IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) 
    {
        
        DisjointSets set  = new DisjointSets(1000000);
        
        Dictionary<string,string> emailNameMap = new Dictionary<string,string>();
        Dictionary<string,int> emailToId = new Dictionary<string,int>();
        
        int id = 0;
        
        foreach(var list in accounts)
        {
            string name = list[0];
            for(int i = 1 ; i < list.Count ; i++)
            {
               if(!emailNameMap.ContainsKey(list[i]))
               {
                   emailNameMap.Add(list[i],name);
               }
               if(!emailToId.ContainsKey(list[i]))
               {
                   emailToId.Add(list[i],id++);
               }
               set.Union(emailToId[list[1]],emailToId[list[i]]);
            }
        }
        
        
        Dictionary<int,List<string>> ans = new Dictionary<int,List<string>>();
        foreach(string email in emailNameMap.Keys)
        {
            int index = set.Find(emailToId[email]);
            if(!ans.ContainsKey(index))
            {
                ans.Add(index,new List<string>());
            }
            ans[index].Add(email);
        }
        List<List<string>> result = new List<List<string>>(ans.Values.ToList());
        for(int i = 0 ; i < result.Count ; i++)
        {
             result[i].Sort(StringComparer.Ordinal);
             result[i].Insert(0,emailNameMap[result[i][0]]);
        }
        IList<IList<string>> final = new List<IList<string>>(result);
        return final ;
        
    }
}