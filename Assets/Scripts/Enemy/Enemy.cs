using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy 
{
    public static int health;
    public static int armor;
    public static List<Card> cards = new List<Card>{
            CardDataBase.cards[0],
            CardDataBase.cards[1],
    }; 
    public static int idOfAbility;
    public int minMax(List<GameObject> cardsInShop)
    {
        return 0;
    }
    
}
