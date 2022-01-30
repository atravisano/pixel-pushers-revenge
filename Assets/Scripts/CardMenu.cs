using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class CardMenu : MonoBehaviour
{
    GameObject cardMenuBackground;
    GameObject cardMenuOpen;
    GameObject cardMenuClose;
    GameObject cardHolder;
    Object cardPrefab;
    private static List<Card> inventory;
    public static CardMenu instance;

    void Awake()
    {
        instance = this;
        inventory = new List<Card>();
        cardPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Card.prefab", typeof(GameObject));
    }

    void Start(){
        cardMenuBackground = GameObject.Find("CardMenuBackground");
        cardMenuOpen = GameObject.Find("CardMenuOpen");
        cardMenuClose = GameObject.Find("CardMenuClose");
        cardHolder = GameObject.Find("CardHolder");

        cardMenuBackground.SetActive(false);
        cardMenuClose.SetActive(false);

        AddPlaceholderCards(); // REMOVE ME
    }

    void OpenMenu(){
        Time.timeScale = 0;
        cardMenuBackground.SetActive(true);
        cardMenuOpen.SetActive(false);
        cardMenuClose.SetActive(true);
        ShowCards();
    }

    void CloseMenu(){
        Time.timeScale = 1;
        cardMenuBackground.SetActive(false);
        cardMenuOpen.SetActive(true);
        cardMenuClose.SetActive(false);
    }

    void ShowCards(){
        DestroyCards();
        for(var i = 0; i < inventory.Count; i++){
            GameObject newCard = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity, cardHolder.transform) as GameObject;
            CardFlip cardFlipComponent = newCard.GetComponentInChildren<CardFlip>();
            DisplayCard(newCard, inventory[i], cardFlipComponent);
        }
    }

    void DisplayCard(GameObject newCard, Card card, CardFlip cardFlipComponent){
        cardFlipComponent.card = card;
        cardFlipComponent.cardFace.SetActive(true);
        
        newCard.GetComponentInChildren<Button>().enabled = false;
        newCard.GetComponentInChildren<Image>().enabled = false;
        newCard.transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
        newCard.transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }

    void DestroyCards(){
        foreach (Transform child in cardHolder.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    //REMPOVE ME (AddPlaceholderCards)
    void AddPlaceholderCards(){
        Card[] cards = Resources.LoadAll<Card>("Cards");
        inventory.Add(cards[0]);
        inventory.Add(cards[1]);
        inventory.Add(cards[2]);
        inventory.Add(cards[3]);
        inventory.Add(cards[4]);
        inventory.Add(cards[5]);
        inventory.Add(cards[6]);
        inventory.Add(cards[7]);
    }

    public void AddCard(Card card){
        inventory.Add(card);
    }




}
