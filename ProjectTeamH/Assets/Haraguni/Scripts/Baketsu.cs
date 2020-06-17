using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baketsu : MonoBehaviour
{
    //スプライト変更用
    [SerializeField]
    private SpriteRenderer renderer;
    //変更するスプライト
    [SerializeField]
    private Sprite[] spr = new Sprite[2];

    public bool isMax; //酸を汲んだか判定

    //バケツから出す酸
    [SerializeField]
    private GameObject acid;
    [SerializeField]
    private float useTime; //汲む時間・零す時間
    //汲み終わる時間・零し終わる時間
    [SerializeField]
    private float useEndTime;

    private Vector3 pos;
    private GameObject parentObj;   //親（プレイヤー）
    private Vector3 parentVec;      //親（プレイヤー）の位置

    //最初の耐久値
    [SerializeField]
    private float setHp;
    public float hp;            //耐久値

    //耐久値が０になってから回復するまでの時間
    [SerializeField]
    private float reUseTime;
    private float recoveryTime; //耐久値が回復してる時間

    public bool coolTime;//バケツが壊れてる状態//中村望s追加
    private bool isOut;//出したバケツが酸に触れてない場合、戻すためのbool

    //バケツ効果音
    [SerializeField]
    private AudioClip acidInAudio, acidOutAudio,baketsuInAudio;
    [SerializeField]
    private AudioSource audioSource;
    void Start()
    {
        isMax = false;
        isOut = false;

        useTime = 0.0f;
        recoveryTime = 0.0f;
        hp = setHp;
        coolTime = false;

        GetComponent<BoxCollider2D>().enabled = false;

        pos = transform.position;
        parentObj = transform.parent.gameObject;
        this.gameObject.SetActive(false);
    }

    void Update()
    {

        parentVec = parentObj.transform.position;
        pos = new Vector3(parentVec.x, parentVec.y, parentVec.z);
        if (hp <= 0) {
            //耐久値が無くなったら、一度だけ呼び出して酸を出して酸を入れてない状態にする。
            Spill();
            return;
        } 

        if (!isMax) {
            Pump(); 
        }
        else {
            Spill();
        }
    }

    //酸を汲む処理
    void Pump()
    {
        useTime += Time.deltaTime;
        pos.y += Time.deltaTime * 0.8f;
        transform.position = pos;
        if (useTime >= useEndTime)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            transform.position = pos;
            useTime = 0.0f;
            isOut = true;
        }
        if(isOut)
        {
            useTime += Time.deltaTime;
            if(useTime>=useEndTime)
            {
                audioSource.PlayOneShot(baketsuInAudio);
                GetComponent<BoxCollider2D>().enabled = false;
                transform.position = pos;
                useTime = 0.0f;
                isOut = false;
                this.gameObject.SetActive(false);
            }
        }
    }

    //酸を零す処理
    void Spill()
    {
        GetComponent<BoxCollider2D>().enabled = false;
        renderer.sprite = spr[1];
        useTime += Time.deltaTime;
        pos.y += Time.deltaTime * 0.8f;
        transform.position = pos;
        if (useTime >= useEndTime)
        {
            audioSource.PlayOneShot(acidOutAudio);
            useTime = 0.0f;
            transform.position = pos;
            //酸をバケツの位置に生成する
            GameObject A = Instantiate(acid) as GameObject;
            A.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            audioSource.PlayOneShot(baketsuInAudio);
            //汲んでない状態にしてオブジェクトを隠す
            isMax = false;
        renderer.sprite = spr[0];
            isOut = false;
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //酸を汲み取る
        if (col.gameObject.tag == "Acid")
        {
            if (isMax) return;
            isOut = false;
            audioSource.PlayOneShot(acidInAudio);
            isMax = true;
                transform.position = pos;
            audioSource.PlayOneShot(baketsuInAudio);
            useTime = 0.0f;
            this.gameObject.SetActive(false);
        }
    }

    //耐久値減少
    public float HealthMinus()
    {
        hp-=Time.deltaTime;
        return hp;
    }
    public bool IsMax()
    {
        return isMax;
    }
    public void HpRecovery()
    {
        if (hp <= 0)
        {
            coolTime = true;
            hp=0;
            recoveryTime += Time.deltaTime;
            if(recoveryTime>=reUseTime)
            {
                hp = setHp;
                coolTime = false;
            }
        }
    }

}