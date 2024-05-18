using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZoneBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    public int power;
    public int enemyPower;
    [SerializeField]TextMeshProUGUI enemy;
    [SerializeField]TextMeshProUGUI good;
    [SerializeField] GameObject playerZone;
    [SerializeField] GameObject enemyZone;
    void Start()
    {
        power = 0;
        enemyPower = 0;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.text = getEnemyPower().ToString();
        good.text = getPlayerPower().ToString();
    }

    int getEnemyPower()
    {
        GameObject[] cards = new GameObject[enemyZone.gameObject.transform.childCount];

        for (int i = 0; i < enemyZone.transform.childCount; i++)
        {
            cards[i] = enemyZone.transform.GetChild(i).gameObject;
        }

        int acum = 0;
        for (int i = 0; i < cards.Length; i++)
        {
            acum += cards[i].GetComponent<CardClass>().power;
        }
        return acum;
    }
    int getPlayerPower()
    {
        GameObject[] cards = new GameObject[playerZone.gameObject.transform.childCount];

        for (int i = 0; i < playerZone.transform.childCount; i++)
        {
            cards[i] = playerZone.transform.GetChild(i).gameObject;
        }

        int acum = 0;
        for (int i = 0; i < cards.Length; i++)
        {
            acum += cards[i].GetComponent<CardClass>().power;
        }
        return acum;
    }
}
