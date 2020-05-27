using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltConveyor : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    public bool LRSwich;//左右切り替え

    Animator animator;

    //public GameObject allow1;
    //public GameObject allow2;

    //private  SpriteRenderer renderer1;
    //private  SpriteRenderer renderer2;

    float LR;

    // Start is called before the first frame update
    void Start()
    {
        LR = 1;//初期状態は右

        animator = GetComponent<Animator>();

        //renderer1 = allow1.GetComponent<SpriteRenderer>();
        //renderer2 = allow2.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", speed);

        if(LRSwich)
        {
            LR = -1;//左に変更

            gameObject.transform.localRotation = new Quaternion(0, 180, 0, 0);
            //renderer1.flipX = true;
            //renderer2.flipX = true;
        }
        else
        {
            LR = 1;//右に変更
            gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
            //renderer1.flipX = false;
            //renderer2.flipX = false;
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        col.gameObject.transform.position += new Vector3(speed * Time.deltaTime * LR, 0, 0);
    }

   
}
