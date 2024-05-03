using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeathZone : MonoBehaviour, IDropHandler
{

    private RectTransform rectTransform;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("card drpped outside");
            if (eventData.pointerDrag.gameObject.transform.parent != GameObject.FindObjectOfType<CardHandPosition>().transform)
            {
                eventData.pointerDrag.gameObject.transform.SetParent(GameObject.FindObjectOfType<CardHandPosition>().transform);
            }
            eventData.pointerDrag.gameObject.GetComponent<DragCard>().activateCard();
            GameObject.FindObjectOfType<CardHandPosition>().fixPadding();
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
