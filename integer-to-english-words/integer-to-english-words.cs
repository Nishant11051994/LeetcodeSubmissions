public class Solution {
    public string One(int num)
    {
        switch(num)
        {
            case 1 : return "One"; 
            case 2 : return "Two"; 
            case 3 : return "Three"; 
            case 4 : return "Four"; 
            case 5 : return "Five"; 
            case 6 : return "Six"; 
            case 7 : return "Seven"; 
            case 8 : return "Eight"; 
            case 9 : return "Nine";              
        }
        return "";
    }
    public string TwoLessThan20(int num)
    {
        switch(num)
        {
            case 10 : return "Ten";
            case 11 : return "Eleven";
            case 12 : return "Twelve";
            case 13 : return "Thirteen";
            case 14 : return "Fourteen";
            case 15 : return "Fifteen";
            case 16 : return "Sixteen";
            case 17 : return "Seventeen";
            case 18 : return "Eighteen";
            case 19 : return "Nineteen";
        }
        return "";
    }
    public string Ten(int num)
    {
        switch(num)
        {
            case 2 : return "Twenty";
            case 3 : return "Thirty";
            case 4 : return "Forty";
            case 5 : return "Fifty";
            case 6 : return "Sixty";
            case 7 : return "Seventy";
            case 8 : return "Eighty";
            case 9 : return "Ninety";
        }
        return "";
    }
    public string Two(int num)
    {
        if(num == 0) return "";
        
        else if(num < 10) return One(num);
        
        else if(num < 20) return TwoLessThan20(num);
        
        else 
        {
            int tenner = num / 10;
            int rest = num % 10;
            if(rest != 0)
            {
                return Ten(tenner) + " " + One(rest);
            }
            else 
                return Ten(tenner);
        }
    }
    public string Three(int num)
    {
        int hundred = num / 100;
        int rest = num % 100;
        string res = "";
        if((hundred != 0) && (rest != 0))
            res = One(hundred) + " Hundred " + Two(rest);
        else if ((hundred == 0) && (rest != 0))
            res = Two(rest);
        else if((hundred != 0) && (rest == 0))
            res = One(hundred) + " Hundred";
        
        return res;
    }
    public string NumberToWords(int num) 
    {
        if(num == 0) return "Zero";
        
        int billion = num / 1000000000;
        int million = (num - billion * 1000000000) / 1000000;
        int thousand = (num - billion * 1000000000 - million * 1000000)/1000;
        int rest = num - billion * 1000000000 - million * 1000000 - thousand * 1000;
        
        string result = "";
        if(billion != 0)
        {
            result = Three(billion) + " Billion";
        }
        if(million != 0)
        {
            if(result != string.Empty)
            {
                result += " ";
            }
            result += Three(million) + " Million";
        }
        if(thousand != 0)
        {
            if(result != string.Empty)
            {
                result += " ";
            }
            result += Three(thousand) + " Thousand";
        }
        if(rest != 0)
        {
            if(result != string.Empty)
            {
                result += " ";
            }
            result += Three(rest);
        }
        return result;
    }
}