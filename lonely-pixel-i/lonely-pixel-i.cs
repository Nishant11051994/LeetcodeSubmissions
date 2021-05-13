public class Pixel
{
    public int row {get; set;}
    public int col {get; set;}
    public Pixel(int r,int c)
    {
        row = r;
        col = c;
    }
}
public class Solution {
    public int FindLonelyPixel(char[][] picture) 
    {
          int numberOfLonelyPixel = 0;
          List<Pixel> list = new List<Pixel>();
          for(int i = 0  ; i < picture.Length ; i++)
          {
              for(int j = 0 ; j < picture[i].Length ; j++)
              {
                  if(picture[i][j] == 'B')
                  {
                      list.Add(new Pixel(i,j));
                  }
              }
          }
        
          foreach(Pixel p in list)
          {
              bool isAlone = true;
              foreach(Pixel q in list)
              {
                  if(p != q && (p.row == q.row || p.col == q.col))
                  {
                      isAlone = false;
                      break;
                  }
              }
              if(isAlone)
              {
                  numberOfLonelyPixel++;
              }
          }
        return numberOfLonelyPixel;
    }
}