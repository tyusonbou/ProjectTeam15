﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

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

    public float speed;
    private float time;

    [SerializeField]
    AudioClip meltSE;
    [SerializeField]
    AudioClip neutralSE;


    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        neutral = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }

        ToAcid2();
        

        if (deathFrag)
        {
            if (!neutral)
            {
                //Destroy(GameObject.Find("Player"));
                audioSource.Play();
                PlayerController.isDead = true;
            }
        }
    }

    //中和から酸へ変化
    private void ToAcid()
    {
        //SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
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

    private void ToAcid2()
    {
        if (neutral)
        {
            acidTimer += Time.deltaTime;
            //colorTimer += (Time.deltaTime) / 5;
            if (acidTimer >= 2.5f)
            {
                spriteRenderer.color = GetChangeColor(spriteRenderer.color);
            }
            if (acidTimer >= 5)
            {
                neutral = false;
            }
            
        }
        if (!neutral)
        {
            spriteRenderer.color = acidColor;
        }
        
    }

    //Alpha値を更新してColorを返す
    Color GetChangeColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.r = Mathf.Sin(time) * 0.5f + 0.5f;

        return color;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //プレイヤーの死亡判定
        if ((col.gameObject.tag == "Player")&&(!neutral))
        {
            //Destroy(col.gameObject);
            audioSource.PlayOneShot(meltSE);
            PlayerController.isDead = true;
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

                audioSource.PlayOneShot(neutralSE);
            }
        }

        if (col.gameObject.tag == "Key")
        {
            Destroy(col.gameObject);
            audioSource.PlayOneShot(meltSE);
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
