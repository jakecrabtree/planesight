using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownAirports : MonoBehaviour
{
    public Dropdown dropdown;

    void Start()
    {
        PopulateList();
    }

    private int min(int a, int b){
        return (a < b)? a : b;
    }

    void PopulateList()
    {
        List<string> airports = ConsoleApplication1.APIWrapper.getAirports();
        
        dropdown.AddOptions(airports.GetRange(0,min(airports.Count, 800)));
    }
}