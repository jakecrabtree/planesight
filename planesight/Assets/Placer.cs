using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placer : MonoBehaviour
{
	[SerializeField] private GameObject obj;

	private Transform mTrans;
	// Use this for initialization
	void Start ()
	{
		mTrans = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseDown()
	{
		PlaceInfrontOfme(-10);
	}

	public void PlaceOnMe()
	{
		PlaceInfrontOfme(0);
	}

	public void PlaceInfrontOfme(float units)
	{	
		Instantiate(obj, new Vector3(0, 0, units), Quaternion.identity);
	}
}
