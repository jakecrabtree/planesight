using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBundle : MonoBehaviour {

    float timeSinceBite;
    bool isTouching;
    [SerializeField]float EatSpeed = 2f;

    Buddy buddy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(isTouching)
        {
            timeSinceBite += Time.deltaTime;
            if (timeSinceBite >= EatSpeed) TakeBite();
        }
	}


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Fruit col" + collision.gameObject.tag +", time since bite " + (int) timeSinceBite + "eat spd " + EatSpeed + " eqVal " + (timeSinceBite >= EatSpeed));
        if (collision.gameObject.tag.Equals("Buddy")) {
            collision.gameObject.GetComponent<Buddy>().stop();
            buddy = collision.gameObject.GetComponent<Buddy>();
            isTouching = true;
        }       

    }

    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log("exits");
        //if(collision.gameObject.tag.Equals("Buddy")) isTouching = false;
    }

    public void TakeBite()
    {
        Debug.Log("bite");
        timeSinceBite = 0;
        if (transform.childCount == 1) {
            buddy.MoveOn();
            Destroy(gameObject);
        }
        Transform child = transform.GetChild(0);
        Destroy(child.gameObject);

    }

}
