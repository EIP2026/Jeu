using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{
    public List<Cards> playerHand;
    public List<Card> playerHandCard;
    public GameObject cardPrefab;
    public Transform handTransform;
    private Deck playerDeck;
    public Text deckCountText;
    public Text discardCountText;

    void Start()
    {
        //playerDeck = new Deck();
        //DrawInitialHand();
        //UpdateCardCounts();
    }

    void DrawInitialHand()
    {
        playerHand = new List<Cards>();
        for (int i = 0; i < 3; i++)
        {
            DrawCards();
        }
    }

    public void DrawCards()
    {
        Cards newCard = playerDeck.DrawCard();
        if (newCard != null)
        {
            playerHand.Add(newCard);
            DisplayCards(newCard);
            UpdateCardCounts();
        }
        else
        {
            Debug.Log("Le deck est vide et il n'y a pas de cartes à remélanger !");
        }
    }

    void DisplayCards(Cards card)
    {
        if (cardPrefab == null)
        {
            Debug.LogError("cardPrefab is not assigned in the Inspector");
            return;
        }
        if (handTransform == null)
        {
            Debug.LogError("handTransform is not assigned in the Inspector");
            return;
        }

        GameObject cardObject = Instantiate(cardPrefab, handTransform);

        // Trouver le composant Text dans l'enfant Button
        Text cardText = cardObject.GetComponentInChildren<Text>();
        if (cardText == null)
        {
            Debug.LogError("Text component not found in cardPrefab");
            return;
        }
        cardText.text = $"{card.cardName}\nDamage: {card.damage}";

        // Trouver le composant Button dans le GameObject enfant
        Button cardButton = cardObject.GetComponentInChildren<Button>();
        if (cardButton == null)
        {
            Debug.LogError("Button component not found in cardPrefab");
            return;
        }
        cardButton.onClick.AddListener(() => OnCardsClicked(card));
    }

    void OnCardsClicked(Cards card)
    {
        FindObjectOfType<TurnManager>().PlayerAttackWithCards(card);
        playerHand.Remove(card);
        playerDeck.DiscardCard(card);

        // Rafraîchir la main de cartes
        RefreshHand();
    }

    void RefreshHand()
    {
        // Déplacer les cartes restantes dans la défausse
        foreach (Cards card in playerHand)
        {
            playerDeck.DiscardCard(card);
        }

        // Vider la main actuelle
        playerHand.Clear();

        // Détruire les objets de carte de l'UI
        foreach (Transform child in handTransform)
        {
            Destroy(child.gameObject);
        }

        // Piocher de nouvelles cartes
        DrawInitialHand();
        UpdateCardCounts();
    }

    void UpdateCardCounts()
    {
        deckCountText.text = $"Deck: {playerDeck.GetDeckCount()}";
        discardCountText.text = $"Discard: {playerDeck.GetDiscardCount()}";
    }
}
