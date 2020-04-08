using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidScript : MonoBehaviour
{
    [SerializeField]
    bool neutral;
    [SerializeField]
    bool deathFrag;
    [SerializeField]
    float acidTimer;

    [SerializeField]
    Color acidColor;
    [SerializeField]
    Color neutralColor;

    [Range(0f, 1f)]
    public float colorTimer;
    [SerializeField]
    AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        neutral = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }

        ToAcid();

        if (deathFrag)
        {
            if (!neutral)
            {
                Destroy(GameObject.Find("Player"));
            }
        }
    }

    //中和から酸へ変化
    private void ToAcid()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (neutral)
        {
            acidTimer += Time.deltaTime;
            colorTimer += (Time.deltaTime)/5;
            if (acidTimer >= 5)
            {
                neutral = false;
            }
            spriteRenderer.color = Color.Lerp(neutralColor, acidColor, curve.Evaluate(colorTimer));
        }
        if (!neutral)
        {
            spriteRenderer.color = acidColor;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //プレイヤーの死亡判定
        if ((col.gameObject.tag == "Player")&&(!neutral))
        {
            Destroy(col.gameObject);
        }
        if((col.gameObject.tag == "Player") && (neutral))
        {
            deathFrag = true;
        }

        //中和剤判定
        if (col.gameObject.tag == "Neutralizer")
        {
            Destroy(col.gameObject);
            if (!neutral)
            {
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.color = neutralColor;
                neutral = true;
                acidTimer = 0;
                colorTimer = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            deathFrag = false;
        }
    }
}
