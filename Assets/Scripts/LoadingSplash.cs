using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSplash : MonoBehaviour
{
    //Goes onto UI Object
    [SerializeField]
    Slider loadingSlider;
    [SerializeField]
    RectTransform loadingSplash;

    float loadBarTimer = 2f;
    float fadeTimer = 0.5f;

    void Start()
    {
        LoadScreen();
    }
    public void LoadScreen()
    {
        StartCoroutine(LoadBar(loadBarTimer));    
    }

    IEnumerator LoadBar(float duration)
    {
        float timer = 0f;
        float percentage;
        while(timer < duration)
        {
            timer += Time.deltaTime;
            percentage = timer / duration;
            loadingSlider.value = percentage;
            yield return 0;
        }
        loadingSlider.value = 1f;
        yield return StartCoroutine(Fade(fadeTimer));
    }
    IEnumerator Fade(float fadeTime)
    {
        float timer = 0f;
        while (timer < fadeTime)
        {
            timer += Time.deltaTime;
            yield return 0;
        }
        //Make this vanish
        loadingSplash.gameObject.SetActive(false);
        //Trigger BGMusic
        OnLoadTriggers();
    }
    void OnLoadTriggers()
    {
        SoundManager.instance.BGMusicStart();
    }
}
