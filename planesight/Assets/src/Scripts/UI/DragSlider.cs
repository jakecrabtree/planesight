using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class DragSlider : MonoBehaviour, IDragHandler, IEndDragHandler {

    private float startWidth;
    private float endWidth;
    bool release;
    Transform parentTrans;
    RectTransform parentRect;

	// Use this for initialization
	void Start () {
        parentTrans = transform.parent;
        parentRect = parentTrans.gameObject.GetComponent<RectTransform>();
        startWidth = parentRect.rect.width;
        release = true;

        //calculate endpoint
        endWidth = Screen.width - GetComponent<RectTransform>().rect.width;
    }
	
	// Update is called once per frame
	
    public void OnDrag(PointerEventData enventData)
    {
        Debug.Log("Draging");
        parentRect.sizeDelta = new Vector2(Input.mousePosition.x, parentRect.rect.height);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        float currentW = parentRect.rect.width;
        float resultW = (currentW - startWidth > endWidth - currentW) ? endWidth : startWidth;

        parentRect.sizeDelta = new Vector2(resultW, parentRect.rect.height);
    }
}
