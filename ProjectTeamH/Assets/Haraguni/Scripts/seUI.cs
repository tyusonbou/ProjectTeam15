using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class seUI : MonoBehaviour
{
    private Slider slider;
    private float volume;
    private float moveCursorX;
    public bool isSelect;
    void Start()
    {
        slider = GetComponent<Slider>();
        volume = slider.value;
        isSelect = false;
        moveCursorX = 0.0f;
    }

    void Update()
    {
        if (!isSelect) return;

        if (Input.GetAxisRaw("Vertical")<0)
        {
            isSelect = false;
            return;
        }
        MoveSlider();

    }

    public void MoveSlider()
    {
        moveCursorX += Input.GetAxis("Horizontal")*0.1f;
        slider.value = moveCursorX;
        volume = slider.value;
        Debug.Log("SEMOVING" + volume);
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
