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
    private bool isMax;
    private bool isUse;
    //バケツから出す酸
    [SerializeField]
    private GameObject acid;
    private float hp; //耐久値
    private float pumpTime;
    void Start()
    {
        isMax = false;
        isUse = false;
        pumpTime = 0.0f;
        GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.SetActive(false);
    }
 
    void Update()
    {
            
        Pump();
    }

    void Spill()
    {
            renderer.sprite = spr[0];

        GameObject A = Instantiate(acid) as GameObject;
        A.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        isMax = false;
        GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.SetActive(false);
    }
    void Pump()
    {
        //酸を汲む時
        if(!isMax)
        {
            pumpTime += Time.deltaTime;
                if (pumpTime>=1.0f)
                {
                GetComponent<BoxCollider2D>().enabled = true;
                pumpTime = 0.0f;
            }
        }
        //酸を零す時
        else if(isMax)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            pumpTime += Time.deltaTime;
            if (pumpTime>=1.0f)
                {
                GetComponent<BoxCollider2D>().enabled = true;
                pumpTime = 0.0f;
                Spill();
            }
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
            this.gameObject.SetActive(false);
        }
        else
        {
            renderer.sprite = spr[0];
            GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.SetActive(false);
        }
    }
}
