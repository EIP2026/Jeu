using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardComponent : MonoBehaviour
{
    public Image cardImage;
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI cardCost;
    public TextMeshProUGUI cardEffects;
    public TextMeshProUGUI cardRarity;

    public void SetCardData(Card card)
    {
        if (cardImage != null)
            cardImage.sprite = card._spriteImage;
        if (cardName != null)
            cardName.text = card._name;
        if (cardCost != null)
            cardCost.text = "Cost: " + card._cost.ToString();
        if (cardEffects != null)
            cardEffects.text = card.effectsDescription();
        if (cardRarity != null)
            cardRarity.text = "Rarity: " + card._rarity.ToString();
    }
}
