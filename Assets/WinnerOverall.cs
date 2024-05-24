using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerOverall : MonoBehaviour
{
    [SerializeField] ZoneBehaviour z1;
    [SerializeField] ZoneBehaviour z2;
    [SerializeField] ZoneBehaviour z3;
    bool playerWin;
    ZoneBehaviour zb1;
    ZoneBehaviour zb2;
    ZoneBehaviour zb3;


    void Start()
    {
        zb1 = z1.gameObject.GetComponent<ZoneBehaviour>();
        zb2 = z2.gameObject.GetComponent<ZoneBehaviour>();
        zb3 = z3.gameObject.GetComponent<ZoneBehaviour>();
        playerWin = Random.value > 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Winner()
    {
        
        int playerZoneWin = 0;
        int EnemyZoneWin = 0;
        //zona1
        if (zb1.getPlayerPower() > zb1.getEnemyPower())
        {
            playerZoneWin += 1;
        }else if (zb1.getPlayerPower() < zb1.getEnemyPower())
        {
            EnemyZoneWin += 1;
        }
        //zona2
        if (zb2.getPlayerPower() > zb2.getEnemyPower())
        {
            playerZoneWin += 1;
        }
        else if (zb2.getPlayerPower() < zb2.getEnemyPower())
        {
            EnemyZoneWin += 1;
        }
        //zona3
        if (zb3.getPlayerPower() > zb3.getEnemyPower())
        {
            playerZoneWin += 1;
        }
        else if (zb3.getPlayerPower() < zb3.getEnemyPower())
        {
            EnemyZoneWin += 1;
        }

        if(playerZoneWin > EnemyZoneWin)
        {
            playerWin = true;
        }else if(playerZoneWin < EnemyZoneWin)
        {
            playerWin = false;
        }
        


        return playerWin;
    } 
}
