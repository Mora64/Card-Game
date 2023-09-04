using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    public static List<Card> cardsInShop;
    private void Start()
    {
        cardsInShop = new List<Card>();
        UpdateShop();
    }

    // Update is called once per frame
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
