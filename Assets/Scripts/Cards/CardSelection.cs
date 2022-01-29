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
            //Card card = DealCard();
            GameObject cardOption = Instantiate(CardPrefab, transform);
            //CardFlip cardFlipComponent = cardOption.GetComponentInChildren<CardFlip>();
            //Image image = cardFlipComponent.cardFace.GetComponent<Image>();
            //image.sprite = 
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
