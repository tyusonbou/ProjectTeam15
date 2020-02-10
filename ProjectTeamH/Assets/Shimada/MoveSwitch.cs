//2020/2/7
//動く床のスイッチ
//島田一宏
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSwitch : MonoBehaviour
{
    [SerializeField]
    private int FlagNo;//床とスイッチの紐づけ
    private bool Swich;//オンかオフか

    void Start()
    {
        Swich = false;//最初はオフ
        
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag=="Player")
        {
            if (Swich == false)
            {
                Swich = true;
                FlagManager.Instance.flags[FlagNo] = true;
            }
            else if (Swich == true)
            {
                Swich = false;
                FlagManager.Instance.flags[FlagNo] = false;
            }
        }
        
    }
}