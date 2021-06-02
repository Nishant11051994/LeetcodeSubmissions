public class Codec {

    Dictionary<int,string> map = new Dictionary<int,string>();
    int counter = 0;
    // Encodes a URL to a shortened URL
    public string encode(string longUrl) 
    {
        map.Add(counter,longUrl);
        return "http://tinyurl.com/" + counter++;
    }

    // Decodes a shortened URL to its original URL.
    public string decode(string shortUrl) 
    {
        return map[Int32.Parse(shortUrl.Replace("http://tinyurl.com/",""))];
    }
}

// Your Codec object will be instantiated and called as such:
// Codec codec = new Codec();
// codec.decode(codec.encode(url));