using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APITester : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //string[] str = APIWrapper.getAirports();
        List<string> lt = APIWrapper.getAirports();
             
        //Debug.Log(str);
        foreach(string s in lt) {
            Debug.Log(s);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
