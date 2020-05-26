using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolineScript : MonoBehaviour
{
    [SerializeField]
    private float FloatingSpeed;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * FloatingSpeed);
        animator.SetTrigger("Spring");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * FloatingSpeed);
        animator.SetTrigger("Spring");
    }
}
