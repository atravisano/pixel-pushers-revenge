using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
        cardMenuBackground.SetActive(true);
        cardMenuOpen.SetActive(false);
        cardMenuClose.SetActive(true);
        showCards();
    }

    void CloseMenu(){
        cardMenuBackground.SetActive(false);
        cardMenuOpen.SetActive(true);
        cardMenuClose.SetActive(false);
    }

    void showCards(){
        Debug.Log("show cards");
        for(var i = 0; i <= inventory.Count; i++){
            Object prefab = Instantiate(cardPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            //prefab.GetComponent<CardFlip>();
            //prefab.card = inventory[i];
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
