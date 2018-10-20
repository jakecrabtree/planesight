using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class EnableAR : MonoBehaviour {

	// Use this for initialization
	void Start() {

    var vuforia = VuforiaARController.Instance;

    vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);

	}

	private void OnVuforiaStarted() {

   		FindObjectOfType<MidAirPositionerBehaviour>().enabled = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
