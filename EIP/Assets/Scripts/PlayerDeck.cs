using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> deck = new List<Card>();
    public Card container;
    public int x;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        for (int i = 0; i < 10; i++) {
            x = Random.Range(1, CardDatabase._cardList.Count);
            deck[i] = CardDatabase._cardList[x];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shuffle()
    {
        for (int i = 0; i < deck.Count; i++) {
            container = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = container;
        }
    }
}
