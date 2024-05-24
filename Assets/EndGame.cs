using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    [SerializeField] WinnerOverall Wo;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void end()
    {
        //agregar logica para hacer que no puedas jugar cartas de la mano

        if (Wo.Winner())
        {
            Debug.Log("Player wins");
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.Log("Enemy wins");
            SceneManager.LoadScene("MainMenu");
        }


    }
}
