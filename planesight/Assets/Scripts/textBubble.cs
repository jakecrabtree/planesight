using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class textBubble : MonoBehaviour {

    public GameObject textBox;
    private Renderer rend;

    public Text currentText = null;

    private List<List<string>> output = new List<List<string>>();

    private List<string> jokes = new List<string>();
    private List<string> weather = new List<string>();
    private List<string> eta = new List<string>();
    private List<string> facts = new List<string>();

    int twoArrayindex = 0;
    int arrayIndex = 0;

    bool showBox = false;
    bool displayText = false;

    List<string> currentArray = null;

    StringBuilder text = new StringBuilder();
    
    // Use this for initialization
	void Start () {

        textBox = GameObject.FindGameObjectWithTag("panel");
        textBox.SetActive(false);

        addJokes(jokes);
        addWeather(weather);
        addFacts(facts);
        addETA(eta);


        output.Add(jokes);
        output.Add(facts);
        output.Add(weather);
        output.Add(eta);

        currentText.text = "";
        
        
    }
	
	// Update is called once per frame
	void Update () {

        currentArray = output[twoArrayindex];

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
        }

        
   	}

    private void addWeather(List<string> weather)
    {
        weather.Add("This is the weather");
    }

    private void addFacts(List<string> facts)
    {
        facts.Add("These are the facts");
    }

    private void addJokes(List<string> jokes)
    {
        jokes.Add("This is joke 1");
        jokes.Add("This is joke 2");
        jokes.Add("This is joke 3");
    }

    private void addETA(List<string> eta)
    {
        eta.Add("This is the eta");
    }

}
