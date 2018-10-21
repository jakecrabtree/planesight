using System;
using System.Text;
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

	public List<String> speak(){
		List<String> dialogue = null;
		if (timer <= 0){
			SpeechType type = ChooseSpeechType();
			dialogue = speak(type);
			timer = timeBetweenLines;
		}
		return dialogue;
	}
	List<String> speak(SpeechType type){
		StringBuilder sb = new StringBuilder("");
		List<String> dialogue = new List<String>();
		string whichDest = "Phoenix, Arizona";
		switch(type){
			case SpeechType.TimeLeft:
				string timeString = "5 minutes ";
				sb.Append("You have ");
				sb.Append(timeString);
				sb.Append("remaining in your flight!");
				dialogue.Add(sb.ToString());
				break;
			case SpeechType.CurrentLocationFact:
				string locationString = "The Grand Canyon";
				sb.Append("You are right over ");
				sb.Append(locationString);
				dialogue.Add(sb.ToString());
				break;
			case SpeechType.CurrentWeather:
				string weatherString = "Sunny, 75 Degrees";
				sb.Append("The weather right under us is ");
				dialogue.Add(sb.ToString());
				sb = new StringBuilder();
				sb.Append(weatherString);
				dialogue.Add(sb.ToString());
				break;
			case SpeechType.DestinationFact:
				string destIntro = "Hey, I saw you're going to";
				string destFact = "Did you know that it was founded on Valentines Day, 1912?";
				sb.Append(destIntro);
				sb.Append(whichDest);
				dialogue.Add(sb.ToString());
				sb = new StringBuilder();
				sb.Append(destFact);
				dialogue.Add(sb.ToString());
				break;
			case SpeechType.DestinationWeather:
				string destIntro2 = "You're headed for " + whichDest+ " right?";
				string destWeatherIntro = "The weather there is ";
				string destWeather = "Rainy, 60 degrees";
				sb.Append(destIntro2);
				dialogue.Add(sb.ToString());
				sb = new StringBuilder();
				sb.Append(destWeatherIntro);
				dialogue.Add(sb.ToString());
				sb = new StringBuilder();
				sb.Append(destWeather);
				dialogue.Add(sb.ToString());
				break;
			case SpeechType.General:
			default:
				sb.Append("What do you call the movie where pilots fight to take off?");
				dialogue.Add(sb.ToString());
				sb = new StringBuilder();
				sb.Append("The Hanger games");
				dialogue.Add(sb.ToString());
				break;
		}
		return dialogue;
	}
}
