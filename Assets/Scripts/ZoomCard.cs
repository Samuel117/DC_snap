using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCard : MonoBehaviour
{
    private bool canZoom = false;
    //[SerializeField] GameObject ZoomCardObject;
    Vector3 ZoomCardPos;
    // Start is called before the first frame update
    void Start()
    {
       // ZoomCardPos = ZoomCardObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log("Zoom on this card");
        //}
    }

    public void overCard()
    {
        canZoom = true;

        Debug.Log("Over card");
    }

    public void clickOnCard()
    {
        Debug.Log("Card clicked");
    }

    public void exitOverCard()
    {
        canZoom = false;
        FindAnyObjectByType<CardHandPosition>().resetHandPos();
    }
}
