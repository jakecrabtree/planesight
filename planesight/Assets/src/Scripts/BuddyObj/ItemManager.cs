using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    [SerializeField] List<string> keys;
    [SerializeField] List<GameObject> values;

    Dictionary<string, GameObject> mapping;

	// Use this for initialization
	void Start () {
        mapping = new Dictionary<string,GameObject>();
		for (int i=0; i < keys.Count; i++)
        {
            mapping.Add(keys[i], values[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void toggleActive(string key)
    {
        GameObject obj = mapping[key];
        obj.SetActive(true);
    }
}
