using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    [SerializeField]
    float umbrellaBraekSpeed;
    [SerializeField]
    AudioClip umRainedSE;
    [SerializeField]
    AudioClip meltSE;
    
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
                audioSource.PlayOneShot(umRainedSE);
            }
            
            if (PlayerController.GetUmbrella() == false) 
            {
                Destroy(other.gameObject);
                audioSource.PlayOneShot(meltSE);
            }
            
        }
    }
}
