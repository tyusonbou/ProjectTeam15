using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaketsuUse : MonoBehaviour
{
    private GameObject baketsu;
    private Baketsu bake;
    void Start()
    {
        //使うバケツを取得する
        baketsu = gameObject.transform.Find("baketsu").gameObject;
        bake = baketsu.GetComponent<Baketsu>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
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
