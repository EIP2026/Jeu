using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> _deck = new List<Card>();
    public Card _container;
    public int _x;
    public static int _deckSize;
    public static List<Card> _staticDeck = new List<Card>();

    public GameObject _cardToHand;
    public GameObject[] _clone;
    public GameObject _hand;

    public int _maxCardsInHand;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 1; i < CardDatabase._cardList.Count; i++) {
            _deck.Add(CardDatabase._cardList[i]);
        }
        _deckSize = _deck.Count;
        shuffle();
        StartCoroutine(startGame());
    }

    // Update is called once per frame
    void Update()
    {
        _staticDeck = _deck;
    }

    IEnumerator startGame()
    {
        for (int i = 0; i < _maxCardsInHand; i++) {
            yield return new WaitForSeconds(1f);
            Instantiate(_cardToHand, transform.position, transform.rotation);
        }
    }

    public void shuffle()
    {
        for (int i = 0; i < _deck.Count; i++) {
            _container = _deck[i];
            int randomIndex = Random.Range(i, _deck.Count);
            _deck[i] = _deck[randomIndex];
            _deck[randomIndex] = _container;
        }
    }
}
