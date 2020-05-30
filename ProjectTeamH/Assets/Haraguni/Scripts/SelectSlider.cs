using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSlider : MonoBehaviour
{
    [SerializeField]
    private VolumeUI[] volume_UI=new VolumeUI[2];
    //選択した時のＳＥ（ＳＥ音量確認用）
    [SerializeField]
    private AudioSource audio;

    private bool sel;

    void Start()
    {
        sel = false;
        volume_UI[0].Select();
        volume_UI[1].NotSelect();
    }

    void Update()
    {
        if (0 > Input.GetAxisRaw("Vertical") && !sel && ( !volume_UI[0].IsMove() || !volume_UI[1].IsMove() ) )
        {
            volume_UI[0].NotSelect();
            volume_UI[1].Select();
            sel = true;
            audio.Play();
        }
        else if (0 < Input.GetAxisRaw("Vertical") && sel && (!volume_UI[0].IsMove() || !volume_UI[1].IsMove() ) )
        {
            volume_UI[1].NotSelect();
            volume_UI[0].Select();
            sel = false;
            audio.Play();
        }
    }
}
