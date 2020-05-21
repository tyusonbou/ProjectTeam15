using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    [SerializeField]
    float umbrellaBraekSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            if (PlayerController.GetUmbrella() == true)
            {
                PlayerController.umbrellaHP -= umbrellaBraekSpeed;
            }
            
            if (PlayerController.GetUmbrella() == false) 
            {
                Destroy(other.gameObject);
            }
            
        }
    }
}
