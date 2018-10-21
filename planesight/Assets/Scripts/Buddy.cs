using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Buddy : MonoBehaviour {

	ChooseSpeech speech;
	public TextBubble bubble;
	Vector3 startPos;
	Vector3 endPos;
	float moveTime = 2;
	float startTime = 0;
	float currTime = 0;
	float endTime = 0;
	bool moving = false;
	bool movingBack = false;

	// Use this for initialization
	void Start () {
		speech = gameObject.GetComponent<ChooseSpeech>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)){
			MoveToPoint(transform.parent.position + new Vector3(0,0,1));
			Debug.Log("called");
		}
		
		if ((moving||movingBack) && (currTime = Time.time) < endTime){
			transform.parent.position = Vector3.Lerp(startPos, endPos, (currTime-startTime)/moveTime);
		}
		else if (moving){
			MoveToPoint(startPos);
		}
		else if (movingBack){
			movingBack = false;
		}

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

	public void MoveToPoint(Vector3 point){
		if (moving){
			moving = false;
			movingBack = true;
		}
		else{
			moving = true;
			movingBack = false;
		}
		startPos = transform.parent.position;
		endPos = point;

		/* Vector3 relativePos = point - transform.parent.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
		rotation.y = 0;
        transform.parent.rotation = rotation;*/

		startTime = Time.time;
		currTime = startTime;
		endTime = startTime+moveTime;
	}
}
