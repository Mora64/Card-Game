using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string name;
    public string description;
    public int attack;
    public int health;
    public int idOfAbility;
    public int level;
    CardSpeciallAbility[] cardSpeciallAbilities;
    public Sprite spriteImage;
    public State state;

    public Card(string _name, string _description, int _attack, int _health, int _level, int _IdOfAbility, CardSpeciallAbility[] _cardSpeciallAbilities, Sprite _sprite)
    {
        name = _name;
        description = _description;
        attack = _attack;
        health = _health;
        level = _level;
        idOfAbility = _IdOfAbility;
        cardSpeciallAbilities = _cardSpeciallAbilities;
        spriteImage = _sprite;
    }

    public enum CardSpeciallAbility
    {
        None,
        AfterDeath,
        AtTheStart,
        Provocation,
        Schield
    }
    public enum State
    {
        ShopCard,
        HandCard,
        BattleGroundCard,
        None
    }

}
