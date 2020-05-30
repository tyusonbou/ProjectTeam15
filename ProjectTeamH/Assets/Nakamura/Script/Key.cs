using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    Rigidbody2D rb2d;
    AudioSource audioSource;

    [SerializeField]
    AudioClip getKeySE;
    // Start is called before the first frame update
    void Start()
    {
        if (rb2d == null)
        {
            rb2d = GetComponent<Rigidbody2D>();
            audioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }//ポーズ時停止
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController.isGetKey = true;
            gameObject.transform.parent = collision.gameObject.transform;
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            gameObject.transform.localPosition = new Vector3(0, 1f);
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            Destroy(rb2d);
            audioSource.PlayOneShot(getKeySE);
        }
    }
}
