public class Directory
{
    public Dictionary<string,string> files = new Dictionary<string,string>();
    public Dictionary<string,Directory> directories = new Dictionary<string,Directory>();
}
public class FileSystem {
    public Directory root;
    public FileSystem() 
    {
        root = new Directory();
    }    
    public IList<string> Ls(string path) 
    {
       Directory directory = root;
       List<string> files = new List<string>();
       if(!path.Equals("/"))
       {
           string[] paths = path.Split("/");
           for(int i = 1 ; i < paths.Length-1 ; i++)
           {
               directory = directory.directories[paths[i]];
           }
           
           if(directory.files.ContainsKey(paths[paths.Length-1]))
           {
               files.Add(paths[paths.Length-1]);
               return files;
           }
           else
           {
                directory = directory.directories[paths[paths.Length-1]];
           }                     
       }
       files.AddRange(new List<string>(directory.files.Keys));
       files.AddRange(new List<string>(directory.directories.Keys));
       files.Sort();
       return files;        
    }    
    public void Mkdir(string path) 
    {
        string[] paths = path.Split('/');
        Directory directory = root;
        for(int i = 1 ; i < paths.Length ; i++)
        {
            if(!directory.directories.ContainsKey(paths[i]))
            {
                Directory newDir  = new Directory();
                directory.directories.Add(paths[i],newDir);
            }
            directory = directory.directories[paths[i]];
        }
    }   
    public void AddContentToFile(string filePath, string content) 
    {
        string[] paths = filePath.Split('/');
        Directory directory = root;
        for(int i = 1 ; i < paths.Length-1 ; i++)
        {
            directory = directory.directories[paths[i]];
        }
        if(!directory.files.ContainsKey(paths[paths.Length-1]))
        {
            directory.files.Add(paths[paths.Length-1],content);
        }
        else
        {
             directory.files[paths[paths.Length-1]] += content;
        }
    }  
    public string ReadContentFromFile(string filePath) 
    {
        string[] paths = filePath.Split('/');
        Directory directory = root;
        for(int i = 1 ; i < paths.Length-1 ; i++)
        {
            directory = directory.directories[paths[i]];
        }
        return directory.files[paths[paths.Length-1]];
    }
}

/**
 * Your FileSystem object will be instantiated and called as such:
 * FileSystem obj = new FileSystem();
 * IList<string> param_1 = obj.Ls(path);
 * obj.Mkdir(path);
 * obj.AddContentToFile(filePath,content);
 * string param_4 = obj.ReadContentFromFile(filePath);
 */