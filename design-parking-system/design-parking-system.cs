public class ParkingSystem {

    Dictionary<int,int> lot;
    public ParkingSystem(int big, int medium, int small) 
    {
        lot = new Dictionary<int,int>();
        lot.Add(1,big);
        lot.Add(2,medium);
        lot.Add(3,small);
    }
    
    public bool AddCar(int carType) 
    {
        if(lot[carType] == 0) return false;
        
        lot[carType]--;
        return true;
    }
}

/**
 * Your ParkingSystem object will be instantiated and called as such:
 * ParkingSystem obj = new ParkingSystem(big, medium, small);
 * bool param_1 = obj.AddCar(carType);
 */