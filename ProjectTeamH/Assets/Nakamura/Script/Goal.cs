using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.GetKey())
        {
            //Color32 color = new Color32(0, 255, 255,0);
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color= new Color32(0, 255, 255, 255);
        }
        if (PlayerController.GetGoal())
        {
            Destroy(gameObject);
        }
    }
}
