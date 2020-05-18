using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeutralizerUI : MonoBehaviour
{
    [SerializeField]
    Text NeutralizerText;

    [SerializeField]
    private Image Image;

    [SerializeField]
    private Sprite[] spr = new Sprite[2];

    // Start is called before the first frame update
    void Start()
    {
        NeutralizerText = GetComponentInChildren<Text>();
        Image = GameObject.Find("XButtonImage").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        NeutralizerText.text = "Neutralizer : " + PlayerController.GetNeutralizer().ToString("00");

        if (Input.GetButtonDown("X"))
        {
            Image.sprite = spr[1];
        }
        if (Input.GetButtonUp("X"))
        {
            Image.sprite = spr[0];
        }
    }
}
