﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;
using System;

public class TextBubble : MonoBehaviour {

    private GameObject textBox;
    private Renderer rend;

    public bool isReady = true;
    public Text currentText = null;
/* 
    private List<string> jokes = new List<string>();
    private List<string> weather = new List<string>();
    private List<string> eta = new List<string>();
    private List<string> facts = new List<string>();*/


    int arrayIndex = 0;

    bool showBox = false;
    bool displayText = false;

    List<string> output = null;

    StringBuilder text = new StringBuilder();
    
    // Use this for initialization
	void Start () {

        textBox = GameObject.FindGameObjectWithTag("panel");
        textBox.SetActive(false);

        currentText.text = "";
    }
	
	// Update is called once per frame
	void Update () {
        /*         currentArray = output[twoArrayindex];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            textBox.SetActive(true);
            showBox = true;
        }

        if (showBox)
        {
            if(arrayIndex == currentArray.Count)
            {
                currentText.text = "";
                textBox.SetActive(false);
            }
            else
                currentText.text = currentArray[arrayIndex];
            arrayIndex++;
            showBox = false;
        }

        if(arrayIndex == currentArray.Count + 1)
        {
            twoArrayindex++;
            arrayIndex = 0;
            showBox = false;
            if (twoArrayindex == output.Count)
            {
                twoArrayindex = 0;
                arrayIndex = 0;
            }
        }*/

        
    }

    public void say(List<String> dialogue){
        output = dialogue;
        isReady = false;
        arrayIndex = -1;
        textBox.SetActive(true);
        next();
    }

    public void next(){
        arrayIndex++;
        if (arrayIndex == output.Count){
            currentText.text = "";
            isReady = true;
            textBox.SetActive(false);
        }
        else{
            currentText.text = output[arrayIndex];
        }
    }


}
