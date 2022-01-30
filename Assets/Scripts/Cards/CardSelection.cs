using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Platformer.Mechanics;

public class CardSelection : MonoBehaviour
{
    public GameObject CardPrefab;
    public int CardsToPickFrom;
    public Transform CardListElement;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void DrawCards()
    {
        for (int i = 0; i < CardsToPickFrom; i++)
        {
            Card card = CardDeck.instance.DealCard();

            GameObject cardOption = Instantiate(CardPrefab, CardListElement);
            CardFlip cardFlipComponent = cardOption.GetComponentInChildren<CardFlip>();
            cardFlipComponent.card = card;
        }
    }

    private void ResetCards()
    {
        for (int i = 0; i < CardListElement.childCount; i++)
        {
            Destroy(CardListElement.GetChild(i).gameObject);
        }
    }

    public void showCardSelect()
    {
        CardListElement.gameObject.SetActive(true);
        DrawCards();
    }

    public void hideCardSelect()
    {
        ResetCards();
        CardListElement.gameObject.SetActive(false);
    }
}
