using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider slider;
    
    public Image gage;

    PlayerController playerScript;

    private GameObject player;
    public Vector2 playerVec;

    [SerializeField]
    private Image Image;
    [SerializeField]
    private Image ImageUm;
    [SerializeField]
    private Image Panel;

    [SerializeField]
    private Sprite[] spr = new Sprite[2];

    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        gage = GameObject.Find("Fill").GetComponent<Image>();
        Image = GameObject.Find("RButtonImage").GetComponent<Image>();
        ImageUm = GameObject.Find("ImageUm").GetComponent<Image>();
        Panel = GameObject.Find("PanelBake").GetComponent<Image>();
        player = GameObject.Find("Player");

        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }
        SliderAlpha();
        slider.value = PlayerController.umbrellaHP;

        if (!PlayerController.GetCoolTime())
        {
            SliderControll();
            gage.color = new Color(255, 255, 255);
        }


        if (PlayerController.GetCoolTime())
        {
            gage.color = new Color(255, 0, 0);

        }

        if (Input.GetButtonDown("RB"))
        {
            Image.sprite = spr[1];
        }
        if (Input.GetButtonUp("RB"))
        {
            Image.sprite = spr[0];
        }
    }

    void SliderControll()
    {
        if (slider.value >= 7)
        {
            slider.image.color = new Color(255, 255, 255);
            ImageUm.color = Color.white;
        }
        else if (slider.value >= 3 && slider.value < 7)
        {
            slider.image.color = new Color(255, 255, 0);
            ImageUm.color = Color.yellow;
        }
        else if (slider.value <= 3)
        {
            slider.image.color = new Color(255, 0, 0);
            ImageUm.color = Color.red;
        }
    }

    void SliderAlpha()
    {
        if (player.transform.position.x < playerVec.x && player.transform.position.y > playerVec.y)
        {
            slider.image.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
            Image.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
            ImageUm.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
            //Panel.color = new Color(1.0f, 1.0f, 1.0f, 0.25f);
        }
        else
        {
            slider.image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            Image.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            ImageUm.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            //Panel.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
