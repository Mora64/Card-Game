using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState : MonoBehaviour
{
    [SerializeField] public State state;
    [SerializeField] public bool moveable = true;
    [SerializeField] public bool scalable = false;
    [SerializeField] public bool isShopCard = false;
    [SerializeField] public Card card;
    
    public enum State{
        ShopCard,
        HandCard,
        BattleGroundCard,
        EnemyCard,
        CharacterCard,
        None,
    }
  
}
