using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Buddy : MonoBehaviour {

	ChooseSpeech speech;
	public TextBubble bubble;
	private Vector3 homePos;
	private Quaternion homeRot;

	Vector3 startPos;
	Vector3 endPos;
	float moveTime = 2;
	float startTime = 0;
	float currTime = 0;
	float endTime = 0;
	bool moving = false;
	bool movingBack = false;
	bool homeSet = false;

	bool readyToMoveOn = true;
	bool atDestination = false;

	Queue<Transform> path;

	// Use this for initialization
	void Start () {
		path = new Queue<Transform>();
		speech = gameObject.GetComponent<ChooseSpeech>();
	}
	
	// Update is called once per frame
	void Update () {
		if ((moving||movingBack) && (currTime = Time.time) < endTime){
			if (moving){
				transform.parent.position = Vector3.Lerp(startPos, endPos, (currTime-startTime)/moveTime);
			}
			else{
				if (path.Count > 0){
					Transform t = path.Dequeue();
					MoveToPoint(t.position);
				}
				else{
					Debug.Log("Going Home");
					transform.parent.position = Vector3.Lerp(startPos, endPos, (currTime-startTime)/moveTime);
				}
			}
		}
		else if(moving && !atDestination && readyToMoveOn){
			atDestination = true;
			readyToMoveOn = false;
		}
		else if (path.Count > 0 && readyToMoveOn){
			Transform transform = path.Dequeue();
			MoveToPoint(transform.position);
		}
		else if (moving && readyToMoveOn){
			MoveHome();
		}
		else if (movingBack && readyToMoveOn){
			movingBack = false;
			transform.parent.rotation = homeRot;
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

	private void MoveHome(){
		moving = false;
		movingBack = true;
		atDestination = false;
		startPos = transform.parent.position;
		endPos = homePos;
/* 
		Vector3 relativePos = homePos - transform.parent.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, transform.parent.up);
		rotation.y = 0;
        transform.parent.rotation = rotation;*/

		startTime = Time.time;
		currTime = startTime;
		endTime = startTime+moveTime;
	}

	public void MoveToPoint(Vector3 point){
		if (!homeSet){
			homeSet = true;
			homePos = transform.parent.position;
			homeRot = transform.parent.rotation;
		}
		movingBack = false;
		moving = true;
		atDestination = false;
		startPos = transform.parent.position;
		endPos = point;
/* 
		Vector3 relativePos = point - transform.parent.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, transform.parent.up);
		rotation.y = 0;
        transform.parent.rotation = rotation;*/

		startTime = Time.time;
		currTime = startTime;
		endTime = startTime+moveTime;
	}

	public void MoveOn(){
		readyToMoveOn = true;
	}
	public void addToMoveQueue(Transform transform){
		path.Enqueue(transform);
	}

	public void stop(){
		endPos = transform.parent.position;
		endTime = Time.time;
	}
}
