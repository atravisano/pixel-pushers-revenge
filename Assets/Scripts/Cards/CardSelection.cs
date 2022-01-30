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

    private bool used = false;

    // Start is called before the first frame update
    void Start()
    {
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

    void OnEnable()
    {
        if (used)
        {
            gameObject.SetActive(false);
            GameController.Instance.ClosePickCard();
            return;
        }

        DrawCards();
        used = true;
    }

    private void OnDisable()
    {
        ResetCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
