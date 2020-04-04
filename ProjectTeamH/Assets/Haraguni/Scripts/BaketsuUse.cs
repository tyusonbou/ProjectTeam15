using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaketsuUse : MonoBehaviour
{
    private GameObject baketsu;
    void Start()
    {
        baketsu = gameObject.transform.Find("baketsu").gameObject;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            baketsu.SetActive(true);
        }
    }
}
