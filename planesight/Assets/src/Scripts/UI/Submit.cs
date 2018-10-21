using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Submit : MonoBehaviour
{

	[SerializeField] private string nextSceneName;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnSubmitClick()
	{
		//TODO: add conditionals
		
		SceneManager.LoadScene(nextSceneName);
	}
}
