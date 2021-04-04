public class Solution {
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) 
    {
        Dictionary<string,Dictionary<string,double>> graph = new Dictionary<string,Dictionary<string,double>>();
        double[] results  = new double[queries.Count];
        for(int i = 0 ; i < equations.Count ; i++)
        {
            IList<string> equation = equations[i];
            
            string divident = equation[0];
            string divisor = equation[1];
            
            double quotient = values[i];
            
            if(!graph.ContainsKey(divident))
            {
                graph.Add(divident,new Dictionary<string,double>());
            }
            if(!graph.ContainsKey(divisor))
            {
                graph.Add(divisor,new Dictionary<string,double>());
            }
            graph[divident].Add(divisor,quotient);
            graph[divisor].Add(divident,1/quotient);                               
        }
        for(int i = 0 ; i < queries.Count ; i++)
            {
                string localdivident = queries[i][0];
                string localdivisor = queries[i][1];
                
                if(!graph.ContainsKey(localdivident) || !graph.ContainsKey(localdivisor))
                {
                     results[i] = -1.0;
                }                   
                else if(localdivident == localdivisor)
                {
                     results[i] =  1.0; 
                }                    
                else
                {
                    HashSet<string> visited = new HashSet<string>();
                    results[i] = BackTrack(graph,localdivident,localdivisor,1,visited);
                }              
            } 
        return results;
    }
    private double BackTrack(Dictionary<string,Dictionary<string,double>> graph, string currNode, string targetNode,double accProduct,HashSet<string> visited)
    {
        visited.Add(currNode);
        double ret = -1.0;
        Dictionary<string,double> neighbours = graph[currNode];
        if(neighbours.ContainsKey(targetNode))
        {
            ret = accProduct * neighbours[targetNode];
        }
        else
        {
            foreach(var item in neighbours)
            {
                string nextNode = item.Key;
                if(visited.Contains(nextNode))
                {
                    continue;
                }
                ret = BackTrack(graph,nextNode,targetNode,accProduct*item.Value,visited);
                if(ret != -1)
                break;                   
            }
        }
        visited.Remove(currNode);
        return ret;
    }
}