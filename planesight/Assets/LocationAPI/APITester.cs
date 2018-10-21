using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APITester : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //string[] str = APIWrapper.getAirports();
        List<string> lt = APIWrapper.getAirports();
        APIWrapper.initialize("AA", 193, "AUS", "LAX");
        APIWrapper.initialize();
        string temperature = APIWrapper.getWeather();
        List<string> cityInfo = APIWrapper.getCity(); //<Austin, Facts about austin from wikipedia>
        List<string> landMarkInfo = APIWrapper.getLandMark(); //<Grand Canyon, Facts about Grand Canyon>


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
