using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bgm : MonoBehaviour
{
    private Slider slider;
    private float volume;
    private float moveCursorX,moveCursorY;
    public bool isSelect;
    void Start()
    {
        slider = GetComponent <Slider>();
        volume = slider.value;
        isSelect = true;
        moveCursorX = 0.0f;
        moveCursorY = 0.0f;
    }

    void Update()
    {
        moveCursorY += Input.GetAxis("Horizontal");

        moveCursorX += Input.GetAxis("Vertical");
        if(moveCursorX!=0.0f){
            MoveSlider();
        }

    }

    public void MoveSlider()
    {
        Debug.Log("move");
    }

    public bool IsSelect()
    {
        return isSelect;
    }
}
