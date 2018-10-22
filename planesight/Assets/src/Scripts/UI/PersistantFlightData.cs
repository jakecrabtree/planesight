using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Text;

public class PersistantFlightData : MonoBehaviour {

	public string airline;
	public int flightNumber;
	public string dept;
	public string arrival;

	private static bool created = false;

	/// <summary>
	/// Awake is called when the script instance is being loaded.
	/// </summary>
	void Awake()
	{
		if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }	
	}

	public void Initialize(string flightNumber, string dept, string arrival){
		StringBuilder sb_airline = new StringBuilder("");
		StringBuilder sb_flightnum = new StringBuilder("");
		flightNumber = flightNumber.ToLower();
		foreach(char c in flightNumber){
			if (c >= 'a' && c <= 'z'){
				sb_airline.Append(c);
			}
			else if (c >= '0' && c <= '9'){
				sb_flightnum.Append(c);
			}
		}
		airline = sb_airline.ToString().ToUpper();
		this.flightNumber = 0;
		if (!Int32.TryParse(sb_flightnum.ToString(), out this.flightNumber))
		{
  	 	this.flightNumber = -1;
		}
		StringBuilder sb_dept = new StringBuilder("");
		foreach(char c in dept){
			if (c == '\"'){
				continue;
			}
			if (c == ' '){
				break;
			}
			sb_dept.Append(c);
		}
		this.dept = sb_dept.ToString();

		StringBuilder sb_arr = new StringBuilder("");
		foreach(char c in arrival){
			if (c == '\"'){
				continue;
			}
			if (c == ' '){
				break;
			}
			sb_arr.Append(c);
		}
		this.arrival = sb_arr.ToString();
	}
        
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
