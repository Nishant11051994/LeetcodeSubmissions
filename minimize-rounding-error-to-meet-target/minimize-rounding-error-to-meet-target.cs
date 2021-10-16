public class Solution {
    private decimal diff = 0;
    Dictionary<string,decimal> dp;
    public string MinimizeError(string[] prices, int target) 
    {
        if(prices == null || prices.Length == 0) return string.Empty;
           
        dp = new Dictionary<string,decimal>();
        
        int j = -1;
        decimal res = Recruse(prices,0,0,target);
        if(res == -1) return j.ToString();
        
        return res.ToString();         
    }
    private decimal Recruse(string[] prices,int index,decimal sum,int target)
    {
        if(index == prices.Length && sum == target)
        {
            return 0;
        }
        if(index == prices.Length) return -1;
        
        string s = sum + "," + index;
        
        if(dp.ContainsKey(s)) return dp[s];
        
        decimal val = Convert.ToDecimal(prices[index]);
        
        decimal result = decimal.MaxValue;
        
        decimal roundDownError1 = Recruse(prices,index+1,sum + Math.Floor(val),target);
        
        
        if(roundDownError1 != -1)
        {            
            roundDownError1 += val - Math.Floor(val);
            result = Math.Min(result,roundDownError1);
        }
        
        decimal roundDownError2 = Recruse(prices,index+1,sum + Math.Ceiling(val),target);
        
        if(roundDownError2 != -1)
        {            
            roundDownError2 += Math.Ceiling(val) - val;
            result = Math.Min(result,roundDownError2);
        } 
        
        result = result == decimal.MaxValue ? -1 : result;
        dp.Add(s,result);
        return dp[s];
    }
}