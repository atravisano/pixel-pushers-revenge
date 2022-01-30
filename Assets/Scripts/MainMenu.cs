using Platformer.Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    GameObject backgroundFader;
    GameObject backgroundAudio;

    void OnEnable()
    {
        var player = FindObjectOfType<PlayerController>();
        if (player == null)
        {
            return;
        }

        Destroy(player.gameObject);
    }

    void Start(){
        backgroundFader = GameObject.Find("ImageBackgroundFader");
        backgroundAudio = GameObject.Find("AudioBackground");
        if(backgroundFader){
            StartCoroutine(FadeIn());
        }
    }

    public void PlayGame(){
        FadeToScene(1);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void GoToMainMenu(){
        FadeToScene(0);
    }

    public void RetryGame(){
        CardMenu.instance.ResetInventory();
        ScoreManager.Instance.ResetScore();
        CardDeck.instance.ResetDeck();
        FadeToScene(1);
    }

    void FadeToScene(int sceneIndex){
        StartCoroutine(FadeOut(sceneIndex));
        StartCoroutine(FadeAudio(backgroundAudio.GetComponent<AudioSource>(), 2f, 0f));
    }

    IEnumerator FadeOut(int sceneIndex){
        backgroundFader.SetActive(true);
        for(var i = 0; i <= 100; i++){
            yield return new WaitForSeconds(0.025f);
            float alpha = (float)(i*0.03);
            alpha = alpha > 1.0f ? 1.0f : alpha;
            backgroundFader.GetComponent<Image>().color = new Color(1f, 1f, 1f, alpha);
        }
        SceneManager.LoadScene(sceneIndex);
    }

    IEnumerator FadeIn(){
        for(var i = 100; i >= 0; i--){
            yield return new WaitForSeconds(0.025f);
            float alpha = (float)(i*0.01);
            backgroundFader.GetComponent<Image>().color = new Color(1f, 1f, 1f, alpha);
        }
        backgroundFader.SetActive(false);
    }

    IEnumerator FadeAudio(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
