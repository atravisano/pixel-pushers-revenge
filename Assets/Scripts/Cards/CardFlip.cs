using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using TMPro;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    public float Delay = 0.005f;
    public GameObject cardFace;
    public Card card;

    public string positiveText;
    public string negativeText;

    public TextMeshProUGUI positiveTextElement;
    public TextMeshProUGUI negativeTextElement;

    public bool cardFaceIsActive;
    
    public int timer;

    // Start is called before the first frame update
    void Start()
    {
        cardFaceIsActive = false;
        positiveTextElement.text = positiveText;
        negativeTextElement.text = negativeText;
    }

    // Update is called once per frame
    public void Selected()
    {
        if(cardFaceIsActive){
            CardMenu.instance.AddCard(card);
        } else {
            StartCoroutine(CalculateFlip());
        }
    }

    public void Flip()
    {
        if (cardFaceIsActive)
        {
            cardFace.SetActive(false);
            cardFaceIsActive = false;
        }
        else
        {
            cardFace.SetActive(true);
            cardFaceIsActive = true;
        }
    }

    IEnumerator CalculateFlip()
    {
        int speed = 9;
        for (int deg = 0; deg < 180/speed; deg++)
        {
            yield return new WaitForSecondsRealtime(Delay);
            transform.Rotate(new Vector3(0, speed, 0));
            timer += speed;

            if (timer == 90 || timer == -90)
            {
                Flip();
            }
        }
    }
}
