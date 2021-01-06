public  class Ticket
{
    public string depart;
    public string arrival;
    public Ticket(string depart,string arrival)
    {
        this.depart = depart;
        this.arrival = arrival;
    }
}
public class Solution {
    public IList<string> FindItinerary(IList<IList<string>> tickets) 
    {
        Dictionary<string,List<string>> map = new Dictionary<string,List<string>>();
        IList<string> itinerary = new List<string>();
        foreach(var item in tickets)
        {
            if(!map.ContainsKey(item[0]))
            {
                map.Add(item[0], new List<string>());
            }
            map[item[0]].Add(item[1]);         
        }
        foreach(var key in map.Keys)
        {
            map[key].Sort();
        }
        
        itinerary.Add("JFK");
        DFS(map,"JFK",tickets.Count+1,itinerary);
        return itinerary;        
    }
    private bool DFS(Dictionary<string,List<string>> map,string currentCity,int iterLength                ,IList<string> currItinerary)
    {
            if(currItinerary.Count == iterLength)
            {
                return true;
            }
            for(int i = 0 ; map.ContainsKey(currentCity) && i < map[currentCity].Count ;i++)
            {
                string destination = map[currentCity][i];
                if(destination!="")
                {
                   currItinerary.Add(destination);
                   map[currentCity][i] = "";
                   bool found = DFS(map,destination,iterLength,currItinerary); 
                   if(found)
                   {
                       return true;
                   }
                   map[currentCity][i] = destination;
                   currItinerary.RemoveAt(currItinerary.Count-1);
                }                
            }
        return false;
     }
}
