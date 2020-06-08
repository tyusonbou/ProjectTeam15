using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="Ground")
        {
            //gameObject.GetComponent<Collider2D>().usedByEffector = false;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            //gameObject.GetComponent<Collider2D>().usedByEffector = false;
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }
}
