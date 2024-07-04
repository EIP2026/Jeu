using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    // Singleton
    public static CardDatabase Instance { get; private set; }
    public static List<Card> _cardList = new List<Card>();

    void Awake()
    {
        // Ensure there is only one instance of CardDatabase
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Initialize the card list
        _cardList.Clear();
        _cardList.Add(new Card(0, "None", 0, new List<CardEffect>(), Resources.Load<Sprite>("FightScene/none"), 0));
        _cardList.Add(new Card(1, "Attack", 1, new List<CardEffect>() { new CardEffect() { _type = "attack", _strong = 4, _duration = 1 } }, Resources.Load<Sprite>("FightScene/attack"), 1));
        _cardList.Add(new Card(2, "Super Attack", 1, new List<CardEffect>() { new CardEffect() { _type = "attack", _strong = 4, _duration = 1 } }, Resources.Load<Sprite>("FightScene/attack"), 1));
        _cardList.Add(new Card(3, "Heal", 1, new List<CardEffect>() { new CardEffect() { _type = "heal", _strong = 4, _duration = 1 } }, Resources.Load<Sprite>("FightScene/block"), 2));
        _cardList.Add(new Card(4, "Attack and Draw", 2, new List<CardEffect>() { new CardEffect() { _type = "attack", _strong = 6, _duration = 1 }, new CardEffect() { _type = "draw", _strong = 2, _duration = 1 } }, Resources.Load<Sprite>("FightScene/attack_draw"), 3));
    }

    public int GetNumberOfCards(int rarity)
    {
        if (rarity != 5)
        {
            return _cardList.Where(card => card._rarity == rarity).Count();
        }
        else
        {
            return _cardList.Count;
        }    
    }
}
