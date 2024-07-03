using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public static Card _displayCard;
    public int _displayId;
    public int _cardId;
    public string _cardName;
    public int _cardCost;
    public List<CardEffect> _cardEffects;
    public Sprite _spriteImage;

    public TextMeshProUGUI  _nameText;
    public TextMeshProUGUI  _costText;
    public TextMeshProUGUI  _effectsText;
    public Image _artImage;
    public GameObject _handPanel;
    public int _numberOfCardsInDeck;
    // Start is called before the first frame update
    void Start()
    {
        _numberOfCardsInDeck = PlayerDeck._deckSize;
        _displayCard = CardDatabase._cardList[_displayId];
    }

    public void SetCardData(Card card)
    {
        _nameText.text = card._name;
        _costText.text = card._cost.ToString(); // Convert int to string for TextMeshPro
        _effectsText.text = card.effectsDescription();
        _artImage.sprite = card._spriteImage;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.tag == "Clone") {
            int randomIndex = Random.Range(0, _numberOfCardsInDeck);
            _displayCard = PlayerDeck._staticDeck[randomIndex];
            this.tag = "Untagged";
        _cardId = _displayCard._id;
        _cardName = _displayCard._name;
        _cardCost = _displayCard._cost;
        _cardEffects = _displayCard._effects;
        _spriteImage = _displayCard._spriteImage;

        _nameText.text = _cardName;
        _costText.text = "" + _cardCost;
        _effectsText.text = _displayCard.effectsDescription();
        _artImage.sprite = _spriteImage;
        }
    }
}
