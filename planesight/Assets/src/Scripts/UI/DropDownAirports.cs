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

    void PopulateList()
    {
        List<string> airports = APIWrapper.getAirports();
        
        dropdown.AddOptions(airports);
    }
}