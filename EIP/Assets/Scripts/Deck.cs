using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private List<Cards> cards;
    private List<Cards> discardPile;

    public Deck()
    {
        cards = new List<Cards>();
        discardPile = new List<Cards>();
        InitializeDeck();
        ShuffleDeck();
    }

    private void InitializeDeck()
    {
        for (int i = 0; i < 10; i++)
        {
            string cardName = "Attack";
            int damage = Random.Range(1, 6);
            Cards newCard = new Cards(cardName, damage);
            cards.Add(newCard);
        }
    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Cards temp = cards[i];
            int randomIndex = Random.Range(0, cards.Count);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    public Cards DrawCard()
    {
        if (cards.Count == 0)
        {
            ReshuffleDeck();
            if (cards.Count == 0)
            {
                Debug.Log("Le deck et la défausse sont vides !");
                return null;
            }
        }
        Cards drawnCard = cards[0];
        cards.RemoveAt(0);
        return drawnCard;
    }

    public void DiscardCard(Cards card)
    {
        discardPile.Add(card);
    }

    private void ReshuffleDeck()
    {
        if (discardPile.Count > 0)
        {
            cards.AddRange(discardPile);
            discardPile.Clear();
            ShuffleDeck();
            Debug.Log("Le deck a été remélangé avec les cartes de la défausse.");
        }
    }

    public int GetDeckCount()
    {
        return cards.Count;
    }

    public int GetDiscardCount()
    {
        return discardPile.Count;
    }
}
