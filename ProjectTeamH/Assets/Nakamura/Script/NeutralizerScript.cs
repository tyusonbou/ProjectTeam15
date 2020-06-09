using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralizerScript : MonoBehaviour
{
    [SerializeField]
    static bool isGround;
    // Start is called before the first frame update
    void Start()
    {
        isGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "Player") && (isGround == true)) 
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }

    public static bool ReturnGround()
    {
        return isGround;
    }
}
