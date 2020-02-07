//2020/2/7
//動く床のスイッチ
//島田一宏
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSwitch : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (FlagManager.Instance.flags[0] == false)
            {
                FlagManager.Instance.flags[0] = true;
            }
            else if (FlagManager.Instance.flags[0] == true)
            {
                FlagManager.Instance.flags[0] = false;
            }
        }
    }
}
