using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Platformer.Mechanics;

public class CardMenu : MonoBehaviour
{
    public GameObject cardMenuBackground;
    public GameObject cardMenuOpen;
    public GameObject cardMenuClose;
    public GameObject cardHolder;
    public bool isWinScreen;

    public GameObject cardPrefab;

    private static List<Card> inventory = new List<Card>();
    public static CardMenu instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if(isWinScreen){
            ShowCards();
        }        
    }

    public void ResetInventory()
    {
        inventory = new List<Card>();
    }

    public void OpenMenu()
    {
        Time.timeScale = 0;
        cardMenuBackground.SetActive(true);
        cardMenuOpen.SetActive(false);
        cardMenuClose.SetActive(true);
        ShowCards();
        ButtonExit();
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        cardMenuBackground.SetActive(false);
        cardMenuOpen.SetActive(true);
        cardMenuClose.SetActive(false);
        ButtonExit();
    }

    void ShowCards()
    {
        DestroyCards();
        for (var i = 0; i < inventory.Count; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity, cardHolder.transform);
            CardFlip cardFlipComponent = newCard.GetComponentInChildren<CardFlip>();
            DisplayCard(newCard, inventory[i], cardFlipComponent);
        }
    }

    void DisplayCard(GameObject newCard, Card card, CardFlip cardFlipComponent)
    {
        cardFlipComponent.card = card;
        cardFlipComponent.cardFace.SetActive(true);

        float scale = isWinScreen ? 2f : 2.5f;
        newCard.GetComponentInChildren<Button>().enabled = false;
        newCard.GetComponentInChildren<Image>().enabled = false;
        newCard.transform.localScale = new Vector3(scale, scale, scale);
        newCard.transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }

    void DestroyCards()
    {
        foreach (Transform child in cardHolder.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void AddCard(Card card)
    {
        inventory.Add(card);
        GameController.Instance.ApplyCard(card);
    }

    public void RemoveRandom()
    {
        if(inventory.Count > 0){
            int i = Random.Range(0, inventory.Count);
            inventory.RemoveAt(i);
        }
    }

    public void ButtonEnter()
    {
        cardMenuOpen.transform.position = cardMenuOpen.transform.position + new Vector3(-5f, 0f, 0f);
        cardMenuClose.transform.position = cardMenuClose.transform.position + new Vector3(-5f, 0f, 0f);
    }

    public void ButtonExit()
    {
        cardMenuOpen.transform.position = cardMenuOpen.transform.position + new Vector3(5f, 0f, 0f);
        cardMenuClose.transform.position = cardMenuClose.transform.position + new Vector3(5f, 0f, 0f);
    }

}
