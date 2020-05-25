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
    private AudioSource audio;
    [SerializeField]
    private AudioMixer mixer;

    //ＢＧＭかＳＥか
    [SerializeField]
    private bool isBGM;

    //音量を保存する。
    [SerializeField]
    private string soundStr;
    private float prefsVolume;
    void Start()
    {
        soundVolume = PlayerPrefs.GetFloat(soundStr,0);
        slider.value = soundVolume;
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
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            soundVolume -= 1;
        }
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

        //if (isBGM) mixer.SetFloat("bgm", Mathf.Clamp(volumeDB, -80.0f, 0.0f));
        //else mixer.SetFloat("se", Mathf.Clamp(volumeDB, -80.0f, 0.0f));

        //if (isBgm) mixer.SetFloat("bgm", mixVor);
        //else mixer.SetFloat("se", mixVor);
        //float ConvertVolume2dB(float volume) => 20f * Mathf.Log10(Mathf.Clamp(volume, 0f, 1f));
        //audio.volume = slider.value / 100;
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

    //ボリュームを渡す
    public float GetVolume()
    {
        return soundVolume;
    }
}
