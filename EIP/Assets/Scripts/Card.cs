using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Card
{
    public int _id;
    public int _cost;
    public string _name;
    public List<CardEffect> _effects;
    public Sprite _spriteImage;
    public int _rarity;

    public Card()
    {
        
    }

    public Card(int id, string name, int cost, List<CardEffect> effects, Sprite spriteImage, int rarity)
    {
        _id = id;
        _name = name;
        _cost = cost;
        _effects = effects;
        _spriteImage = spriteImage;
        _rarity = rarity;
    }

    public string effectsDescription()
    {
        string description = "";
        for (int i = 0; i < _effects.Count; i++)
        {
            switch(_effects[i]._type)
            {
                case "attack":
                    description += "Deal " + _effects[i]._strong + " damage";
                    break;
                case "block":
                    description += "Block " + _effects[i]._strong + " damage";
                    break;
                case "draw":
                    description += "Draw " + _effects[i]._strong + " card" + (_effects[i]._strong > 1 ? "s" : "");
                    break;
                case "heal":
                    description += "Heal " + _effects[i]._strong + " health";
                    break;
                default:
                    description += "Unknown effect";
                    break;
            }
            if (i < _effects.Count - 1)
            {
                description += "\n";
            }
        }
        return description;
    }

}
