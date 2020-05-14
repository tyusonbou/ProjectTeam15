using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeZoneScript : MonoBehaviour
{
    public GameObject gameOb;
    // Start is called before the first frame update
    void Start()
    {
        gameOb = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "SafeZone")
        {
            gameOb.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "SafeZone")
        {
            gameOb.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "SafeZone")
        {
            gameOb.SetActive(true);
        }
    }
}
