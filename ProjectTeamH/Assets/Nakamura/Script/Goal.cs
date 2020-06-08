using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static bool isGoal;

    //public GameObject gameObject1;
    //public GameObject gameObject2;

    [SerializeField]
    AudioClip openSE;

    Animator animator;
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        isGoal = false;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Mathf.Approximately(Time.timeScale, 0f)) { return; }

        if (PlayerController.GetKey() && GameObject.Find("Key") == null)
        {
            animator.SetBool("Open", true);
        }
        if (isGoal)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player") && (PlayerController.GetKey() == true) && (PlayerController.GetGround() == true)) 
        {
            if (Input.GetButtonDown("A"))
            {
                isGoal = true;

                audioSource.PlayOneShot(openSE);
            }
            animator.SetBool("Open", true);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player") && (PlayerController.GetKey() == true) && (PlayerController.GetGround() == true))
        {
            if (Input.GetButtonDown("A"))
            {
                isGoal = true;

                audioSource.PlayOneShot(openSE);
            }
            animator.SetBool("Open", true);
        }
    }

    public static bool GetGoal()
    {
        return isGoal;
    }
}
