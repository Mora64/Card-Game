using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    private List<Vector2> places;
    public GameObject _cardPrefabCopy;
    List<GameObject> CharacterBattleCards;
    List<GameObject> EnemyBattleCards;
    
    int whoAttacking;
    int indexOfRandomEnemyCard;
    int indexOfRandomCharacterCard;
    void Start()
    {
        
        EnemyBattleCards = new List<GameObject>();
        CharacterBattleCards = new List<GameObject>();
        GenerateCardsInBattle();
        whoAttacking = (int)Random.Range(0f, 1.999f);
        indexOfRandomCharacterCard = (int)Random.Range(0, CharacterBattleCards.Count - 0.1f);
        indexOfRandomEnemyCard = (int)Random.Range(0, EnemyBattleCards.Count - 0.1f);
        
    }
       
    private void GenerateCardsInBattle()
    {
       
        places = GameProcess.GetNewCardPlaces('s', Enemy.Cards.Count);
        for (int i = 0; i < Enemy.Cards.Count; i++)
        {
            Card currentCard = Enemy.Cards[i];
            GameObject BattleCard = ReadCard1(currentCard);
            if (EnemyBattleCards == null) print("null1");
            EnemyBattleCards.Add(Instantiate(BattleCard, places[i], BattleCard.transform.rotation));
            CardState state = EnemyBattleCards[i].GetComponent<CardState>();
            state.state = CardState.State.EnemyCard;
            state.card = new Card(currentCard);
        }
        places = GameProcess.GetNewCardPlaces('h', GameProcess.HandCards.Count);
        for (int i = 0; i < GameProcess.HandCards.Count; i++)
        {
            GameProcess.HandCards[i].SetActive(true);
            CharacterBattleCards.Add(Instantiate(GameProcess.HandCards[i], places[i], GameProcess.HandCards[i].transform.rotation));
            CardState state = CharacterBattleCards[i].GetComponent<CardState>();
            state.state = CardState.State.CharacterCard;
            
        }
    }
    IEnumerator BattleProcess()
    {
        if(whoAttacking == 0)
        {
            while(Vector2.Distance(CharacterBattleCards[indexOfRandomCharacterCard].transform.position, EnemyBattleCards[indexOfRandomEnemyCard].transform.position) != 0)
            {
                CharacterBattleCards[indexOfRandomCharacterCard].transform.position = Vector2.MoveTowards(CharacterBattleCards[indexOfRandomCharacterCard].transform.position, EnemyBattleCards[indexOfRandomEnemyCard].transform.position, 0.02f);
                yield return null;
            }
            EnemyBattleCards[indexOfRandomEnemyCard].GetComponent<CardState>().card.health-= CharacterBattleCards[indexOfRandomCharacterCard].GetComponent<CardState>().card.attack;
            if (EnemyBattleCards[indexOfRandomEnemyCard].GetComponent<CardState>().card.health == 0) Destroy(EnemyBattleCards[indexOfRandomEnemyCard]);
            CharacterBattleCards[indexOfRandomCharacterCard].GetComponent<CardState>().card.health -= EnemyBattleCards[indexOfRandomEnemyCard].GetComponent<CardState>().card.attack;
            if (CharacterBattleCards[indexOfRandomCharacterCard].GetComponent<CardState>().card.health == 0) Destroy(CharacterBattleCards[indexOfRandomCharacterCard]);
        }
        if(whoAttacking == 1)
        {

        }
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
