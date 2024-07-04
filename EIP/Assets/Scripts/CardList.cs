using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Collections.Generic;

public class DisplayCardInList : MonoBehaviour
{
    public GameObject cardPrefab; // Assign the card prefab in the Inspector
    public Transform listContainer; // Assign the container for the list in the Inspector
    public int numberOfCards = 10; // Number of cards to display
    public float scaleFactor = 1.5f; // Scale factor for the cards

    // UI Toggle buttons
    public Toggle toggleRarity0;
    public Toggle toggleRarity1;
    public Toggle toggleRarity2;
    public Toggle toggleRarity3;

    private List<Card> cardsToDisplay;
    private DynamicContentResizer contentResizer; // Reference to the DynamicContentResizer script

    void Start()
    {
        // Initialize the toggle listeners
        toggleRarity0.onValueChanged.AddListener(delegate { FilterCardsByRarity(); });
        toggleRarity1.onValueChanged.AddListener(delegate { FilterCardsByRarity(); });
        toggleRarity2.onValueChanged.AddListener(delegate { FilterCardsByRarity(); });
        toggleRarity3.onValueChanged.AddListener(delegate { FilterCardsByRarity(); });

        // Get reference to the DynamicContentResizer script
        contentResizer = FindObjectOfType<DynamicContentResizer>();

        // Initially display all cards
        cardsToDisplay = CardDatabase._cardList.ToList();
        PopulateList();
    }

    void PopulateList()
    {
        // Clear existing cards
        foreach (Transform child in listContainer)
        {
            Destroy(child.gameObject);
        }

        // Filter the cards by selected rarity
        List<Card> filteredCards = FilterCards();

        for (int i = 0; i < filteredCards.Count && i < numberOfCards; i++)
        {
            GameObject cardObject = Instantiate(cardPrefab, listContainer);

            // Set the scale
            cardObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

            // Set the card color based on rarity
            switch (filteredCards[i]._rarity)
            {
                case 1:
                    cardObject.transform.GetChild(0).GetComponent<Image>().color = Color.red;
                    break;
                case 2:
                    cardObject.transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
                    break;
                case 3:
                    cardObject.transform.GetChild(0).GetComponent<Image>().color = Color.green;
                    break;
            }

            // Set the card data
            DisplayCard displayCard = cardObject.GetComponent<DisplayCard>();
            if (displayCard != null)
            {
                displayCard.SetCardData(filteredCards[i]);
            }
        }
    }

    void FilterCardsByRarity()
    {
        cardsToDisplay = CardDatabase._cardList.ToList();
        PopulateList();
    }

    List<Card> FilterCards()
    {
        List<Card> filteredCards = new List<Card>();

        if (toggleRarity0.isOn)
        {
            filteredCards.AddRange(cardsToDisplay.Where(card => card._rarity == 0));
        }
        if (toggleRarity1.isOn)
        {
            filteredCards.AddRange(cardsToDisplay.Where(card => card._rarity == 1));
        }
        if (toggleRarity2.isOn)
        {
            filteredCards.AddRange(cardsToDisplay.Where(card => card._rarity == 2));
        }
        if (toggleRarity3.isOn)
        {
            filteredCards.AddRange(cardsToDisplay.Where(card => card._rarity == 3));
        }

        // If no toggle is on, display all cards
        if (!toggleRarity0.isOn && !toggleRarity1.isOn && !toggleRarity2.isOn && !toggleRarity3.isOn)
        {
            filteredCards = cardsToDisplay;
        }

        return filteredCards;
    }
}
