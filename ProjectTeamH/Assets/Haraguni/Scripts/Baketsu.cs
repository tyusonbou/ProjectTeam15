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
    private float useTime; //汲む時間・零す時間
    //汲み終わる時間・零し終わる時間
    [SerializeField]
    private float useEndTime;

    private Vector3 pos;
    private GameObject parentObj;   //親（プレイヤー）
    private Vector3 parentVec;      //親（プレイヤー）の位置

    public float hp;
    void Start()
    {
        isMax = false;

        useTime = 0.0f;

        GetComponent<BoxCollider2D>().enabled = false;

        pos = transform.position;
        parentObj = transform.parent.gameObject;
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if(hp<=0)  Destroy(this.gameObject); 
        parentVec = parentObj.transform.position;
        pos = new Vector3(parentVec.x + 0.64f, parentVec.y, parentVec.z); // +0.64fはプレイヤーとの距離（仮）
        if (!isMax) { Pump(); }
        if (isMax) { Spill(); }
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
            pos.y = 0;
            transform.position = pos;
            useTime = 0.0f;
        }
    }

    //酸を零す処理
    void Spill()
    {
        useTime += Time.deltaTime;
        pos.y += Time.deltaTime * 0.8f;
        transform.position = pos;
        if (useTime >= useEndTime)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            useTime = 0.0f;

            //汲む前の見た目に戻す
            renderer.sprite = spr[0];
            pos.y = 0;
            transform.position = pos;
            //酸をバケツの位置に生成する
            GameObject A = Instantiate(acid) as GameObject;
            A.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            //汲んでない状態にしてオブジェクトを隠す
            isMax = false;
            this.gameObject.SetActive(false);
        }
        }

    void OnTriggerEnter2D(Collider2D col)
        {
        //酸に触れたら酸を消す
        if (col.gameObject.tag == "Acid" && !isMax)
            {
                isMax = true;
                Destroy(col.gameObject);
                renderer.sprite = spr[1];
                pos.y = 0.0f;
                transform.position = pos;
                this.gameObject.SetActive(false);
            }

            //酸以外のオブジェクトに触れた場合、そのまま戻す
            else
            {
                renderer.sprite = spr[0];
                pos.y = 0.0f;
                GetComponent<BoxCollider2D>().enabled = false;
                transform.position = pos;
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
    
}