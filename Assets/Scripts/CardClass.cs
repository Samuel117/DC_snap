using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CardClass : MonoBehaviour
{
    public class Card
    {
        public int ID;
        public int energy;
        public int power;
        public string name;

        public Card(int id, int x, int y, string s)
        {
            ID = id;
            energy = x;
            power = y;
            name = s;
        }
        void ModifyPower(int x, int sign)
        {
            power += x * sign;
        }
        void ModifyCost(int x, int sign)
        {
            energy += x * sign;
        }


    }
}
