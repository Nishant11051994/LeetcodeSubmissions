/*
// Definition for Employee.
class Employee {
    public int id;
    public int importance;
    public IList<int> subordinates;
}
*/

class Solution {
    int sum  = 0;
    public int GetImportance(IList<Employee> employees, int id) 
    {
        Employee e = employees.FirstOrDefault(x => x.id == id);
        PreOrder(e,employees);
        return sum;
    }
    private void PreOrder(Employee emp,IList<Employee> employees)
    {
        if(emp == null) return;
        
        sum += emp.importance;
        
        HashSet<int> set = new HashSet<int>(emp.subordinates);
        
        foreach(Employee e in employees)
        {
            if(set.Contains(e.id))
            {
                set.Remove(e.id);
                PreOrder(e,employees);
            }
        }
    }
}