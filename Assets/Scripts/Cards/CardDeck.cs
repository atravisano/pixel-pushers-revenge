using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public static CardDeck instance;

    private static List<Card> deck;

    void Awake()
    {
        deck = new List<Card>();
        instance = this;

        Card[] cards = Resources.LoadAll<Card>("Cards");
        foreach (Card card in cards)
        {
            deck.Add(card);
        }
        Debug.Log("Deck Count: " + deck.Count);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public Card DealCard()
    {
        int i = Random.Range(0, deck.Count);
        Card randomCard = deck[i];
        deck.RemoveAt(i);
        
        Debug.Log("Picked " + randomCard.name);
        Debug.Log(deck.Count);

        return randomCard;
    }

}
