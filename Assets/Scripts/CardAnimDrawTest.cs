using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimDrawTest : MonoBehaviour
{
    private bool canDraw = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activate()
    {
        this.gameObject.SetActive(true); 
        canDraw= false;
    }

    public void deactivate()
    {
        this.gameObject.SetActive(false);
        canDraw= true;
    }

    public bool getCanDraw()
    {
        return canDraw;
    }
}
