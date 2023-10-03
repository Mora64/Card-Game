using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Battle : MonoBehaviour
{
    private List<Vector2> places;
    public GameObject _cardPrefabCopy;
    List<GameObject> CharacterBattleCards;
    List<GameObject> EnemyBattleCards;
    
    int whoAttacking;
    int RandomEnemyCard;
    int RandomCharacterCard;
    int CurrentCharacterCard = 0;
    int CurrentEnemyCard = 0;
    bool goToShopScene = false;
    Vector3 startCardPos;
    void Start()
    {
        
        EnemyBattleCards = new List<GameObject>();
        CharacterBattleCards = new List<GameObject>();
        GenerateCardsInBattle();
        whoAttacking = (int)Random.Range(0f, 1.999f);

        
    }
    private void Update()
    {
        if (goToShopScene)
        {
            SceneManager.LoadScene("Shop");
        }
    }
    private void GenerateCardsInBattle()
    {
       
        places = GameProcess.GetNewCardPlaces('s', Enemy.Cards.Count);
        for (int i = 0; i < Enemy.Cards.Count; i++)
        {
            Card currentCard = Enemy.Cards[i];
            GameObject BattleCard = ReadCard1(currentCard);
            EnemyBattleCards.Add(Instantiate(BattleCard, places[i], BattleCard.transform.rotation));
            CardState state = EnemyBattleCards[i].GetComponent<CardState>();
            state.state = CardState.State.EnemyCard;
            state.card = new Card(currentCard);
            state.moveable = false;
        }

        places = GameProcess.GetNewCardPlaces('h', GameProcess.BattleGroundCards.Count);
        for (int i = 0; i < GameProcess.BattleGroundCards.Count; i++)
        {
            GameProcess.BattleGroundCards[i].SetActive(true);
            CharacterBattleCards.Add(Instantiate(GameProcess.BattleGroundCards[i], places[i], GameProcess.BattleGroundCards[i].transform.rotation));
            GameProcess.BattleGroundCards[i].SetActive(false);
            CardState state = CharacterBattleCards[i].GetComponent<CardState>();
            state.state = CardState.State.CharacterCard;
            state.card = GameProcess.BattleGroundCards[i].GetComponent<CardState>().card;
            state.moveable = false;
        }

        StartCoroutine(BattleProcess());
    }
    IEnumerator BattleProcess()
    {
        List<GameObject> attacker = new List<GameObject>();
        List<GameObject> defender = new List<GameObject>();
        int CurrentCard;
        int RandomCard;
        bool isAtackingCharacter = false;

        while(EnemyBattleCards.Count != 0 || CharacterBattleCards.Count != 0)
        {
            //Calculating who will atacking first and who will defence
            if (whoAttacking == 1)
            {
                attacker = CharacterBattleCards;
                isAtackingCharacter = true;
                defender = EnemyBattleCards;
                CurrentCard = CurrentCharacterCard;
                RandomCard = (int)Random.Range(0, EnemyBattleCards.Count - 0.1f);
            }
            else
            {
                attacker = EnemyBattleCards;
                isAtackingCharacter = false;
                defender = CharacterBattleCards;
                CurrentCard = CurrentEnemyCard;
                RandomCard = (int)Random.Range(0, CharacterBattleCards.Count - 0.1f);

            }

            if (CurrentCard >= attacker.Count) CurrentCard = 0;
            if (attacker.Count == 0) {goToShopScene = true; yield break;} 

            startCardPos = attacker[CurrentCard].transform.position;

            //atack card animation
            while (Vector2.Distance(attacker[CurrentCard].transform.position, defender[RandomCard].transform.position) != 0)
            {
                attacker[CurrentCard].transform.position = Vector2.MoveTowards(attacker[CurrentCard].transform.position, defender[RandomCard].transform.position, 0.01f);
                yield return null;
            }

            //health cards updates
            defender[RandomCard].GetComponent<CardState>().card.health -= attacker[CurrentCard].GetComponent<CardState>().card.attack;
            GameProcess.UpdateCard(defender[RandomCard], defender[RandomCard].GetComponent<CardState>().card, false);
            attacker[CurrentCard].GetComponent<CardState>().card.health -= defender[RandomCard].GetComponent<CardState>().card.attack;
            GameProcess.UpdateCard(attacker[CurrentCard], attacker[CurrentCard].GetComponent<CardState>().card,false);

            //return back card animation
            while (Vector2.Distance(attacker[CurrentCard].transform.position, startCardPos) != 0)
            {
                attacker[CurrentCard].transform.position = Vector2.MoveTowards(attacker[CurrentCard].transform.position, startCardPos, 0.02f);
                yield return null;
            }

            //if health of card = 0; delete this card from scene
            if (defender[RandomCard].GetComponent<CardState>().card.health <= 0) {
                GameObject temp = defender[RandomCard];
                defender.Remove(defender[RandomCard]);
                Destroy(temp);
            }

            if (attacker[CurrentCard].GetComponent<CardState>().card.health <= 0)
            {
                GameObject temp = attacker[CurrentCard];
                attacker.Remove(attacker[CurrentCard]);
                Destroy(temp);
            }

            if(CurrentCard > attacker.Count) CurrentCard = 0;
            if(attacker.Count == 0) {goToShopScene = true; yield break;}
            if (defender.Count == 0){goToShopScene = true; yield break;}

            //updating values
            whoAttacking = whoAttacking == 0 ? 1 : 0;
            if (isAtackingCharacter) CurrentCharacterCard++;
            else CurrentEnemyCard++;

            yield return null;
        }
        goToShopScene = true;
        yield break;
        
    }

    public GameObject ReadCard1(Card card)
    {

        TextMeshProUGUI _cardAttack = _cardPrefabCopy.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI _cardHealth = _cardPrefabCopy.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI _cardLevel = _cardPrefabCopy.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        Image _cardImage = _cardPrefabCopy.transform.GetChild(0).GetChild(0).GetComponent<Image>();

        _cardImage.sprite = card.spriteImage;
        _cardAttack.text = card.attack.ToString();
        _cardHealth.text = card.health.ToString();
        _cardLevel.text = card.level.ToString();

        return _cardPrefabCopy;
    }
}
