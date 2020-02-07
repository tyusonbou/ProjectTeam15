//2020/2/7
//動く床のスイッチ
//島田一宏
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSwitch : MonoBehaviour
{
    [SerializeField]
    private int FlagNo;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (FlagManager.Instance.flags[FlagNo] == false)
            {
                FlagManager.Instance.flags[FlagNo] = true;
            }
            else if (FlagManager.Instance.flags[FlagNo] == true)
            {
                FlagManager.Instance.flags[FlagNo] = false;
            }
        }
    }
}
