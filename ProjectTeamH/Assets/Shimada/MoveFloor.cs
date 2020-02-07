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
    private float moveTime;//時間
    [SerializeField]
    private float speed;//動く速さ
    [SerializeField]
    private float length;//動く範囲
    void Start()
    {
        FlagManager.Instance.ResetFlags();
        rb = GetComponent<Rigidbody2D>();
        defaultpass = transform.position;
        
    }

    void Update()
    {
        
        if (FlagManager.Instance.flags[0] == true)
        {
            moveTime += Time.deltaTime;
            //X座標のみ横移動
            rb.transform.position =new Vector2(defaultpass.x + Mathf.PingPong(moveTime*speed, length), defaultpass.y);
            
        }
        
    }
}
