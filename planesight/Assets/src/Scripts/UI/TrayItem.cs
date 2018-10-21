using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TrayItem : MonoBehaviour, IPointerDownHandler
{
    
    [HideInInspector] public GameObject obj;


    
	// Use this for initialization
	void Start () {
        float parH = transform.parent.gameObject.GetComponent<RectTransform>().rect.height;
        GetComponent<RectTransform>().sizeDelta = new Vector2(parH, parH);

    }

    public void OnPointerDown(PointerEventData eventData)
    {   
        
        GameObject newItem = Instantiate(obj, Input.mousePosition, transform.rotation, transform.root.parent);
        
        newItem.AddComponent<SpawnedTrayItem>();
        newItem.transform.SetParent(transform.root);
    }
}
