using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video; 

public class changeScene : MonoBehaviour {


    public VideoPlayer video;
    private float time;

    //Time: 4:20 Blaze it
    private float elapseTime = 260f;

    // Use this for initialization
	void Start () {
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;
        if(video.isPlaying && time > elapseTime)
            SceneManager.LoadScene(sceneName: "BasicARScene");
    }
}
