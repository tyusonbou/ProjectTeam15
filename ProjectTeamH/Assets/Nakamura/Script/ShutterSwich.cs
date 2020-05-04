using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterSwich : MonoBehaviour
{
    [SerializeField]
    GameObject Shutter;
    // Start is called before the first frame update
    void Start()
    {
        
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
        }
    }
}
