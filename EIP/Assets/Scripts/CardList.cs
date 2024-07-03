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

    void Start()
    {
        numberOfCards = CardDatabase.Instance.GetNumberOfCards(5);
        PopulateList();
    }

    void PopulateList()
    {
        List<Card> cardsToDisplay = CardDatabase._cardList.ToList();
        // for each card in the list, print their name

        for (int i = 0; i < numberOfCards; i++)
        {
            GameObject cardObject = Instantiate(cardPrefab, listContainer);

            // Set the scale
            cardObject.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
            switch (cardsToDisplay[i]._rarity)
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

            DisplayCard displayCard = cardObject.GetComponent<DisplayCard>();
            if (displayCard != null && i < cardsToDisplay.Count)
            {
                displayCard.SetCardData(cardsToDisplay[i]);
            }
        }
    }
}
