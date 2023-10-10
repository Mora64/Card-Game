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
    public int costOfSelling = 1;
    public List<CardSpeciallAbility> cardSpeciallAbilities;
    public Sprite spriteImage;
    public List<Race> race;
    public Card(string _name, string _description, int _attack, int _health, int _level, int _IdOfAbility, List<CardSpeciallAbility> _cardSpeciallAbilities,List<Race> _races,Sprite _sprite)
    {
        name = _name;
        description = _description;
        attack = _attack;
        health = _health;
        level = _level;
        idOfAbility = _IdOfAbility;
        cardSpeciallAbilities = _cardSpeciallAbilities;
        spriteImage = _sprite;
        race = _races;
    }
    public Card(Card card)
    {
        this.name = card.name;
        this.description = card.description;    
        this.attack = card.attack;
        health = card.health;
        level = card.level;
        idOfAbility = card.idOfAbility;
        spriteImage = card.spriteImage;
        cardSpeciallAbilities = card.cardSpeciallAbilities;
        race = card.race;
    }
    public Card()
    {
        name = null;
        description = null;
        attack = 0;
        health = 0;
        level = 0;
        idOfAbility= 0;
        spriteImage = null;
        cardSpeciallAbilities = null;
        

    }
    public enum CardSpeciallAbility
    {
        None,
        AfterDeath,
        AtTheStart,
        Provocation,
        Schield,
        BattleCry,
        AfterSelling
    }
    public enum Race
    {
        All,
        Demon,
        Undead,
        Beast,
        Mechanism,
        Murlock,
        Dragon,
        Elemental,
        Naga,
    }
    

}
