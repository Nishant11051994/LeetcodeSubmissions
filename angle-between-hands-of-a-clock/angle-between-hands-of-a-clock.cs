public class Solution {
    public double AngleClock(int hour, int minutes) 
    {
        double angle = 0;
         
        double hourAngle = 0;
        double minuteAngle = 0;
        
        if(hour == 12)
        {
            hourAngle = 0;
        }
        else
        {
            hourAngle = hour * 30;
        }
        
        hourAngle += 0.5 * minutes;
        
        minuteAngle = minutes * 6;
        
        Console.WriteLine($"hour angle is {hourAngle} and minuteAngle is {minuteAngle}");

        angle = Math.Abs(minuteAngle - hourAngle);
        
        angle = Math.Min(angle,360-angle);
        
        
        
        return angle;
    }
}