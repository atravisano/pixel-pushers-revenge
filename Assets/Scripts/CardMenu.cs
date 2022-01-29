using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMenu : MonoBehaviour
{
    GameObject cardMenuBackground;
    GameObject cardMenuOpen;
    GameObject cardMenuClose;
    private static List<Card> inventory;
    public static CardMenu instance;

    void Awake()
    {
        instance = this;
        inventory = new List<Card>();
    }

    void Start(){
        cardMenuBackground = GameObject.Find("CardMenuBackground");
        cardMenuOpen = GameObject.Find("CardMenuOpen");
        cardMenuClose = GameObject.Find("CardMenuClose");

        cardMenuBackground.SetActive(false);
        cardMenuClose.SetActive(false);
    }

    public void OpenMenu(){
        cardMenuBackground.SetActive(true);
        cardMenuOpen.SetActive(false);
        cardMenuClose.SetActive(true);

        
    }

    public void CloseMenu(){
        cardMenuBackground.SetActive(false);
        cardMenuOpen.SetActive(true);
        cardMenuClose.SetActive(false);
    }

    public void AddCard(Card card){
        inventory.Add(card);
    }
}
