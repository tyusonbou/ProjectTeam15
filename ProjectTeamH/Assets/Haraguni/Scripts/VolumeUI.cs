using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeUI : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    public float soundVolume;
    public bool isSelect;
    [SerializeField]
    private Image handle;

    [SerializeField]
    private AudioMixer mixer;

    //ＢＧＭかＳＥか
    [SerializeField]
    private bool isBGM;

    //音量を保存する。
    [SerializeField]
    private string soundStr;
    private float prefsVolume;

    //斜め入力をすると別のスライダーも動く為、それを防ぐ用
    public bool isMove;
    void Start()
    {
        soundVolume = PlayerPrefs.GetFloat(soundStr,0);
        slider.value = soundVolume;
        isMove = false;
        handle.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        if (isBGM)
        {
            mixer.SetFloat("BGM", slider.value);
        }

        else
        {
            mixer.SetFloat("SE", slider.value);
        }
    }

    void Update()
    {
        //選択中は赤、そうじゃない場合は白
        if (isSelect)
        {
            handle.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
        if (!isSelect) {
            handle.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            return; }
        if (soundVolume <= -80) soundVolume = -80;
        if (soundVolume >= 20) soundVolume = 20;
        slider.value = soundVolume;
        if (Input.GetAxis("Horizontal") > 0)
        {
            soundVolume += 1;
            isMove = true;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            soundVolume -= 1;
            isMove = true;
        }
        else { isMove = false; }

        //スライダーの値を音量にして、音量を保存
        slider.value = soundVolume;
        PlayerPrefs.SetFloat(soundStr, soundVolume);
        PlayerPrefs.Save();

        if (isBGM)
        {
            mixer.SetFloat("BGM", slider.value);
        }
        else
        {
            mixer.SetFloat("SE", slider.value);
        }
    }

    //選択中かどうか（選択中は調整できる）
    public bool IsSelect()
    {
        return isSelect;
    }
    public bool Select()
    {
        return isSelect = true;
    }
    public bool NotSelect()
    {
        return isSelect = false;
    }
    public bool IsMove()
    {
        return isMove;
    }

    //ボリュームを渡す
    public float GetVolume()
    {
        return soundVolume;
    }
}
