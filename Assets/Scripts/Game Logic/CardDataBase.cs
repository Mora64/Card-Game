using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase 
{
    public static List<Card> cards = new List<Card>();

    // Start is called before the first frame update
    public static void Load()
    {

        cards.Add(new Card("Coin", "it is Coin", 3, 4, 1, 1, new Card.CardSpeciallAbility[] { Card.CardSpeciallAbility.None }, Resources.Load<Sprite>("coin")));
        cards.Add(new Card("Ring", "it is Ring", 2, 6, 2, 1, new Card.CardSpeciallAbility[] { Card.CardSpeciallAbility.None }, Resources.Load<Sprite>("ring")));
        cards.Add(new Card("Pouch", "it is Pouch", 3, 2, 3, 1, new Card.CardSpeciallAbility[] { Card.CardSpeciallAbility.None }, Resources.Load<Sprite>("coin pouch")));
        cards.Add(new Card("Cauldron", "it is Cauldron", 4, 4, 0, 1, new Card.CardSpeciallAbility[] { Card.CardSpeciallAbility.None }, Resources.Load<Sprite>("cauldron")));
    }
}
