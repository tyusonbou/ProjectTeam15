using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BakestuSlider : MonoBehaviour
{
    public Slider slider;
    public Baketsu bakestu;
    public Image gage;
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("BaketuSlider").GetComponent<Slider>();
        gage = GameObject.Find("BaketsuFill").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }

        //bakestu = GameObject.Find("baketsu").GetComponent<Baketsu>();
        slider.value = bakestu.hp;

        if (bakestu.coolTime != true)
        {
            SliderControll();
            gage.color = new Color(255, 255, 255);
        }


        if (bakestu.coolTime == true)
        {
            gage.color = new Color(255, 0, 0);

        }
    }

    void SliderControll()
    {
        if (slider.value >= 7)
        {
            slider.image.color = new Color(0, 255, 0);
        }
        else if (slider.value >= 3 && slider.value < 7)
        {
            slider.image.color = new Color(255, 255, 0);
        }
        else if (slider.value <= 3)
        {
            slider.image.color = new Color(255, 0, 0);
        }
    }
}
