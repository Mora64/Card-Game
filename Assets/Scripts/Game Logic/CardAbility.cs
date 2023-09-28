using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAbility : MonoBehaviour
{
    // Start is called before the first frame update
    public static void UseCardAbility(int id, GameObject obj)
    {
        switch (id)
        {
            case 0:
                break;
            case 1:
                for(int i = 0; i < GameProcess.BattleGroundCards.Count; i++)
                {
                    CardState state = GameProcess.BattleGroundCards[i].GetComponent<CardState>();
                    Card card = state.card;
                    card.attack++;
                    card.health++;
                    GameProcess.UpdateCard(GameProcess.BattleGroundCards[i], card);
                }
                break;
            case 2:
                Character.updateShopCost = 0;
                Character.amountOfSpeciallUpdateShopCost = 1;
                break;
            case 3:
                obj.GetComponent<CardState>().card.costOfSelling = 3;
                break;
            case 4:
                
                int index = (int)Random.Range(0, GameProcess.BattleGroundCards.Count - 0.01f);
                GameProcess.BattleGroundCards[index].GetComponent<CardState>().card.attack+=5;
                GameProcess.UpdateCard(GameProcess.BattleGroundCards[index], GameProcess.BattleGroundCards[index].GetComponent<CardState>().card);

                break;

        }
    }

    
}
