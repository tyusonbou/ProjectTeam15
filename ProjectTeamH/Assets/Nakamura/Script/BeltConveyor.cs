using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltConveyor : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    /*static*/ bool LRSwich;//左右切り替え

    float LR;

    // Start is called before the first frame update
    void Start()
    {
        LR = 1;//初期状態は右
    }

    // Update is called once per frame
    void Update()
    {
        if(LRSwich)
        {
            LR = -1;//左に変更
        }
        else
        {
            LR = 1;//右に変更
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        col.gameObject.transform.position += new Vector3(speed * Time.deltaTime * LR, 0, 0);
    }

    //public static bool ChangeLR()
    //{
    //    return LRSwich;
    //}
}
