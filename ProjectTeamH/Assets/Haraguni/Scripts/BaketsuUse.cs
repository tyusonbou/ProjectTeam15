using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaketsuUse : MonoBehaviour
{
    [SerializeField]
    private GameObject baketsu;
    [SerializeField]
    private Baketsu bake;
    //バケツが壊れた時一度だけバケツを呼び出す（酸を出す）
    private bool isBreak;

    void Update()
    {
        if(bake.hp<=0)
        {
            bake.HpRecovery();
            if (!isBreak)
            {
                baketsu.SetActive(true);
                isBreak = true;
            }
        }
        else
        {
            isBreak = false;
        }

        if(Input.GetKeyDown(KeyCode.Space) && bake.hp>=0)
        {
            //バケツを表示する
            baketsu.SetActive(true);
        }


        if(bake.IsMax())
        {
            bake.HealthMinus();
        }
    }
}
