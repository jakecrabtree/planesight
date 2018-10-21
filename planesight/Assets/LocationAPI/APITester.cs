using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APITester : MonoBehaviour {

	// Use this for initialization
	void Start () {

        List<string> lt = APIWrapper.getAirports();
        APIWrapper.initialize("AA", 193, "AUS", "LAX");
        //KEEP PERIODICALLY CALLING .INITIALIZE()
        APIWrapper.initialize();
        string temperature = APIWrapper.getWeather();
        List<string> cityInfo = APIWrapper.getCity(); //<Austin, Facts about austin from wikipedia>
        List<string> landMarkInfo = APIWrapper.getLandMark(); //<Grand Canyon, Facts about Grand Canyon>
       


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
