using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSlider : MonoBehaviour
{
    [SerializeField]
    private bgmUI bgm_UI;
    [SerializeField]
    private seUI se_UI;
    void Update()
    {
        if (0 > Input.GetAxisRaw("Vertical"))
        {
            bgm_UI.NotSelect();
            se_UI.Select();
        }
        else if (0 < Input.GetAxisRaw("Vertical"))
        {
            se_UI.NotSelect();
            bgm_UI.Select();
        }
    }
}
