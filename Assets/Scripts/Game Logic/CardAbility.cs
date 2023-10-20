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
                GameObject card = GameProcess.HandCards[(int)Random.Range(0f, GameProcess.HandCards.Count - 0.01f)];
                card.GetComponent<CardState>().card.attack++;
                GameProcess.UpdateCard(card, card.GetComponent<CardState>().card, true);

                break;
            case 2:
                obj.GetComponent<CardState>().card.costOfSelling++;
                break;
            case 3:
                obj.GetComponent<CardState>().card.costOfSelling = 3;
                break;
            case 4:
                int index = (int)Random.Range(0, GameProcess.BattleGroundCards.Count - 0.01f);
                GameProcess.BattleGroundCards[index].GetComponent<CardState>().card.attack+=5;
                GameProcess.UpdateCard(GameProcess.BattleGroundCards[index], GameProcess.BattleGroundCards[index].GetComponent<CardState>().card, true);

                break;

        }
    }

    
}
