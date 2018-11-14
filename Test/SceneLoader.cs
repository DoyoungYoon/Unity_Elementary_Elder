using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    
    
    public Image SceneFadeIO = null;
    public float fadeTime = 0.015f;

    int S_width = Screen.width;
    int S_height = Screen.height;
    public Color fadeColor = Color.black;

    string NextSceneName = null;
    
    void Start()
    {
        SceneFadeIO = GameObject.FindGameObjectWithTag("SceneFadeIOTag").GetComponent<Image>();
        SceneFadeIO.rectTransform.localPosition = new Vector2(0, 0); 
        SceneFadeIO.rectTransform.sizeDelta = new Vector2(S_width, S_height);
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut ()
    {
        if (SceneFadeIO.color.a >= 0)
        {
            fadeColor.a -= 0.01f;
            SceneFadeIO.color = fadeColor;
            yield return new WaitForSeconds(fadeTime);
            StartCoroutine("FadeOut");
            if(SceneFadeIO.color.a<0)
            {
                SceneFadeIO.gameObject.SetActive(false);
            }
        }
    }


    IEnumerator FadeIn()
    {
        if (SceneFadeIO.color.a <= 1)
        {
            fadeColor.a += 0.01f;
            SceneFadeIO.color = fadeColor;
            yield return new WaitForSeconds(fadeTime);
            StartCoroutine("FadeIn");
            if (SceneFadeIO.color.a > 1)
            {
                SceneManager.LoadScene(NextSceneName);

                
            }
        }
    }

    IEnumerator FadeInWithoutLoadScene()
    {
        if (SceneFadeIO.color.a <= 1)
        {
            fadeColor.a += 0.01f;
            SceneFadeIO.color = fadeColor;
            yield return new WaitForSeconds(fadeTime);
            StartCoroutine("FadeInWithoutLoadScene");
        }
    }

    public void ChangeScenes()
    {
        SceneFadeIO.gameObject.SetActive(true);
        NextSceneName = "mainScene";
        StartCoroutine("FadeIn");

    }

    public void StartFadeInWithoutLoadScene()
    {
        SceneFadeIO.gameObject.SetActive(true);
        StartCoroutine("FadeInWithoutLoadScene");
    }

    public void StartFadeOut()
    {
        StartCoroutine("FadeOut");
    }
}
