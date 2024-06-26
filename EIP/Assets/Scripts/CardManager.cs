using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CardManager : MonoBehaviour
{
    int cardsInHand = 2;
    public class Effect
    {
        public string _type;
        public int _strong;
        public int _duration;

        public Effect(string type, int strong, int duration)
        {
            _type = type;
            _strong = strong;
            _duration = duration;
        }
    }
    public class Card
    {
        public Effect[] _effects;
        public string _sprite;
        public int _cost;

        public Card(Effect[] effects, string sprite, int cost)
        {
            _effects = effects;
            _sprite = sprite;
            _cost = cost;
        }
    }

    public static Effect effectAttackOne8 = new Effect("attackOne", 8, 1);
    public static Effect effectAttackAll6 = new Effect("attackAll", 6, 1);
    public static Effect effectVuln2 = new Effect("vulnerable", 25, 2);
    public static Effect effectBlock5 = new Effect("block", 100, 2);
    public static Effect effectDraw1 = new Effect("draw", 1, 1);

    static Effect[] effectArrayAttackOne8Vuln2 = {effectAttackOne8, effectVuln2};
    static Card cardAttackOne8Vuln2 = new Card(effectArrayAttackOne8Vuln2, "card_attack_vuln", 2);
    static Effect[] effectArrayAttackAll6Draw1 = {effectAttackAll6, effectDraw1};
    static Card cardAttackAll6Draw1 = new Card(effectArrayAttackAll6Draw1, "card_attackall_pick", 1);
    static Effect[] effectArrayBlock5 = {effectBlock5};
    static Card cardBlock5 = new Card(effectArrayBlock5, "card_defend", 1);
    
    Card[] cardsDeck = {cardAttackOne8Vuln2, cardAttackAll6Draw1, cardBlock5};
    Card[] cardsHand = {};
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Card");
        for(int i = 0; i < cardsInHand; i++) {
            Random.Range(0, 3);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
