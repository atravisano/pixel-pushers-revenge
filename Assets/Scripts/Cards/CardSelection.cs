using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSelection : MonoBehaviour
{
    public GameObject CardPrefab;
    public int CardsToPickFrom;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < CardsToPickFrom; i++)
        {
            Card card = CardDeck.instance.DealCard();
            Debug.Log(card.title);

            GameObject cardOption = Instantiate(CardPrefab, transform);
            CardFlip cardFlipComponent = cardOption.GetComponentInChildren<CardFlip>();
            cardFlipComponent.positiveText = card.positive;
            cardFlipComponent.negativeText = card.negative;
            cardFlipComponent.card = card;
            Image image = cardFlipComponent.cardFace.GetComponent<Image>();
            image.sprite = card.image;
        }
    }

    //private Card DealCard()
    //{
    //    .return 
    //}

    // Update is called once per frame
    void Update()
    {
        
    }
}
