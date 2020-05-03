using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidTower : MonoBehaviour
{
    [SerializeField]
    bool isAcidFrag;
    [SerializeField]
    GameObject AcidArea;

    [SerializeField]
    float UpSpeed;
    [SerializeField]
    float UpScale;
    [SerializeField]
    float StopPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }

        if (isAcidFrag)
        {
            AcidArea.transform.position += new Vector3(0, UpSpeed * Time.deltaTime, 0);

            AcidArea.transform.localScale += new Vector3(0, UpScale * Time.deltaTime);
        }

        if (AcidArea.transform.position.y >= StopPos)
        {
            isAcidFrag = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isAcidFrag = true;
        }
    }
}
