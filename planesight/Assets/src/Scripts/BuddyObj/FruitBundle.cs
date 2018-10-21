using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBundle : MonoBehaviour {

    float timeSinceBite;
    [SerializeField]float EatSpeed = 10;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Buddy") {
            timeSinceBite += Time.deltaTime;
            if (timeSinceBite >= EatSpeed) TakeBite();
        }       

    }

    public void TakeBite()
    {
        timeSinceBite = 0;
        Transform child = transform.GetChild(0);
        if (child == null) Destroy(gameObject);
        else Destroy(child.gameObject);
    }
}
