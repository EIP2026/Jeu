using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public static Card displayCard;
    public int displayId;
    public int cardId;
    public string cardName;
    public int cardCost;
    public List<CardEffect> cardEffects;
    public Sprite spriteImage;

    public TextMeshProUGUI  nameText;
    public TextMeshProUGUI  costText;
    public TextMeshProUGUI  effectsText;
    public Image artImage;
    // Start is called before the first frame update
    void Start()
    {
        displayCard = CardDatabase._cardList[displayId];
        cardId = displayCard._id;
        cardName = displayCard._name;
        cardCost = displayCard._cost;
        cardEffects = displayCard._effects;
        spriteImage = displayCard._spriteImage;

        nameText.text = cardName;
        costText.text = "" + cardCost;
        effectsText.text = displayCard.effectsDescription();
        artImage.sprite = spriteImage;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
