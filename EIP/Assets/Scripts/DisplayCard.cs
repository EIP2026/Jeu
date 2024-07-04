using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DisplayCard : MonoBehaviour
{
    public Card _displayCard;
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
    public GameObject _canvas;
    public int _numberOfCardsInDeck;

    public Button _cardButton;

    public TurnManager _turnManager;
    public HandManager _handManager;
    // Start is called before the first frame update
    void Start()
    {
        _numberOfCardsInDeck = PlayerDeck._deckSize;
        _displayCard = CardDatabase._cardList[_displayId];
        if (this.tag == "Clone") {
            int randomIndex = Random.Range(0, _numberOfCardsInDeck);
            //_displayCard = PlayerDeck._staticDeck[randomIndex];
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

        _turnManager = GameObject.Find("Canvas").GetComponent<TurnManager>();
        _handManager = GameObject.Find("Canvas").GetComponent<HandManager>();
        if (_turnManager != null) {
            _cardButton = GetComponentInChildren<Button>();
            _cardButton.onClick.AddListener(() => OnCardClicked());
        }
    }

    public void SetCardData(Card card)
    {
        _displayCard = card;
        _displayId = card._id;
        _cardId = card._id;
        _cardName = card._name;
        _cardCost = card._cost;
        _cardEffects = card._effects;
        _spriteImage = card._spriteImage;
        _nameText.text = card._name;
        _costText.text = card._cost.ToString(); // Convert int to string for TextMeshPro
        _effectsText.text = card.effectsDescription();
        _artImage.sprite = card._spriteImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCardClicked()
    {
        if (!_turnManager.IsPlayerTurn()) {
            return;
        }
        foreach (CardEffect effect in _cardEffects)
        {
            if (effect._type == "attack") {
                _turnManager.PlayerAttackWithCard(effect._strong);
            }
        }
        _handManager.RemoveCard(_displayCard);
    }
}
