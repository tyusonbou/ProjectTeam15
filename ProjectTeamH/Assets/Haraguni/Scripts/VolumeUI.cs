using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeUI : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    private float volume;
    public bool isSelect;
    [SerializeField]
    private Image handle;
    void Start()
    {
        volume = 100;
        slider.value = 100;
        handle.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
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
        if (volume <= 0) volume = 0;
        if (volume >= 100) volume = 100;
        slider.value = volume;
        if (Input.GetAxis("Horizontal") > 0)
        {
            volume += 1;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            volume -= 1;
        }
        slider.value = volume;
    }

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
}
