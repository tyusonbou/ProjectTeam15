using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaketuAcid : MonoBehaviour
{
    [SerializeField]
    float DestroyTime;

    float CountTime;

    [SerializeField]
    float UpForce;
    [SerializeField]
    float LRForce;

    Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        CountTime = 0;

        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //時間経過で消滅
        CountTime += Time.deltaTime;

        if (DestroyTime < CountTime)
        {
            Destroy(gameObject);
        }

        ////右向きの時右に飛ぶ
        //if (PlayerController.GetLRState() == "RIGHT")
        //{
        //    rb2d.velocity = Vector2.zero;

        //    rb2d.AddForce(Vector2.up * UpForce);
        //    rb2d.AddForce(Vector2.right * LRForce);
        //}
        ////左向きの時左向き飛ぶ
        //if (PlayerController.GetLRState() == "LEFT")
        //{
        //    rb2d.velocity = Vector2.zero;

        //    rb2d.AddForce(Vector2.up * UpForce);
        //    rb2d.AddForce(Vector2.left * LRForce);
        //}
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Object")
        {
            Destroy(gameObject);

            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
