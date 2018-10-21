using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tray : MonoBehaviour {
    Rect mRect;
    Transform trayTransform;

    Vector3 origin;
    Vector3 end;

    float speed;


	// Use this for initialization
	void Start () {
        trayTransform = transform.parent;
        mRect = trayTransform.gameObject.GetComponent<RectTransform>().rect;

        origin = transform.position;
        end = new Vector3(
            Screen.width - GetComponent<RectTransform>().rect.width / 2,
            origin.y,
            origin.z
            );
        speed = 0;        
	}
	
	void OnMouseDrag()
    {
    }
 
   
}
