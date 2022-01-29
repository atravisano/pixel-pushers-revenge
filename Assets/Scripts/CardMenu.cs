using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CardMenu : MonoBehaviour
{
    GameObject cardMenuBackground;
    GameObject cardMenuOpen;
    GameObject cardMenuClose;

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
}
