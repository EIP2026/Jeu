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
        _x = 0;
        for (int i = 0; i < 10; i++) {
            _x = Random.Range(1, CardDatabase._cardList.Count);
            _deck.Add(CardDatabase._cardList[_x]);
        }
        _deckSize = _deck.Count;
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
