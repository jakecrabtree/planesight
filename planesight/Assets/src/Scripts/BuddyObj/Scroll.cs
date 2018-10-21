using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {
	Buddy buddy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Use this for initializatio
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Buddy"))
        {
            collision.gameObject.GetComponent<Buddy>().stop();
            buddy = collision.gameObject.GetComponent<Buddy>();
			buddy.SayFact();
            collision.gameObject.GetComponent<Buddy>().MoveOn();
            Destroy(gameObject);
        }
        
    }
}
