public class SparseVector {
    IDictionary<int,int> map;
    public SparseVector(int[] nums) 
    {
        map = new Dictionary<int,int>();
        for(int i = 0 ; i < nums.Length ; i++)
        {
            if(nums[i] != 0)
            {
                map.Add(i,nums[i]);
            }
        }
    }
    
    // Return the dotProduct of two sparse vectors
    public int DotProduct(SparseVector vec) 
    {
        int dotproduct = 0;
        bool nonZeroValuePresent = false;
        foreach(var item in vec.map)
        {
            if(this.map.ContainsKey(item.Key))
            {
                dotproduct += item.Value * this.map[item.Key];
            }
        }
        return dotproduct;
    }
}

// Your SparseVector object will be instantiated and called as such:
// SparseVector v1 = new SparseVector(nums1);
// SparseVector v2 = new SparseVector(nums2);
// int ans = v1.DotProduct(v2);