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

    //バケツ出し
    [SerializeField]
    private AudioClip baketsuClip;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = baketsuClip;
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }//ポーズ時停止//中村望追記
        if (bake.hp<=0)
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

        //Bボタンで使用//中村望//4/27変更
        if (Input.GetButtonDown("B") && bake.coolTime == false)
        {
            //バケツを表示する
            baketsu.SetActive(true);
            audioSource.Play();
        }
        if (bake.IsMax())
        {
            bake.HealthMinus();
        }
    }

}
