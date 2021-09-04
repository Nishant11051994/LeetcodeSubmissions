public class Solution {
    public string ReorderSpaces(string text) 
    {
        int numberOfSpaces = 0;
        string[] arr = text.Split(' ',StringSplitOptions.RemoveEmptyEntries);      
        List<string> listOfWords = arr.ToList();       
        for(int i = 0 ; i < text.Length ; i++)
        {
            if(text[i] == ' ')
            {
                numberOfSpaces++;
            }
        }
        StringBuilder sb = new StringBuilder();
        if(listOfWords.Count == 1)
        {
            sb.Append(listOfWords[0]);
            for(int i = 0 ; i < numberOfSpaces ; i++)
            {
                sb.Append(" ");
            }
            return sb.ToString();
        }
                
        int emptySpaces = listOfWords.Count - 1;
                
        int spacesToBeAdded = numberOfSpaces % emptySpaces;
        
        int betweenSpaces = numberOfSpaces / emptySpaces;
        
        
        for(int i = 0 ; i < listOfWords.Count ; i++)
        {
            sb.Append(listOfWords[i]);
            for(int j = 0 ; j < betweenSpaces && i != listOfWords.Count-1 ; j++)
            {
                sb.Append(" ");
            }
        }
        if(spacesToBeAdded > 0)
        {
            for(int i = 0 ; i < spacesToBeAdded ; i++)
            {
                sb.Append(" ");
            }
        }       
        return sb.ToString();
        
        
    }
}