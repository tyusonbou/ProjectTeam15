using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterSwich : MonoBehaviour
{
    [SerializeField]
    GameObject Shutter;

    //スプライト変更用
    [SerializeField]
    private new SpriteRenderer renderer;
    //変更するスプライト
    [SerializeField]
    private Sprite[] spr = new Sprite[2];

    AudioSource audioSource;
    [SerializeField]
    AudioClip ButtonSE;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Shutter.GetComponent<ShutterScript>().OpenFrag = true;
            renderer.sprite = spr[1];
            audioSource.PlayOneShot(ButtonSE);
        }
    }
}
