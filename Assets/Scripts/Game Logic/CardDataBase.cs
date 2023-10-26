using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase 
{
    public static List<Card> cards = new List<Card>();
    public static List<List<Card>> deck = new List<List<Card>>();

    // Start is called before the first frame update
    public static void Load()
    { 
        cards.Add(new Card("King of monkey", "when you summon beast during the battle, your creatures getting +3 attack until end of the turn", 4, 4, 3, 99, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AfterSummon },Card.Race.Beast, Resources.Load<Sprite>("beast-kingofmonkey")));//>>>>..?
        cards.Add(new Card("Night Scream", "<b>After Death</b> summon two Turkey 3/3", 4, 4, 3, 22, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AfterHisDeath }, Card.Race.Beast, Resources.Load<Sprite>("Beast-NightScream")));
        cards.Add(new Card("Bear Grizly", "When your creature dying, getting +1 attack forever", 2, 3, 2, 6, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AfterCreatureDeath }, Card.Race.Beast, Resources.Load<Sprite>("Beast-BearGrizly")));
        cards.Add(new Card("Black Panther", "When you summon a beast, your friendly beasts gets +5/+5", 5, 5, 5, 21, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AfterSummon}, Card.Race.Beast, Resources.Load<Sprite>("Beast-BlackPanther")));
        cards.Add(new Card("Forest Warior", "At the end of your turn, will give to other random card +1 attack", 1, 2, 1, 1, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AtTheEndOFTheTimer }, Card.Race.Beast, Resources.Load<Sprite>("Beast-ForestWarrior")));//added
        cards.Add(new Card("Risen from the ashes", "When this creatures dies, reduces health of the creature that killed him to 1", 3, 4, 3, 14, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AfterHisDeath }, Card.Race.Beast, Resources.Load<Sprite>("Beast-Risenfromtheashes")));
        cards.Add(new Card("Sentient Owl", "<b>Battle Cry</b> give +2/+1 to orandom friendly creature", 1, 1, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry}, Card.Race.Beast, Resources.Load<Sprite>("Beast-SentientOwl")));//������ ��������� ��� 1/1 �����
        cards.Add(new Card("Beef Oni", "This cost 3 health instead of gold to buy", 4, 3, 2, 9, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AfterCardBuying }, Card.Race.Demon, Resources.Load<Sprite>("Demon-beefyoni")));
        cards.Add(new Card("Four-armed Baki", "When you buy creature, this creature get his characteristic", 5, 4, 6, 22, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AfterCardBuying }, Card.Race.Demon, Resources.Load<Sprite>("Demon-four-armedBaki")));
        cards.Add(new Card("Messenger of Zeus", "At the end of your turn, will give +5/+5 to random card in your hand", 3, 4, 3,17, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AtTheEndOFTheTimer }, Card.Race.Demon, Resources.Load<Sprite>("Demon-messengerofZeus")));
        cards.Add(new Card("Mountain Myth", "when you buy a demon, this creature get +3/+2", 5, 4, 4, 23, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AfterCardBuying }, Card.Race.Demon, Resources.Load<Sprite>("Demon-MountainMyth")));
        cards.Add(new Card("Owner of sinful souls", "will give to other friendly demons minimal attack and health from shop creatures", 2, 2, 5, 18, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AtTheEndOFTheTimer }, Card.Race.Demon, Resources.Load<Sprite>("Demon-Ownerofsinfulsouls")));
        cards.Add(new Card("Patrones OF the Underworld", "<b>After death will give rebirth to 2 other creatures</b>", 4, 4, 4, 19, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AfterHisDeath }, Card.Race.Demon, Resources.Load<Sprite>("Demon-PatronessoftheUnderworld")));
        cards.Add(new Card("Red Tycoon", "At the end of the turn, get buff to attack & health, equal to half of wasted gold in this turn", 4, 4, 4, 24, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Demon, Resources.Load<Sprite>("Demon-RedTycoon")));//9 demon
        cards.Add(new Card("Guardian of the moon", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Dragon, Resources.Load<Sprite>("Dragon, Guardian of Moon")));
        cards.Add(new Card("Golden Dawn", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Dragon, Resources.Load<Sprite>("dragon- GoldenDawn")));
        cards.Add(new Card("Envi", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Dragon, Resources.Load<Sprite>("Dragon-Envi")));
        cards.Add(new Card("Redder", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Dragon, Resources.Load<Sprite>("Dragon-Redder")));//4 dragon
        cards.Add(new Card("Terror of the Seas", "if you lost last combat your friendly creatures getting +2/+2", 2, 3, 2, 10, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Elemental, Resources.Load<Sprite>("Elem, TerroroftheSeas")));
        cards.Add(new Card("Fire Spirit", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Elemental, Resources.Load<Sprite>("Elem-FireSpirit")));
        cards.Add(new Card("Macro", "After you play Elemental, cost of shop updating become 0", 3, 3, 2, 7, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AfterPlayingCard }, Card.Race.Elemental, Resources.Load<Sprite>("Elem-Macro")));
        cards.Add(new Card("Patron of the waves", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Elemental, Resources.Load<Sprite>("Elem-Patron oftheWaves")));
        cards.Add(new Card("Sand Vortex", "after turn this sells for 1 more Gold", 2, 1, 1, 2, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AtTheEndOFTheTimer}, Card.Race.Elemental, Resources.Load<Sprite>("Elem-SandVortex")));//add f string
        cards.Add(new Card("Smoker", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Elemental, Resources.Load<Sprite>("Elem-Smoker")));//6 elem
        cards.Add(new Card("Eshli", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Mechanism, Resources.Load<Sprite>("Mecha, Eshli")));
        cards.Add(new Card("Old Golem", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Mechanism, Resources.Load<Sprite>("Mechanism, OldGolem")));
        cards.Add(new Card("Electron", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Mechanism, Resources.Load<Sprite>("Mechanism- ElectroBiggy")));
        cards.Add(new Card("Nori", "<b> Rebirth </b>", 1, 3, 1, 0, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.Rebirth }, Card.Race.Mechanism, Resources.Load<Sprite>("Mechanism- Nori")));
        cards.Add(new Card("Frozen", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Mechanism, Resources.Load<Sprite>("Mechanism-Frozen")));
        cards.Add(new Card("Enfernal Warrior", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Mechanism, Resources.Load<Sprite>("Mechanism-InfernalWarrior")));//6 mechja
        cards.Add(new Card("Boster", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Naga, Resources.Load<Sprite>("Naga-Boster")));
        cards.Add(new Card("Cloud Molly", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Naga, Resources.Load<Sprite>("Naga-CloudMolly")));
        cards.Add(new Card("Doppler", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Naga, Resources.Load<Sprite>("Naga-Doppler")));
        cards.Add(new Card("GreenHell", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Naga, Resources.Load<Sprite>("Naga-GreenHell")));
        cards.Add(new Card("Haster", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Naga, Resources.Load<Sprite>("Naga-Haster")));
        cards.Add(new Card("Hydronic", "<b>Spellcraft</b> your creature getting +5/+1 and provocation until next turn", 2, 1, 2, 11, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.SpellCraft }, Card.Race.Naga, Resources.Load<Sprite>("Naga-Hydronic")));
        cards.Add(new Card("Scarly", "<b>Battle cry</b>: Giving 1 Coin", 2, 1, 0, 4, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Naga, Resources.Load<Sprite>("Naga-Scarly")));
        cards.Add(new Card("Sky walker", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Naga, Resources.Load<Sprite>("Naga-SkyWalker")));//8 naga
        cards.Add(new Card("Leader Of Skeletons", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Undead, Resources.Load<Sprite>("Undead, LeaderOfSkeletons")));
        cards.Add(new Card("Spiny", "Giving +1 attack to all creatures in shop, tfor the rest of the game", 2,2,2,12, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Undead, Resources.Load<Sprite>("Undead, Spiny")));
        cards.Add(new Card("Angry Turtle", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Undead, Resources.Load<Sprite>("Undead-AngryTurtle")));
        cards.Add(new Card("Dard Revenger", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Undead, Resources.Load<Sprite>("Undead-DardRevenger")));
        cards.Add(new Card("Guardian of the forest", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Undead, Resources.Load<Sprite>("Undead-GuardianoftheForest")));
        cards.Add(new Card("Three head Baki", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Undead, Resources.Load<Sprite>("Undead-Three-headBaki")));//6 undead
        cards.Add(new Card("Fire Poggies", "Giving +2 attack to all friendly creatures", 2, 2, 2, 8, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.GivingTempBuff }, Card.Race.None, Resources.Load<Sprite>("Usual- FirePoggies")));//1 none
        cards.Add(new Card("Drago", "When thid card get damage, attack increase by 1", 0, 3, 1, 3, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.WhenCardGetDamage}, Card.Race.Dragon, Resources.Load<Sprite>("Drago")));//1 none
        cards.Add(new Card("Rem for Luck", "at the end of your turn, give another one friendly creature +2/+1", 2, 3, 2, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AtTheEndOFTheTimer }, Card.Race.Dragon, Resources.Load<Sprite>("rem")));//1 none
        cards.Add(new Card("Cora", "Your other creatures have extra attack equal to your level of shop", 2, 2, 3, 13, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.GivingTempBuff }, Card.Race.Dragon, Resources.Load<Sprite>("Dragon-Cora")));
        cards.Add(new Card("Mara", "<b>Revenge(4)</b> getting <b>Rebirth</b>", 6, 2, 3, 14, 4, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.Revenge}, Card.Race.Dragon, Resources.Load<Sprite>("Mara")));
        cards.Add(new Card("Kraken", "Giving 0.5 Coins at the start of next turn, repeat for each friendly creature with different race (rounded down)", 4, 4, 3, 15, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AtTheStartOfTheTurn}, Card.Race.None, Resources.Load<Sprite>("Kraken")));
        cards.Add(new Card("Tera", "At the end of the turn, giving +1 health to creatures, that have less health than this", 3, 2, 2, 16, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AtTheEndOFTheTimer }, Card.Race.Dragon, Resources.Load<Sprite>("Dragon-Tera")));
        //Dragon-Cora
        for (int i =0;i< cards.Count; i++)
        {
            
            switch (cards[i].level)
            {
                case 1:
                    deck[1].Add(cards[i]);
                    break;
                case 2:
                    deck[2].Add(cards[i]);
                    break;
                case 3:
                    deck[3].Add(cards[i]);
                    break;
                case 4:
                    deck[4].Add(cards[i]);
                    break;
                case 5:
                    deck[5].Add(cards[i]);
                    break;
                case 6:
                    deck[6].Add(cards[i]);
                    break;
                default:
                    break;

            }
        }
    }
    



}
