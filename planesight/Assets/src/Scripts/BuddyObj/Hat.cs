using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : MonoBehaviour {
    Buddy buddy;
    // Use this for initialization
    void Start () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Buddy"))
        {
            collision.gameObject.GetComponent<Buddy>().stop();
            buddy = collision.gameObject.GetComponent<Buddy>();
            buddy.GetComponent<ItemManager>().toggleActive("Hat");
            buddy.MoveOn();
            Destroy(gameObject);
        }
        
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
