using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static bool isGoal;

    public GameObject gameObject1;
    public GameObject gameObject2;

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
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }

        if (GameObject.Find("Key") == null)
        {
            animator.SetBool("Open", true);
            gameObject1.SetActive(false);
            gameObject2.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player") && (PlayerController.GetKey() == true))
        {
            isGoal = true;
            animator.SetBool("Open", true);
            audioSource.PlayOneShot(openSE);
            
        }
    }

    public static bool GetGoal()
    {
        return isGoal;
    }
}
