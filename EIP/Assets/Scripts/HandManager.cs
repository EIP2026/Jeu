using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandManager : MonoBehaviour
{
    public List<Cards> playerHand;
    public List<Card> playerHandCard;
    public GameObject cardPrefab;
    public Transform handTransform;
    private Deck playerDeck;
    public Text deckCountText;
    public Text discardCountText;
    public GameObject _cardToHand;
    public TurnManager _turnManager;

    void Start()
    {
        _turnManager = GameObject.Find("Canvas").GetComponent<TurnManager>();
        playerDeck = new Deck();
        DrawInitialHand();
        UpdateCardCounts();
    }

    void DrawInitialHand()
    {
        playerHand = new List<Cards>();
        playerHandCard = new List<Card>();
        for (int i = 0; i < 3; i++)
        {
            DrawCard();
        }
    }

    public void DrawCard(int amount = 1)
    {
        for (int i = 0; i < amount; i++) {
            Card newCard = playerDeck.DrawCard();
            if (newCard != null)
            {
                playerHandCard.Add(newCard);
                DisplayCard(newCard);
                UpdateCardCounts();
            }
            else
            {
                Debug.Log("Le deck est vide et il n'y a pas de cartes à remélanger !");
            }
        }
    }
    public void DrawCards()
    {
        // Cards newCard = playerDeck.DrawCard();
        // if (newCard != null)
        // {
        //     playerHand.Add(newCard);
        //     DisplayCards(newCard);
        //     UpdateCardCounts();
        // }
        // else
        // {
        //     Debug.Log("Le deck est vide et il n'y a pas de cartes à remélanger !");
        // }
    }

    void DisplayCard(Card card)
    {
        GameObject newCard = Instantiate(cardPrefab, handTransform);
        newCard.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
        DisplayCard displayCard = newCard.GetComponent<DisplayCard>();
        displayCard.SetCardData(card);
    }
    // void DisplayCards(Cards card)
    // {
    //     if (cardPrefab == null)
    //     {
    //         Debug.LogError("cardPrefab is not assigned in the Inspector");
    //         return;
    //     }
    //     if (handTransform == null)
    //     {
    //         Debug.LogError("handTransform is not assigned in the Inspector");
    //         return;
    //     }

    //     GameObject cardObject = Instantiate(cardPrefab, handTransform);

    //     // Trouver le composant Text dans l'enfant Button
    //     Text cardText = cardObject.GetComponentInChildren<Text>();
    //     if (cardText == null)
    //     {
    //         Debug.LogError("Text component not found in cardPrefab");
    //         return;
    //     }
    //     cardText.text = $"{card.cardName}\nDamage: {card.damage}";

    //     // Trouver le composant Button dans le GameObject enfant
    //     Button cardButton = cardObject.GetComponentInChildren<Button>();
    //     if (cardButton == null)
    //     {
    //         Debug.LogError("Button component not found in cardPrefab");
    //         return;
    //     }
    //     cardButton.onClick.AddListener(() => OnCardsClicked(card));
    // }

    public void RemoveCard(Card card)
    {
        playerHandCard.Remove(card);
        playerDeck.discardCard(card);
        foreach (Transform child in handTransform)
        {
            if (child.GetComponent<DisplayCard>()._displayId == card._id)
            {
                Destroy(child.gameObject);
                break;
            }
        }
        if (_turnManager.GetCurrentMana() <= 0) {
            RefreshHand();
        }
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
        foreach (Card card in playerHandCard) {
            playerDeck.discardCard(card);
        }
        playerHandCard.Clear();
        foreach (Transform child in handTransform)
        {
            Destroy(child.gameObject);
        }
        DrawInitialHand();
        UpdateCardCounts();
        _turnManager.SetManaToMax();
        // Déplacer les cartes restantes dans la défausse
        // foreach (Cards card in playerHand)
        // {
        //     playerDeck.DiscardCard(card);
        // }

        // // Vider la main actuelle
        // playerHand.Clear();

        // // Détruire les objets de carte de l'UI
        // foreach (Transform child in handTransform)
        // {
        //     Destroy(child.gameObject);
        // }

        // // Piocher de nouvelles cartes
        // DrawInitialHand();
        // UpdateCardCounts();
    }

    void UpdateCardCounts()
    {
        deckCountText.text = $"Deck: {playerDeck.GetDeckCount()}";
        discardCountText.text = $"Discard: {playerDeck.GetDiscardCount()}";
    }
}
