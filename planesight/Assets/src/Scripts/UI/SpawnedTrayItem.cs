﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpawnedTrayItem : MonoBehaviour
{
    bool placed;
    public void OnPointerDown(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    // Use this for initialization
    void Start () {
        placed = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!placed) { 
            Vector3 p = Input.mousePosition;
            p.z = 0.5f;
            Vector3 pos = Camera.main.ScreenToWorldPoint(p);
            transform.position = pos;
            if (!Input.GetMouseButton(0)){
                placed = true;
            }
        } else {
            transform.RotateAround(transform.position, Vector3.up, Time.deltaTime*30);
        }
        
    }

    
}
