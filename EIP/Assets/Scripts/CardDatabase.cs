using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "None", 0, new List<CardEffect>(), "card_none"));
        cardList.Add(new Card(1, "Attack", 1, new List<CardEffect>() {new CardEffect(){ _type = "attack", _strong = 4, _duration = 1 }}, "card_attack"));
        cardList.Add(new Card(2, "Block", 1, new List<CardEffect>() {new CardEffect(){ _type = "block", _strong = 4, _duration = 1}}, "card_block"));
        cardList.Add(new Card(3, "Poison", 2, new List<CardEffect>() { new CardEffect(){ _type = "attack", _strong = 6, _duration = 1}, new CardEffect(){ _type = "draw", _strong = 1, _duration = 1 }}, "card_attack_draw"));
    }
}
