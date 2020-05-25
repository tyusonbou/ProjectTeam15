using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerAcid : MonoBehaviour
{
    [SerializeField]
    AudioClip meltSE;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(meltSE);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(meltSE);
        }
    }
}
