using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card : MonoBehaviour
{
    public int _id;
    public int _cost;
    public string _name;
    public List<CardEffect> _effects;
    public string _sprite;

    public Card()
    {
        
    }

    public Card(int id, string name, int cost, List<CardEffect> effects, string sprite)
    {
        _id = id;
        _name = name;
        _cost = cost;
        _effects = effects;
        _sprite = sprite;
    }

}
