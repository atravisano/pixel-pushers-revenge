using System.Collections;
using System.Collections.Generic;
using Platformer.Mechanics;
using TMPro;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    public float Delay = 0.001f;
    public GameObject cardFace;

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
        StartCoroutine(CalculateFlip());

        GameController.Instance.ClosePickCard();
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
        for (int deg = 0; deg < 180; deg++)
        {
            yield return new WaitForSeconds(Delay);
            transform.Rotate(new Vector3(0, 1, 0));
            timer++;

            if (timer == 90 || timer == -90)
            {
                Flip();
            }
        }
    }
}
