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
        cards.Add(new Card("King of monkey", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry },Card.Race.Beast, Resources.Load<Sprite>("beast-kingofmonkey")));
        cards.Add(new Card("Night Scream", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Beast, Resources.Load<Sprite>("Beast-NightScream")));
        cards.Add(new Card("Bear Grizly", "When your creature dying, getting +1 attack forever", 2, 3, 2, 6, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AfterCreatureDeath }, Card.Race.Beast, Resources.Load<Sprite>("Beast-BearGrizly")));
        cards.Add(new Card("Black Panther", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Beast, Resources.Load<Sprite>("Beast-BlackPanther")));
        cards.Add(new Card("Forest Warior", "-", 1, 2, 1, 1, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Beast, Resources.Load<Sprite>("Beast-ForestWarrior")));//added
        cards.Add(new Card("Hybrid", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Beast, Resources.Load<Sprite>("Beast-hybrid")));
        cards.Add(new Card("Risen from the ashes", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Beast, Resources.Load<Sprite>("Beast-Risenfromtheashes")));
        cards.Add(new Card("Sentient Owl", "-", 1, 1, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.Rebirth}, Card.Race.Beast, Resources.Load<Sprite>("Beast-SentientOwl")));//������ ��������� ��� 1/1 �����
        cards.Add(new Card("Akriel", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Demon, Resources.Load<Sprite>("Demon-Akriel")));
        cards.Add(new Card("Leader of demon Island", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Demon, Resources.Load<Sprite>("Demon-CapitanOfDemonicIsland")));
        cards.Add(new Card("Beef Oni", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Demon, Resources.Load<Sprite>("Demon-beefyoni")));
        cards.Add(new Card("Four-armed Baki", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Demon, Resources.Load<Sprite>("Demon-four-armedBaki")));
        cards.Add(new Card("Messenger of Zeus", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Demon, Resources.Load<Sprite>("Demon-messengerofZeus")));
        cards.Add(new Card("Mountain Myth", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Demon, Resources.Load<Sprite>("Demon-MountainMyth")));
        cards.Add(new Card("Owner of sinful souls", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Demon, Resources.Load<Sprite>("Demon-Ownerofsinfulsouls")));
        cards.Add(new Card("Patrones OF the Underworld", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Demon, Resources.Load<Sprite>("Demon-PatronessoftheUnderworld")));
        cards.Add(new Card("Red Tycoon", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Demon, Resources.Load<Sprite>("Demon-RedTycoon")));//9 demon
        cards.Add(new Card("Guardian of the moon", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Dragon, Resources.Load<Sprite>("Dragon, Guardian of Moon")));
        cards.Add(new Card("Golden Dawn", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Dragon, Resources.Load<Sprite>("dragon- GoldenDawn")));
        cards.Add(new Card("Envi", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Dragon, Resources.Load<Sprite>("Dragon-Envi")));
        cards.Add(new Card("Redder", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Dragon, Resources.Load<Sprite>("Dragon-Redder")));//4 dragon
        cards.Add(new Card("Terror of the Seas", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Elemental, Resources.Load<Sprite>("Elem, TerroroftheSeas")));
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
        cards.Add(new Card("Hydronic", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Naga, Resources.Load<Sprite>("Naga-Hydronic")));
        cards.Add(new Card("Scarly", "<b>Battle cry</b>: Giving 1 Coin", 2, 1, 0, 4, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Naga, Resources.Load<Sprite>("Naga-Scarly")));
        cards.Add(new Card("Sky walker", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Naga, Resources.Load<Sprite>("Naga-SkyWalker")));//8 naga
        cards.Add(new Card("Leader Of Skeletons", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Undead, Resources.Load<Sprite>("Undead, LeaderOfSkeletons")));
        cards.Add(new Card("Spiny", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Undead, Resources.Load<Sprite>("Undead, Spiny")));
        cards.Add(new Card("Angry Turtle", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Undead, Resources.Load<Sprite>("Undead-AngryTurtle")));
        cards.Add(new Card("Dard Revenger", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Undead, Resources.Load<Sprite>("Undead-DardRevenger")));
        cards.Add(new Card("Guardian of the forest", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Undead, Resources.Load<Sprite>("Undead-GuardianoftheForest")));
        cards.Add(new Card("Three head Baki", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.Undead, Resources.Load<Sprite>("Undead-Three-headBaki")));//6 undead
        cards.Add(new Card("Fire Poggies", "-", 4, 4, 0, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.BattleCry }, Card.Race.None, Resources.Load<Sprite>("Usual- FirePoggies")));//1 none
        cards.Add(new Card("Drago", "When thid card get damage, attack increase by 1", 0, 3, 1, 3, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.WhenCardGetDamage}, Card.Race.Dragon, Resources.Load<Sprite>("Drago")));//1 none
        cards.Add(new Card("Rem for Luck", "at the end of your turn, give another one friendly creature +2/+1", 2, 3, 2, 5, new List<Card.CardSpeciallAbility> { Card.CardSpeciallAbility.AtTheEndOFTheTimer }, Card.Race.Dragon, Resources.Load<Sprite>("rem")));//1 none

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
