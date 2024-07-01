using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List<Card> _cardList = new List<Card>();

    void Awake()
    {
        _cardList.Add(new Card(0, "None", 0, new List<CardEffect>(), Resources.Load<Sprite>("Assets/Sprites/FightScene/Cards/none.png")));
        _cardList.Add(new Card(1, "Attack", 1, new List<CardEffect>() {new CardEffect(){ _type = "attack", _strong = 4, _duration = 1 }}, Resources.Load<Sprite>("Assets/Sprites/FightScene/Cards/attack.png")));
        _cardList.Add(new Card(2, "Block", 1, new List<CardEffect>() {new CardEffect(){ _type = "block", _strong = 4, _duration = 1}}, Resources.Load<Sprite>("Assets/Sprites/FightScene/Cards/block.png")));
        _cardList.Add(new Card(3, "Attack and Draw", 2, new List<CardEffect>() { new CardEffect(){ _type = "attack", _strong = 6, _duration = 1}, new CardEffect(){ _type = "draw", _strong = 1, _duration = 1 }}, Resources.Load<Sprite>("Assets/Sprites/FightScene/Cards/attack_draw.png")));
    }
}
