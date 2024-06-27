using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardEffect[] _effects;
        public string _sprite;
        public int _cost;

        public Card(CardEffect[] effects, string sprite, int cost)
        {
            _effects = effects;
            _sprite = sprite;
            _cost = cost;
        }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
