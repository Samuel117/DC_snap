using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameZone : MonoBehaviour, IDropHandler
{
    private RectTransform rectTransform;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null && this.transform.childCount < 4)
        {
            eventData.pointerDrag.gameObject.transform.SetParent(rectTransform);
            LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
