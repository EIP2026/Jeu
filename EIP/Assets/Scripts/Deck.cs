using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private List<Cards> cards;
    private List<Cards> discardPile;

    private List<Card> _cards;
    private List<Card> _discardPile;

    public Deck()
    {
        cards = new List<Cards>();
        discardPile = new List<Cards>();
        _cards = new List<Card>();
        _discardPile = new List<Card>();
        InitializeDeck();
        ShuffleDeck();
    }

    private void InitializeDeck()
    {
        // for (int i = 0; i < 10; i++)
        // {
        //     string cardName = "Attack";
        //     int damage = Random.Range(1, 6);
        //     Cards newCard = new Cards(cardName, damage);
        //     cards.Add(newCard);
        // }
        foreach (Card card in CardDatabase._cardList)
        {
            if (card._id != 0)
            {
                if (card._name == "Attack" || card._name == "Heal") {
                    for (int i = 0; i < 5; i++) {
                        _cards.Add(card);
                    }
                } else {
                    for (int i = 0; i < 2; i++) {
                        _cards.Add(card);
                    }
                }
            }
        }
    }

    private void ShuffleDeck()
    {
        // for (int i = 0; i < cards.Count; i++)
        // {
        //     Cards temp = cards[i];
        //     int randomIndex = Random.Range(0, cards.Count);
        //     cards[i] = cards[randomIndex];
        //     cards[randomIndex] = temp;
        // }
        for (int i = 0; i < _cards.Count; i++)
        {
            Card temp = _cards[i];
            int randomIndex = Random.Range(0, _cards.Count);
            _cards[i] = _cards[randomIndex];
            _cards[randomIndex] = temp;
        }
    }

    public Card DrawCard()
    {
        if (_cards.Count == 0)
        {
            ReshuffleDeck();
            if (_cards.Count == 0)
            {
                Debug.Log("Le deck et la défausse sont vides !");
                return null;
            }
        }
        Card drawnCard = _cards[0];
        _cards.RemoveAt(0);
        return drawnCard;
    }
    // public Cards DrawCard()
    // {
    //     if (cards.Count == 0)
    //     {
    //         ReshuffleDeck();
    //         if (cards.Count == 0)
    //         {
    //             Debug.Log("Le deck et la défausse sont vides !");
    //             return null;
    //         }
    //     }
    //     Cards drawnCard = cards[0];
    //     cards.RemoveAt(0);
    //     return drawnCard;
    // }

    public void discardCard(Card card)
    {
        _discardPile.Add(card);
    }

    public void DiscardCard(Cards card)
    {
        discardPile.Add(card);
    }

    private void ReshuffleDeck()
    {
        if (_discardPile.Count > 0)
        {
            _cards.AddRange(_discardPile);
            _discardPile.Clear();
            ShuffleDeck();
            Debug.Log("Le deck a été remélangé avec les cartes de la défausse.");
        }
    }
    // private void ReshuffleDeck()
    // {
    //     if (discardPile.Count > 0)
    //     {
    //         cards.AddRange(discardPile);
    //         discardPile.Clear();
    //         ShuffleDeck();
    //         Debug.Log("Le deck a été remélangé avec les cartes de la défausse.");
    //     }
    // }

    public int GetDeckCount()
    {
        return _cards.Count;
    }

    public int GetDiscardCount()
    {
        return _discardPile.Count;
    }
}
