//2020/04/17
//ボタン
//島田一宏
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour
{
    int number;
    public AudioClip sound;
    AudioSource audioSource;

    float fadeSpeed = 0.02f; //透明度が変わるスピード
    float red, green, blue, alpha; //パネル関係
    public bool isFadeOut = false;//フェードアウト
    public bool isFadeIn = false;//フェードイン

    private string ChangeSceneName;
    public int ChangeScene;
    Image fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        audioSource = GetComponent<AudioSource>();
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alpha = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFadeIn)
        {
            StartFadeIn();
        }
        if(isFadeOut)
        {
            StartFadeOut();
        }
    }
    public void OnClick()
    {
        audioSource.PlayOneShot(sound);
        isFadeOut = true;
        if (ChangeScene == 1)
        {
            ChangeSceneName = "Stage1";
        }
        if (ChangeScene == 2)
        {
            ChangeSceneName = "StageSelect";
        }
        if (ChangeScene == 3)
        {
            ChangeSceneName = "SoundUI";
        }
        if (ChangeScene == 4)
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
        }
        if (ChangeScene == 5)
        {
            ChangeSceneName = "Title";
        }
    }

    void StartFadeIn()
    {
        alpha -= fadeSpeed;
        SetAlpha();
        if(alpha <= 0)
        {
            isFadeIn = false;
            fadeImage.enabled = false;
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;
        alpha += fadeSpeed;
        SetAlpha();
        if(alpha >= 1)
        {
            isFadeOut = false;

            SceneManager.LoadScene(ChangeSceneName);
            
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alpha);
    }

    

}
