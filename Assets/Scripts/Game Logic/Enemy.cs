using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public static List<Card> Cards = new List<Card>{
            CardDataBase.cards[0],
            CardDataBase.cards[1],

    };
    public static int health;
    public int armor;

}
