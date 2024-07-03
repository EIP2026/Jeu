using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{
    public List<Cards> playerHand;
    public List<Card> playerHandCard;
    public GameObject cardPrefab;
    public Transform handTransform;

    void Start()
    {
        //DrawInitialHand();
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
        string cardName = "Attack";
        int damage = Random.Range(1, 6);
        Cards newCard = new Cards(cardName, damage);

        playerHand.Add(newCard);
        DisplayCards(newCard);
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

        // Rafraîchir la main de cartes
        foreach (Transform child in handTransform)
        {
            Destroy(child.gameObject);
        }

        DrawInitialHand(); // Redessine la main
    }
}
