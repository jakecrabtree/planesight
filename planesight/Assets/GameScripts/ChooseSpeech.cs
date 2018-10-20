using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSpeech : MonoBehaviour {

	public enum SpeechType{General, CurrentLocationFact, CurrentWeather, TimeLeft, DestinationWeather, DestinationFact};
	HashSet<SpeechType> recentlyUsed;
	Queue<SpeechType> recentlyUsedQueue;
	int set_size = 2;
	float timeBetweenLines = 5f;
	float timer;
	

	// Use this for initialization
	void Start () {
		recentlyUsed = new HashSet<SpeechType>();
		recentlyUsedQueue = new Queue<SpeechType>();
		timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
	}

	SpeechType ChooseSpeechType(){
		int len = Enum.GetNames(typeof(SpeechType)).Length;
		int max_it = 20;
		int it = 0;
		while(it < max_it){
			SpeechType randType = (SpeechType)UnityEngine.Random.Range(0,len);
			if (!recentlyUsed.Contains(randType)){
				if (recentlyUsedQueue.Count > 0 && recentlyUsedQueue.Count <= set_size){
					SpeechType old = recentlyUsedQueue.Dequeue();
					recentlyUsed.Remove(old);
				}
				recentlyUsedQueue.Enqueue(randType);
				recentlyUsed.Add(randType);
				return randType;
			}
			++it;
		}
		return SpeechType.General;
	}

	/// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while
	/// over the GUIElement or Collider.
	/// </summary>
	void OnMouseDown()
	{
		if (timer <= 0){
			speak();
			timer = timeBetweenLines;
		}
	}

	void speak(){
		SpeechType type = ChooseSpeechType();
		speak(type);
	}
	void speak(SpeechType type){
		switch(type){
			case SpeechType.General:
			default:
				Debug.Log("Q: What do you call the movie where pilots fight to take off? A: The Hanger games");
				break;
		}
	}
}
