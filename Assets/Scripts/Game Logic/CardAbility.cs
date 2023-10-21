using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAbility : MonoBehaviour
{
    // Start is called before the first frame update
    public static void UseCardAbility(int id, GameObject obj)
    {
        Card card = obj.GetComponent<CardState>().card;
        switch (id)
        {
            case 0:
                break;
            case 1:
                GameObject RandomCard = GameProcess.BattleGroundCards[(int)Random.Range(0f, GameProcess.BattleGroundCards.Count - 0.01f)];
                RandomCard.GetComponent<CardState>().card.attack++;
                GameProcess.UpdateCard(RandomCard, RandomCard.GetComponent<CardState>().card, true);

                break;
            case 2:
                card.costOfSelling++;
                break;
            case 3:
                card.attack++;
                GameProcess.UpdateCard(obj, card, true);
                break;
            case 4:
                //instantiate card coin in hand

                break;
            case 5:
                GameObject RandomCard1 = GameProcess.BattleGroundCards[(int)Random.Range(0f, GameProcess.BattleGroundCards.Count - 0.01f)];
                RandomCard1.GetComponent<CardState>().card.attack+=2;
                RandomCard1.GetComponent<CardState>().card.attack++;
                GameProcess.UpdateCard(RandomCard1, RandomCard1.GetComponent<CardState>().card, true);
                break;
            case 6:
                card.attack++;
                GameProcess.UpdateCard(obj, card, true);
                break;
            case 7:
                Character.amountOfSpeciallUpdateShopCost = 1;
                Character.updateShopCost = 0;
                break;

        }
    }
    public static void AfterPlayCardAbility(GameObject playedCard, GameObject source, int id)
    {
        switch (id)
        {
            case 7:
                if (playedCard.GetComponent<CardState>().card.race == Card.Race.Elemental)
                {
                    Character.amountOfSpeciallUpdateShopCost++;
                    Character.updateShopCost = 0;
                }
                break;
        }
    }
    
}
