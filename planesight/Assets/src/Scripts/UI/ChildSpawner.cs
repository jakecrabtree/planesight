using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildSpawner : MonoBehaviour {

    public GameObject buddyObj;
    [SerializeField] private List<GameObject> childrenToSpawn;
    [SerializeField] TrayItem ti;
    float TotalW;
    private RectTransform rt;
    private List<RectTransform> childrenRts;
    private float initW;
    private float initH;

    // Use this for initialization
    void Start () {
        rt = GetComponent<RectTransform>();
        childrenRts = new List<RectTransform>();
        ti.initializeBuddy(buddyObj.GetComponentInChildren<Buddy>());
		foreach(GameObject child in childrenToSpawn)
        {
            TrayItem curr = Instantiate(ti, transform);
            curr.obj = child;
            initW = curr.GetComponent<RectTransform>().rect.width;
            initH = curr.GetComponent<RectTransform>().rect.height;
            TotalW += initW;
            childrenRts.Add(curr.GetComponent<RectTransform>());
        }
        Debug.Log("" + TotalW + "  " + rt.rect.width);
	}

    void Update()
    {
        if (TotalW > rt.rect.width)
        {
            float newW = rt.rect.width / childrenRts.Count;
            foreach (RectTransform crt in childrenRts)
            {
                crt.sizeDelta = new Vector2(newW, initH);
            }
        }
        else
        {
            foreach (RectTransform crt in childrenRts)
            {
                crt.sizeDelta = new Vector2(initW, initH);
            }
        }


    }
}
