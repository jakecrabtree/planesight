using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveDragon : MonoBehaviour {

    public GameObject[] movePositions;
    GameObject currentPos;
    GameObject cameraMain;
    int posIndex = 0;

    Vector3 moveDistanceBetween;
    public float speed;
    float time = 0;
    float nextTime = 1f;
    public float timeBetween;

    bool canMove = true;
    float timeBetweenNextMove = 0;
    float timeToWait = 30f;




    // Use this for initialization
    void Start () {

        cameraMain = GameObject.FindGameObjectWithTag("MainCamera");
        //getNextPos();
        //transform.position = currentPos.transform.position;
        transform.LookAt(cameraMain.transform.position);

    }
	
	// Update is called once per frame
	void Update () {

        transform.LookAt(cameraMain.transform.position);

        /*time += Time.deltaTime;

		if(transform.position != currentPos.transform.position && time > nextTime && canMove)
        {
            transform.position += (moveDistanceBetween/speed);
            nextTime += timeBetween;
        }
        
        if(distanceMet())
        {
            
            if(posIndex == movePositions.Length)
            {
                posIndex = 0;
            }
            transform.LookAt(camera.transform.position);

            if (canMove)
            {
                timeBetweenNextMove = time + timeToWait;
                canMove = false;
            }
            
            
        }

        if (!canMove && timeBetweenNextMove < time)
        {
            
            canMove = true;
            posIndex++;
            getNextPos();
            transform.LookAt(currentPos.transform.position);

            
        }*/
    }

    private void getNextPos()
    {
        currentPos = movePositions[posIndex];
        moveDistanceBetween = currentPos.transform.position - this.transform.position;
    }

    private bool distanceMet()
    {
        if(Mathf.Abs(transform.position.x - currentPos.transform.position.x) > 0.1)
        {
            return false;
        }

        if(Mathf.Abs(transform.position.y - currentPos.transform.position.y) > 0.1)
        {
            return false;
        }

        if(Mathf.Abs(transform.position.z - currentPos.transform.position.z) > 0.1)
        {
            return false;
        }

        return true;
    }
}
