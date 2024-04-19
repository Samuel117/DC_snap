using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class DragCard : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        //Debug.Log("start drag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("draging...");
        //Modificamos nuestra posición para añadir la cantidad de movimiento del maouse desde el ultimo frame
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("stop drag");
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("click on card");
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("card drpped");
        if(this.gameObject.transform.parent == GameObject.Find("Hand")) {
            GameObject.FindObjectOfType<CardHandPosition>().resetHandPos();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
