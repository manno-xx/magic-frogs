using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Sorter : MonoBehaviour
{
    private List<int> toSort;
    
    // Start is called before the first frame update
    void Start()
    {
        toSort = new List<int>() { 16, 8, 4, 1, 2 };

        Sort(toSort);
        
        ShowItemsOfList(toSort);
    }

    private void ShowItemsOfList(List<int> list)
    {
        // ToDo: Write a loop that shows every item from the list that is passed as a parameter
        //      Show the value in the console
        //      A foreach loop is nice to use for this. Ch 4, p. 102
        foreach (int number in list)
        {
            Debug.Log(number);
        }

        for (int i = 0; i < list.Count; i++)
        {
            Debug.Log(list[i]);
        }
    }
    
    private void Sort(List<int> ints)
    {
        // ToDo: Find a way to sort the list that is passed as a parameter
        //      There's many ways (even books written on it probably)
        //      However, look at the loooooong list of methods on this page:
        //      https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1?view=net-8.0
        //      It's probably easier than you think
        ints.Sort();
    }
}
