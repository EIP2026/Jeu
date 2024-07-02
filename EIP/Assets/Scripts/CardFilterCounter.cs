using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardCountDisplay : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public int rarity;

    void Start()
    {
        int numberOfCards = CardDatabase.Instance.GetNumberOfCards(rarity);
        UpdateText(numberOfCards);
    }

    void UpdateText(int number)
    {
        displayText.text = number.ToString();
    }
}
