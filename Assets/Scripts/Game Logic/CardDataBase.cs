using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase 
{
    public static List<Card> cards = new List<Card>();

    // Start is called before the first frame update
    public static void Load()
    {

        cards.Add(new Card("Coin", "BattleCry:", 3, 4, 1, 1, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Resources.Load<Sprite>("coin")));
        cards.Add(new Card("Ring", " (0)", 2, 6, 2, 2, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Resources.Load<Sprite>("ring")));
        cards.Add(new Card("Pouch", "", 3, 2, 3, 3, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AfterSelling }, Resources.Load<Sprite>("coin pouch")));
        cards.Add(new Card("Cauldron", "f", 4, 4, 0, 4, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Resources.Load<Sprite>("cauldron")));
        //cards.Add(new Card());
    }
}
