using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Battle : MonoBehaviour
{
    private List<Vector3> places;
    public GameObject _cardPrefabCopy;
    List<GameObject> CharacterBattleCards;
    List<GameObject> EnemyBattleCards;

    List<GameObject> attackerList = new List<GameObject>();
    List<GameObject> defenderList = new List<GameObject>();

    int whoAttacking;
    int CurrentCharacterCard = 0;
    int CurrentEnemyCard = 0;
    bool goToShopScene = false;
    bool isAtackingCharacter = false;
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
            StartCoroutine(EndOfTheBattle());
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


        places = GameProcess.GetNewCardPlaces('b', GameProcess.BattleGroundCards.Count);
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
        
        int CurrentCard;
        int RandomCard;
        

        while(EnemyBattleCards.Count != 0 || CharacterBattleCards.Count != 0)
        {
            //Calculating who will atacking first and who will defence
            if (whoAttacking == 1)
            {
                attackerList = CharacterBattleCards;
                isAtackingCharacter = true;
                defenderList = EnemyBattleCards;
                CurrentCard = CurrentCharacterCard;
                RandomCard = (int)Random.Range(0, EnemyBattleCards.Count - 0.1f);
            }
            else
            {
                attackerList = EnemyBattleCards;
                isAtackingCharacter = false;
                defenderList = CharacterBattleCards;
                CurrentCard = CurrentEnemyCard;
                RandomCard = (int)Random.Range(0, CharacterBattleCards.Count - 0.1f);

            }

            if (CurrentCard >= attackerList.Count) CurrentCard = 0;
            if (attackerList.Count == 0) {goToShopScene = true; yield break;} 

            startCardPos = attackerList[CurrentCard].transform.position;

            yield return Attack(attackerList[CurrentCard], defenderList[RandomCard], startCardPos);

            if(CurrentCard > attackerList.Count) CurrentCard = 0;
            if(attackerList.Count == 0) {goToShopScene = true; yield break;}
            if (defenderList.Count == 0){goToShopScene = true; yield break;}

            //updating values
            whoAttacking = whoAttacking == 0 ? 1 : 0;
            if (isAtackingCharacter) CurrentCharacterCard++;
            else CurrentEnemyCard++;

            yield return null;
        }
        goToShopScene = true;
        yield break;
        
    }
    IEnumerator Attack(GameObject attacker, GameObject defender, Vector3 startPos)
    {
        Vector3 startScale = attacker.transform.localScale;
        float scalingValue = 1.2f;
        float scalingSpeed = 0.4f;
        float movingSpeed = 8f;
        //scaling current attacking card
        while(attacker.transform.localScale != startScale * scalingValue)
        {
            attacker.transform.localScale = Vector3.MoveTowards(attacker.transform.localScale, startScale * scalingValue, Time.deltaTime * scalingSpeed);
            yield return null;
        }

        //moving current card to target
        Vector2 targetPoint = Vector3.zero;
        Bounds bounds = defender.GetComponent<BoxCollider2D>().bounds;
        if (isAtackingCharacter)
        {
            if (attacker.transform.position.x == defender.transform.position.x)
            {
                targetPoint = new Vector2(bounds.center.x, bounds.center.y - GameProcess.CARDHEIGHT / 4);
            }
            else if (attacker.transform.position.x > defender.transform.position.x)
            {
                targetPoint = new Vector3(bounds.max.x, bounds.min.y);
            }
            else
            {
                targetPoint = new Vector3(bounds.min.x, bounds.min.y);
            }
        }
        else
        {
            if (attacker.transform.position.x == defender.transform.position.x)
            {
                targetPoint = new Vector2(bounds.center.x, bounds.center.y + GameProcess.CARDHEIGHT / 4);
            }
            else if (attacker.transform.position.x > defender.transform.position.x)
            {
                targetPoint = new Vector2(bounds.max.x, bounds.max.y);
            }
            else
            {
                targetPoint = new Vector2(bounds.min.x, bounds.max.y);
            }
        }


        while (Vector2.Distance(attacker.transform.position, targetPoint) != 0)
        {
            attacker.transform.position = Vector2.MoveTowards(attacker.transform.position, targetPoint, Time.deltaTime * movingSpeed);
            yield return null;
        }

        //health cards updates
        defender.GetComponent<CardState>().card.health -= attacker.GetComponent<CardState>().card.attack;
        GameProcess.UpdateCard(defender, defender.GetComponent<CardState>().card, false);
        attacker.GetComponent<CardState>().card.health -= defender.GetComponent<CardState>().card.attack;
        GameProcess.UpdateCard(attacker, attacker.GetComponent<CardState>().card, false);

        //return back card animation
        while (Vector2.Distance(attacker.transform.position, startCardPos) != 0 && attacker.transform.localScale != startScale)
        {
            attacker.transform.position = Vector2.MoveTowards(attacker.transform.position, startCardPos, 0.02f);
            attacker.transform.localScale = Vector3.MoveTowards(attacker.transform.localScale, startScale, Time.deltaTime * scalingSpeed);
            yield return null;
        }

        //if health of card = 0; delete this card from scene
        if (defender.GetComponent<CardState>().card.health <= 0)
        {
            GameObject temp = defender;
            defenderList.Remove(defender);
            Destroy(temp);
        }

        if (attacker.GetComponent<CardState>().card.health <= 0)
        {
            GameObject temp = attacker;
            attackerList.Remove(attacker);
            Destroy(temp);
        }

    }
    IEnumerator EndOfTheBattle()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Shop");
        
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
