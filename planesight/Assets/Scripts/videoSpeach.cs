using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class videoSpeach : MonoBehaviour {

    List<string> videoSpeech1 = new List<string>();
    List<string> videoSpeech2 = new List<string>();
    List<string> videoSpeech3 = new List<string>();
    List<string> videoSpeech4 = new List<string>();
    List<string> videoSpeech5 = new List<string>();
    List<string> videoSpeech6 = new List<string>();
    List<string> videoSpeech7 = new List<string>();
    List<string> videoSpeech8 = new List<string>();
    List<string> videoSpeech9 = new List<string>();

    List<List<string>> test = new List<List<string>>();

    

    public TextBubble bubble;

    int index;
    int count;

    float time = 0;
    float timeTillNextText = 0;


	// Use this for initialization
	void Start () {
        videoSpeech1.Add("Welcome to American Airlines, I'll be your travel buddy for this flight!");
        videoSpeech2.Add("Please listen carefully and pay full attention to these messages.");
        videoSpeech3.Add("Please remember to turn me off during take off. Dont worry, I'll still be here when you get back.");
        videoSpeech4.Add("These messages are very important. They will make sure you won't get hurt.");
        videoSpeech5.Add("Keep in mind, these slides are not toys. They should only be used for emergencies!");
        videoSpeech6.Add("Look around you. Can you spot the exits?");
        videoSpeech7.Add("Ask an adult for help if you need any help!");
        videoSpeech8.Add("Remember, opening a safety vest in the middle of a flight is very dangerous!");
        videoSpeech9.Add("Enjoy your trip! Hang out with me to learn some cool things about your flight!");

        test.Add(videoSpeech1);
        test.Add(videoSpeech2);
        test.Add(videoSpeech3);
        test.Add(videoSpeech4);
        test.Add(videoSpeech5);
        test.Add(videoSpeech6);
        test.Add(videoSpeech7);
        test.Add(videoSpeech8);
        test.Add(videoSpeech9);


        bubble.say(test[index]);
        //bubble.next();
        

        timeTillNextText = 15f;

        index = 0;
        count = 0;

	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;
        if (time > timeTillNextText)
        {
            count++;
            if (count == 2)
            {
                index++;
                print("index:" + index);
                print("count:" + count);
                List<string> temp = test[index];
                bubble.say(temp);
                count = 0;
            }else
                bubble.next();
            timeTillNextText += 15f;
        }

    }
}
