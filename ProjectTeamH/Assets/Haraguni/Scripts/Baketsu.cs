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
    private Sprite[] spr=new Sprite[2];
    private bool isMax; //酸を汲んだか判定
    //バケツから出す酸
    [SerializeField]
    private GameObject acid;
    private float hp; //耐久値
    private float useTime; //汲む時間・零す時間
    //汲み終わる時間・零し終わる時間
    [SerializeField]
    private float useEndTime;
    void Start()
    {
        isMax = false;
        useTime = 0.0f;
        GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.SetActive(false);
    }
 
    void Update()
    {
            if(!isMax) Pump();
            if(isMax) Spill();
    }

    //酸を汲む処理
    void Pump()
    {
            useTime += Time.deltaTime;
                if (useTime>= useEndTime)
                {
                GetComponent<BoxCollider2D>().enabled = true;
            transform.Rotate(0, 1, 0);
                useTime = 0.0f;
            }
    }

    //酸を零す処理
    void Spill()
    {
        useTime += Time.deltaTime;
        if (useTime >= useEndTime)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            useTime = 0.0f;

        //汲む前の見た目に戻す
        renderer.sprite = spr[0];
        //酸をバケツの位置に生成する
        GameObject A = Instantiate(acid) as GameObject;
        A.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //汲んでない状態にしてオブジェクトを隠す
        isMax = false;
            transform.Rotate(0, -1, 0);
        this.gameObject.SetActive(false);

        }
    }

    //耐久値が減る処理
    void MinusHealth()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //酸に触れたら酸を消す
        if (col.gameObject.tag == "Acid" && !isMax)
        {
            isMax = true;
            Destroy(col.gameObject);
            renderer.sprite = spr[1];
            this.gameObject.SetActive(false);
        }

        //酸以外のオブジェクトに触れた場合、そのまま戻す
        else
        {
            renderer.sprite = spr[0];
            GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.SetActive(false);
        }
    }
}
