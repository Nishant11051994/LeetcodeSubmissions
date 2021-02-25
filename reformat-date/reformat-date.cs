public class Solution {
    public string ReformatDate(string date) 
    {
        if(string.IsNullOrEmpty(date)) return date;
        
        string[] arr = date.Split(" ");
        StringBuilder sb = new StringBuilder();
        
        sb.Append(arr[arr.Length-1]);
        sb.Append("-");
        string month = GetMonth(arr[1]);
        if(month.Length == 1)
        {
            month = "0" + month;
        }
       // Console.WriteLine($"month is {month}");
        sb.Append(month);
        sb.Append("-");
        
        string day = "";
        for(int i = 0 ; i < arr[0].Length ; i++)
        {
            if(Char.IsDigit(arr[0][i]))
            {
                day = day + arr[0][i];
            }
        }   
        if(day.Length == 1)
        {
            day = "0" + day;
        }
        sb.Append(day);
        return sb.ToString();
        
    }
    private string GetMonth(string month)
    {
        //Console.WriteLine($"month is GetMonth method is {month}");
        string result = "";
        switch(month)
        {
            case "Jan" :
                result = "1";break;
            case "Feb" :
                result = "2";break;
            case "Mar":
                result = "3";break;
            case "Apr":
                result = "4";break;
            case "May":
                result = "5";break;
            case "Jun":
                result = "6";break;
            case "Jul":
                result = "7";break;
            case "Aug":
                result = "8";break;
            case "Sep":
                result = "9";break;
            case "Oct":
                result = "10";break;
            case "Nov":
                result = "11";break;
            case "Dec":
                result = "12";break;
        }
        return result;
    }
}