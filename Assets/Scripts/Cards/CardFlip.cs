using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    public float Delay = 0.001f;
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
        Debug.Log(card);
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
            Debug.Log("card face off");
            cardFace.SetActive(false);
            cardFaceIsActive = false;
        }
        else
        {
            Debug.Log("card face on");
            cardFace.SetActive(true);
            cardFaceIsActive = true;
        }
    }

    IEnumerator CalculateFlip()
    {
        int speed = 9;
        for (int deg = 0; deg < 180/speed; deg++)
        {
            yield return new WaitForSeconds(Delay);
            transform.Rotate(new Vector3(0, speed, 0));
            timer += speed;

            if (timer == 90 || timer == -90)
            {
                Flip();
            }
        }
    }
}
