using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    int _cardsInHand;

    // public static CardEffect effectAttackOne8 = new CardEffect("attackOne", 8, 1);
    // public static CardEffect effectAttackAll6 = new CardEffect("attackAll", 6, 1);
    // public static CardEffect effectVuln2 = new CardEffect("vulnerable", 25, 2);
    // public static CardEffect effectBlock5 = new CardEffect("block", 100, 2);
    // public static CardEffect effectDraw1 = new CardEffect("draw", 1, 1);

    // static CardEffect[] effectArrayAttackOne8Vuln2 = {effectAttackOne8, effectVuln2};
    // static Card cardAttackOne8Vuln2 = new Card(effectArrayAttackOne8Vuln2, "card_attack_vuln", 2);
    // static CardEffect[] effectArrayAttackAll6Draw1 = {effectAttackAll6, effectDraw1};
    // static Card cardAttackAll6Draw1 = new Card(effectArrayAttackAll6Draw1, "card_attackall_pick", 1);
    // static CardEffect[] effectArrayBlock5 = {effectBlock5};
    // static Card cardBlock5 = new Card(effectArrayBlock5, "card_defend", 1);
    
    // List<Card> _cardsDeck = new List<Card> {cardAttackOne8Vuln2, cardAttackAll6Draw1, cardBlock5};
    List<Card> _cardsHand = new List<Card>();

    public CardManager(int cardsInHand)
    {
        _cardsInHand = 2;
    }

    void DrawCard(int numberOfCards)
    {
        for(int i = 0; i < numberOfCards; i++) {
            //int randomIndex = Random.Range(0, _cardsDeck.Count);
            //_cardsHand.Add(_cardsDeck[randomIndex]);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _cardsInHand = 2;
        Debug.Log(_cardsInHand);
        DrawCard(_cardsInHand);
    }

}
