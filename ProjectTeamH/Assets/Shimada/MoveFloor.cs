//2020/2/7
//移動する床
//島田一宏
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFloor : MonoBehaviour
{
    //変数定義
    private Rigidbody2D rb;
    private Vector2 defaultpass;

    void Start()
    {
        FlagManager.Instance.ResetFlags();
        rb = GetComponent<Rigidbody2D>();
        defaultpass = transform.position;
        
    }

    void Update()
    {
        Time.timeScale = 0.0f;
        if (FlagManager.Instance.flags[0] == true)
        {
            Time.timeScale = 1.0f;
            //X座標のみ横移動
            rb.transform.position =new Vector2(defaultpass.x + Mathf.PingPong(Time.time, 3), defaultpass.y);
        }
    }
}
