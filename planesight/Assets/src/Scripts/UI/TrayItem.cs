using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrayItem : MonoBehaviour, IPointerDownHandler
{
    
    public Buddy buddy;
    [HideInInspector] public GameObject obj;


    
	// Use this for initialization
	void Start () {
        float parH = transform.parent.gameObject.GetComponent<RectTransform>().rect.height;
        GetComponent<RectTransform>().sizeDelta = new Vector2(parH, parH);

    }

    public void initializeBuddy(Buddy bud){
        buddy = bud;
    }
    public void OnPointerDown(PointerEventData eventData)
    {   
        
        GameObject newItem = Instantiate(obj, Input.mousePosition, transform.rotation, transform.root);
        
        newItem.AddComponent<SpawnedTrayItem>();
        newItem.GetComponent<SpawnedTrayItem>().initializeBuddy(buddy);
        newItem.transform.SetParent(transform.root);
        
    }
}
