using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaketsuUse : MonoBehaviour
{
    private GameObject baketsu;
    void Start()
    {
        //使うバケツを取得する
        baketsu = gameObject.transform.Find("baketsu").gameObject;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //バケツを表示する
            baketsu.SetActive(true);
        }
    }
}
