using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BakestuSlider : MonoBehaviour
{
    public Slider slider;
    public Baketsu bakestu;
    public Image gage;

    private GameObject player;
    public Vector2 playerVec;
    
    [SerializeField]
    private Image Image;
    [SerializeField]
    private Image ImageBake;
    [SerializeField]
    private Image Panel;

    [SerializeField]
    private Sprite[] spr = new Sprite[4];

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("BaketuSlider").GetComponent<Slider>();
        gage = GameObject.Find("BaketsuFill").GetComponent<Image>();
        Image = GameObject.Find("BButtonImage").GetComponent<Image>();
        ImageBake = GameObject.Find("ImageBake").GetComponent<Image>();
        Panel = GameObject.Find("PanelBake").GetComponent<Image>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }
        SliderAlpha();
        //bakestu = GameObject.Find("baketsu").GetComponent<Baketsu>();
        slider.value = bakestu.hp;

        if (bakestu.coolTime != true)
        {
            //SliderControll();
            gage.color = new Color(255, 255, 255);
        }


        if (bakestu.coolTime == true)
        {
            gage.color = new Color(255, 0, 0);

        }

        if (bakestu.isMax == true)
        {
            ImageBake.color = Color.yellow;
        }
        if (bakestu.isMax == false)
        {
            ImageBake.color = Color.white;
        }

        if (Input.GetButtonDown("B"))
        {
            Image.sprite = spr[1];
        }
        if (Input.GetButtonUp("B")) 
        {
            Image.sprite = spr[0];
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

    void SliderAlpha()
    {
        if (player.transform.position.x < playerVec.x && player.transform.position.y > playerVec.y)
        {
            slider.image.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
            Image.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
            ImageBake.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
            //Panel.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
        }
        else
        {
            slider.image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            Image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            ImageBake.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            //Panel.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
