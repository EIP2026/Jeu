using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
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

        public Card(Effect[] effects, string sprite)
        {
            _effects = effects;
            _sprite = sprite;
        }
    }

    public static Effect effectAttackOne8 = new Effect("attackOne", 8, 1);
    public static Effect effectAttackAll6 = new Effect("attackAll", 6, 1);
    public static Effect effectVuln2 = new Effect("vulnerable", 25, 2);
    public static Effect effectBlock5 = new Effect("block", 100, 2);
    public static Effect effectDraw1 = new Effect("draw", 1, 1);

    static Effect[] effectArrayAttackOne8Vuln2 = {effectAttackOne8, effectVuln2};
    public Card cardAttackOneVuln = new Card(effectArrayAttackOne8Vuln2, "card_attack_vuln");
    static Effect[] effectArrayAttackAll6Draw1 = {effectAttackAll6, effectDraw1};
    public Card cardAttackAllDraw = new Card(effectArrayAttackAll6Draw1, "card_attack_vul");
    static Effect[] effectArrayBlock5 = {effectBlock5};
    public Card cardBlock = new Card(effectArrayBlock5, "card_attack_vul");
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
