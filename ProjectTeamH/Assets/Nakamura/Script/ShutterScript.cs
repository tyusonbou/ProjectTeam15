using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutterScript : MonoBehaviour
{
    [SerializeField]
    private GameObject ShutterR;
    [SerializeField]
    private GameObject ShutterL;

    public float OpenSpeed;

    public float OpenAreaR;
    public float OpenAreaL;

    
    public bool OpenFrag;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }//ポーズ停止用

        if (PlayerController.GetKey())
        {
            OpenFrag = true;            
        }

        if (OpenFrag)
        {
            if (ShutterR.transform.position.x < OpenAreaR)
            {
                ShutterR.transform.position += new Vector3(OpenSpeed * Time.deltaTime, 0, 0);
            }
            if (ShutterL.transform.position.x > OpenAreaL)
            {
                ShutterL.transform.position -= new Vector3(OpenSpeed * Time.deltaTime, 0, 0);
            }
                
        }
    }
}
