using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Character : MonoBehaviour
{
    public static int money = 3;
    public static List<Card> Cards;
    [SerializeField] private TextMeshProUGUI moneyText;
    public static int Money
    {
        get {
            return money < 10 ? money : 10;
        }
        
    }
    private void Awake() 
    {
        DontDestroyOnLoad(this);
        moneyText.text = money.ToString();
        Cards = new List<Card>();

        Cards.Add(CardDataBase.cards[0]);
        Cards.Add(CardDataBase.cards[1]);
        Cards.Add(CardDataBase.cards[2]);
    }
    private void Update()
    {
        moneyText.text = money.ToString();
    }
}
