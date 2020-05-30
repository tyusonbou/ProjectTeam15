using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    [SerializeField]
    private float FloatingSpeed;

    Animator animator;
    AudioSource audioSource;

    [SerializeField]
    AudioClip tramplineSE;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * FloatingSpeed);
        animator.SetTrigger("Spring");
        audioSource.PlayOneShot(tramplineSE);
    }

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * FloatingSpeed);
    //    animator.SetTrigger("Spring");
    //}
}
