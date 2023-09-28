using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop
{

    public static List<Card> cardsInShop;


    public static void UpdateShop()
    {
        cardsInShop.Clear();
       
        for (int i = 0; i < GameProcess.amountOfCardInShop; i++)
        {
            Card randomCard = CardDataBase.cards[(int)Random.Range(0, CardDataBase.cards.Count - 0.01f)];
            cardsInShop.Add(randomCard);
        }
        
        GameProcess.currentCardsInShop = cardsInShop;
    }
}
