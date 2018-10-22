using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseSpeech : MonoBehaviour {

	public enum SpeechType{General, CurrentWeather, Altitude, Speed, TimeLeft, CurrentLocationFact, CurrentCity};
	HashSet<SpeechType> recentlyUsed;
	Queue<SpeechType> recentlyUsedQueue;
	PersistantFlightData flightData;
	int set_size = 2;
	float timeBetweenLines = 5f;
	float timer;
	

	void UpdateLocationData(){
		ConsoleApplication1.APIWrapper.initialize();
	}
	// Use this for initialization
	void Start () {
		recentlyUsed = new HashSet<SpeechType>();
		recentlyUsedQueue = new Queue<SpeechType>();
		timer = 0f;
		flightData = GameObject.Find("PersistantDataObject").GetComponent<PersistantFlightData>();
		ConsoleApplication1.APIWrapper.initialize(flightData.airline, flightData.flightNumber, flightData.dept, flightData.arrival);
        //KEEP PERIODICALLY CALLING .INITIALIZE()
		ConsoleApplication1.APIWrapper.initialize();
        InvokeRepeating("UpdateLocationData", 0.0f, 300f);
	}

	string currTemp(){
        string temperature = ConsoleApplication1.APIWrapper.getWeather();
		return temperature;
	}

	List<String> getCity(){
		List<string> cityInfo = ConsoleApplication1.APIWrapper.getCity(); //<Austin, Facts about austin from wikipedia>
		return cityInfo;
	}

	List<String> getLandmark(){
		List<string> landMarkInfo = ConsoleApplication1.APIWrapper.getLandMark(); //<Grand Canyon, Facts about Grand Canyon>*/
		return landMarkInfo;
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

	public List<String> speakFact(){
		int len = Enum.GetNames(typeof(SpeechType)).Length;
		List<String> dialogue = null;
		SpeechType type = (SpeechType)UnityEngine.Random.Range(len-2,len);
		return speak(type);
	}
	List<String> speak(SpeechType type){
		StringBuilder sb = new StringBuilder("");
		List<String> dialogue = new List<String>();
		switch(type){
			case SpeechType.TimeLeft:
				string timeString = "101 minutes ";
				sb.Append("You have ");
				sb.Append(timeString);
				sb.Append("remaining in your flight!");
				dialogue.Add(sb.ToString());
				break;
			case SpeechType.CurrentLocationFact:
				//List<String> landmark = new List<String>({"",""}); 
				string locationString = "Mississippi River";//landmark[0]; 
				sb.Append("We are super close to ");
				sb.Append(locationString);
				dialogue.Add(sb.ToString());
				sb = new StringBuilder("");
				sb.Append("Did you know? ");
				dialogue.Add(sb.ToString());
				sb = new StringBuilder("");
				sb.Append(/* landmark[1]*/ "The Mississippi River is the chief river of the second-largest drainage system on the North American continent, second only to the Hudson Bay drainage system.");
				dialogue.Add(sb.ToString());
				break;
			case SpeechType.CurrentWeather:
				string temp = currTemp();
				sb.Append("The temperature right under us is ");
				dialogue.Add(sb.ToString());
				sb = new StringBuilder("");
				sb.Append(temp);
				sb.Append(" Degrees Kelvin!");
				dialogue.Add(sb.ToString());
				break;
			case SpeechType.CurrentCity:
				List<String> city = getCity(); 
				string cityString = city[0];
				sb.Append("We're right over the great city of ");
				sb.Append(cityString);
				dialogue.Add(sb.ToString());
				sb = new StringBuilder("");
				sb.Append("Did you know? ");
				dialogue.Add(sb.ToString());
				sb = new StringBuilder("");
				sb.Append(city[1]);
				//sb.Append("Memphis is a city on the Mississippi River in southwest Tennessee, famous for the influential strains of blues, soul and rock 'n' roll that originated there.");
				dialogue.Add(sb.ToString());
				break;
			case SpeechType.Altitude:
				sb.Append("Whoa, we're currently flying at ");
				sb.Append("30100 feet!");
				dialogue.Add(sb.ToString());
				break;
			case SpeechType.Speed:
				sb.Append("We're bopping along at ");
				sb.Append("300 miles per hour!");
				dialogue.Add(sb.ToString());
				break;

			/*case SpeechType.DestinationFact:
				 
				string destIntro = "Hey, I saw you're going to";
				string destFact = "Did you know that it was founded on Valentines Day, 1912?";
				sb.Append(destIntro);
				sb.Append(whichDest);
				dialogue.Add(sb.ToString());
				sb = new StringBuilder();
				sb.Append(destFact);
				dialogue.Add(sb.ToString());
				break;*/
			/* case SpeechType.DestinationWeather:
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
				break;*/
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
