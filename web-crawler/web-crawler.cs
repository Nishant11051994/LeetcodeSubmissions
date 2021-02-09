/**
 * // This is the HtmlParser's API interface.
 * // You should not implement it, or speculate about its implementation
 * class HtmlParser {
 *     public List<String> GetUrls(String url) {}
 * }
 */

class Solution {
    public IList<string> Crawl(string startUrl, HtmlParser htmlParser) 
    {
        if(string.IsNullOrEmpty(startUrl)) return null;                       
        HashSet<string> result = new HashSet<string>();       
        Uri myUri = new Uri(startUrl);   
        string hostNameOfStartUrl = myUri.Host;              
        Queue<string> queue = new Queue<string>();
        queue.Enqueue(startUrl);
        result.Add(startUrl);
        while(queue.Count > 0)
        {
            string curr = queue.Dequeue();
            foreach(string url in htmlParser.GetUrls(curr))
            {
                 if(result.Contains(url)) continue;
                 Uri currUri = new Uri(url);   
                 string hostNameOfCurrUrl = currUri.Host;
                 if(hostNameOfCurrUrl == hostNameOfStartUrl)
                 {
                   result.Add(url);
                   queue.Enqueue(url);
                 } 
            }                       
        }            
       return result.ToList();
    }
}