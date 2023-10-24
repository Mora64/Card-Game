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
                RandomCard1.GetComponent<CardState>().card.attack += 2;
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
            case 8:
                for(int i = 0; i < GameProcess.BattleGroundCards.Count; i++)
                {
                    GameProcess.BattleGroundCards[i].GetComponent<CardState>().card.attack += 2;
                    GameProcess.UpdateCard(GameProcess.BattleGroundCards[i], GameProcess.BattleGroundCards[i].GetComponent<CardState>().card, true);
                }
                break;
            case 9:
                Character.money += 3;
                Character.health -= 3;
                break;
            case 10:
                if (Character.lostLastCombat)

                    for (int i = 0; i < GameProcess.BattleGroundCards.Count; i++)
                    {
                        GameProcess.BattleGroundCards[i].GetComponent<CardState>().card.attack += 2;
                        GameProcess.BattleGroundCards[i].GetComponent<CardState>().card.health += 2;
                        GameProcess.UpdateCard(GameProcess.BattleGroundCards[i], GameProcess.BattleGroundCards[i].GetComponent<CardState>().card, true);
                    }
                break;
            case 11:
                ///Insstantiate spellcaft +5 +1 provocation in hand;
                break;
            case 12:
                CardBuffs.AttackBuffToAllCreatures++;
                CardBuffs.HealthBuffToAllCreatures++; // add buffs in shop
                break;
            case 13:
                for (int i = 0; i < GameProcess.BattleGroundCards.Count; i++)
                {
                    GameProcess.BattleGroundCards[i].GetComponent<CardState>().card.attack += Character.level;
                    GameProcess.UpdateCard(GameProcess.BattleGroundCards[i], GameProcess.BattleGroundCards[i].GetComponent<CardState>().card, true);
                }
                break;
            case 15:
                List<Card.Race> list = new List<Card.Race>();
                int counter = 0;
                for (int i = 0; i < GameProcess.BattleGroundCards.Count; i++)
                {
                    if (!list.Contains(GameProcess.BattleGroundCards[i].GetComponent<CardState>().card.race)){
                        list.Add(GameProcess.BattleGroundCards[i].GetComponent<CardState>().card.race);
                        counter++;
                    }
                }
                Character.money = counter;
                
                break;
            case 16:
                for (int i = 0; i < GameProcess.BattleGroundCards.Count; i++)
                {
                    if (GameProcess.BattleGroundCards[i].GetComponent<CardState>().card.health < obj.GetComponent<CardState>().card.health)
                    {
                        GameProcess.BattleGroundCards[i].GetComponent<CardState>().card.health++;
                        GameProcess.UpdateCard(GameProcess.BattleGroundCards[i], GameProcess.BattleGroundCards[i].GetComponent<CardState>().card, true);
                    }
                }
                break;
            case 17:
                int index = (int)(Random.Range(0, GameProcess.HandCards.Count-0.01f));
                GameProcess.HandCards[index].GetComponent<CardState>().card.attack += 5;
                GameProcess.HandCards[index].GetComponent<CardState>().card.health += 5;
                GameProcess.UpdateCard(GameProcess.HandCards[index], GameProcess.HandCards[index].GetComponent<CardState>().card, true);
                break;

            case 18:
                int minA=1000;
                int minH=1000;
                for(int i = 0;i < GameProcess.ShopCards.Count; i++)
                {
                    if (GameProcess.ShopCards[i].GetComponent<CardState>().card.attack < minA) minA = GameProcess.ShopCards[i].GetComponent<CardState>().card.attack;
                    if (GameProcess.ShopCards[i].GetComponent<CardState>().card.health < minH) minA = GameProcess.ShopCards[i].GetComponent<CardState>().card.health;
                }
                for(int i = 0; i < GameProcess.BattleGroundCards.Count; i++)
                {
                    GameProcess.BattleGroundCards[i].GetComponent<CardState>().card.attack += minA;
                    GameProcess.BattleGroundCards[i].GetComponent<CardState>().card.health += minH;
                    GameProcess.UpdateCard(GameProcess.BattleGroundCards[i], GameProcess.BattleGroundCards[i].GetComponent<CardState>().card, true);
                }
                break;
            

        }
                
    }
    public static void AfterDeath(GameObject target, GameObject killer,int  id, List<GameObject> attakers, List<GameObject> defenders)
    {
        switch (id)
        {
            case 14:
                killer.GetComponent<CardState>().card.health = 1;
                GameProcess.UpdateCard(killer, killer.GetComponent<CardState>().card, false);
                break;
            case 19:
                for (int i = 0; i < 2; i++)
                {
                    while (true)
                    {
                        int counter = 0;
                        if (counter == defenders.Count) break;
                        int r = (int)Random.Range(0, defenders.Count - 0.01f);
                        if (defenders[i].GetComponent<CardState>().card.cardSpeciallAbilities.Contains(Card.CardSpeciallAbility.Rebirth)) counter++;
                        else { defenders[i].GetComponent<CardState>().card.cardSpeciallAbilities.Add(Card.CardSpeciallAbility.Rebirth); break; }
                    }
                }
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
    public static void CardDebuffAbility(GameObject playedCArd, int id)
    {
        switch(id){
            case 8:
                for (int i = 0; i < GameProcess.BattleGroundCards.Count; i++)
                {
                    GameProcess.BattleGroundCards[i].GetComponent<CardState>().card.attack -= 2;
                    GameProcess.UpdateCard(GameProcess.BattleGroundCards[i], GameProcess.BattleGroundCards[i].GetComponent<CardState>().card, true);
                }
                break;
            case 13:
                for (int i = 0; i < GameProcess.BattleGroundCards.Count; i++)
                {
                    GameProcess.BattleGroundCards[i].GetComponent<CardState>().card.attack -= Character.level;
                    GameProcess.UpdateCard(GameProcess.BattleGroundCards[i], GameProcess.BattleGroundCards[i].GetComponent<CardState>().card, true);
                }
                break;
        }
    }


}
