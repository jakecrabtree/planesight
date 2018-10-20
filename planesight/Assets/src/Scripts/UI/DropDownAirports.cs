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
        List<string> airports = new List<string>() {"Ian", "Jake", "David", "Steve", "Nidhen"};
        dropdown.AddOptions(airports);
    }
}