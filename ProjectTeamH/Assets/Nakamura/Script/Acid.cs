using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    [SerializeField]
    byte r, g, b;
    [SerializeField]
    bool neutral;
    // Start is called before the first frame update
    void Start()
    {
        neutral = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (neutral)
        {
            StartCoroutine("ToAcid");
        }
    }

    private IEnumerator ToAcid()
    {
        yield return new WaitForSeconds(5.0f);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color32(255, 255, 0, 255);
        neutral = false;

        yield break;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.tag == "Player")&&(!neutral))
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Neutralizer")
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color32(0, 255, 100, 255);
            neutral = true;
            Destroy(col.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if ((col.gameObject.tag == "Player") && (!neutral))
        {
            Destroy(col.gameObject);
        }
    }
}
