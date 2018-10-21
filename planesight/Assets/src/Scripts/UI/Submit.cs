using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Submit : MonoBehaviour
{

	[SerializeField]public Text flightNum;
	[SerializeField]public Text departure;
	[SerializeField]public Text arrival;
	[SerializeField]private string nextSceneName;

	[SerializeField]GameObject dataObj;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnSubmitClick()
	{
		//TODO: add conditionals
		dataObj.GetComponent<PersistantFlightData>().Initialize(flightNum.text,departure.text,arrival.text);
		SceneManager.LoadScene(nextSceneName);
	}
}
