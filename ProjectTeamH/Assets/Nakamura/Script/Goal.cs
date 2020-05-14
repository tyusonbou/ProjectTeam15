using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    static bool isGoal;

    [SerializeField]
    private Sprite openSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        isGoal = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }

        if (PlayerController.GetKey())
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = openSprite;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.tag == "Player") && (PlayerController.GetKey() == true))
        {
            isGoal = true;
            Destroy(gameObject);
        }
    }

    public static bool GetGoal()
    {
        return isGoal;
    }
}
