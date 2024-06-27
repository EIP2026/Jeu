using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card
{
    public CardEffect[] _effects;
        public int _id;
        public string _name;
        public string _sprite;
        public int _cost;

        public Card()
        {
            
        }

        public Card(CardEffect[] effects, string sprite, int cost)
        {
            _effects = effects;
            _sprite = sprite;
            _cost = cost;
        }

}
