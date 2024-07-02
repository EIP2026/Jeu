using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToHand : MonoBehaviour
{
    public GameObject _hand;
    public GameObject _handCard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _hand = GameObject.Find("Hand");
        _handCard.transform.SetParent(_hand.transform);
        _handCard.transform.localScale = Vector3.one;
        _handCard.transform.position = new Vector3(transform.position.x, transform.position.y, -40);
        _handCard.transform.eulerAngles = new Vector3(25, 0, 0);
    }
}
