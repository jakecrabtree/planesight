using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Buddy : MonoBehaviour {

	ChooseSpeech speech;
	public TextBubble bubble;

	// Use this for initialization
	void Start () {
		speech = gameObject.GetComponent<ChooseSpeech>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	/// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while
	/// over the GUIElement or Collider.
	/// </summary>
	void OnMouseDown()
	{
		if (bubble.isReady){
			List<String> dialogue = speech.speak();
			if (dialogue != null){
				bubble.say(dialogue);
			}
		}
		else{
			bubble.next();
		}
	}
}
