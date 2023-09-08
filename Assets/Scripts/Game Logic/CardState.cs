using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardState : MonoBehaviour
{
   public State state;
    public bool moveable = true;
   public enum State{
        ShopCard,
        HandCard,
        BattleGroundCard,
   }
}
