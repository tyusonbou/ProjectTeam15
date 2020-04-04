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
    void Start()
    {
        isMax = false;
        isUse = false;
            GetComponent<BoxCollider2D>().enabled = false;
        this.gameObject.SetActive(false);
    }
 
    void Update()
    {
        Rotate();
    }

    void Spill()
    {
            renderer.sprite = spr[0];
            GameObject A = Instantiate(acid) as GameObject;
            isMax = false;
        this.gameObject.SetActive(false);
    }
    void Rotate()
    {
        if(transform.rotation.z<0 && !isMax)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            transform.Rotate(0, 0, 10 * Time.deltaTime * 10);
                if (transform.rotation.z >= 0)
                {
            GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else if(transform.rotation.z>=-90 && isMax)
        {
            transform.Rotate(0, 0, -10 * Time.deltaTime * 10);
                if (transform.rotation.z < -90)
                {
                Spill();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Acid" && !isMax)
        {
            renderer.sprite = spr[1];
            isMax = true;
            Destroy(col.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}
