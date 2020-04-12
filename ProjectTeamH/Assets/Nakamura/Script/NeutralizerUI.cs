using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeutralizerUI : MonoBehaviour
{
    [SerializeField]
    Text NeutralizerText;

    // Start is called before the first frame update
    void Start()
    {
        NeutralizerText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        NeutralizerText.text = "Neutralizer : " + PlayerController.GetNeutralizer().ToString("00");
    }
}
