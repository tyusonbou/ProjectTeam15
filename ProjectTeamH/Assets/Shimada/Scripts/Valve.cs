//2020/5/25
//酸の出し入れをするバルブ
//島田一宏
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valve : MonoBehaviour
{
    private bool Swich;//オンかオフか
    [SerializeField]
    private GameObject Acid;//酸のオブジェクト
    void Start()
    {
        Swich = false;//最初はオフ 
        Acid.gameObject.SetActive(false);

    }

    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //プレイヤーが触れたら
        if (col.gameObject.tag == "Player")
        {
            if (Swich == false)
            {
                Swich = true;//スイッチオン
                Acid.gameObject.SetActive(true);
            }
            else if (Swich == true)
            {
                Swich = false;//スイッチオフ
                Acid.gameObject.SetActive(false);
            }
        }
    }
}
