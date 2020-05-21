using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    
    public Image gage;


    [SerializeField]
    private Image Image;

    [SerializeField]
    private Sprite[] spr = new Sprite[2];

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        gage = GameObject.Find("Fill").GetComponent<Image>();
        Image = GameObject.Find("RButtonImage").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }


        slider.value = PlayerController.umbrellaHP;

        //if (player.isCoolTime != true)
        //{
        //    SliderControll();
        //    gage.color = new Color(255, 255, 255);
        //}

        
        //if (player.isCoolTime == true)
        //{
        //    gage.color = new Color(255, 0, 0);
            
        //}

        //if (Input.GetButtonDown("RB"))
        //{
        //    Image.sprite = spr[1];
        //}
        //if (Input.GetButtonUp("RB"))
        //{
        //    Image.sprite = spr[0];
        //}
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
