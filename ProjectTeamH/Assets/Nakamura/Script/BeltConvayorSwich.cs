using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltConvayorSwich : MonoBehaviour
{
    [SerializeField]
    GameObject[] Convayor;

    //スプライト変更用
    [SerializeField]
    private new SpriteRenderer renderer;
    //変更するスプライト
    [SerializeField]
    private Sprite[] spr = new Sprite[2];
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Convayor[0].GetComponent<BeltConveyor>().LRSwich = !Convayor[0].GetComponent<BeltConveyor>().LRSwich;
            Convayor[1].GetComponent<BeltConveyor>().LRSwich = !Convayor[1].GetComponent<BeltConveyor>().LRSwich;

            if (renderer.sprite == spr[1])
            {
                renderer.sprite = spr[0];
            }
            if (renderer.sprite == spr[0])
            {
                renderer.sprite = spr[1];
            }
        }
    }
}
