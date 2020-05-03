using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSlider : MonoBehaviour
{
    [SerializeField]
    private bgmUI bgm_UI;
    [SerializeField]
    private seUI se_UI;
    private bool selBGM;
    void Start()
    {
        selBGM = true;
    }

    void Update()
    {
        if (!bgm_UI.IsSelect())
        {
            Debug.Log("SELECTSE");
            se_UI.Select();
        }
        if(!se_UI.IsSelect())
        {
            se_UI.NotSelect();
            bgm_UI.Select();
        }

    }
}
