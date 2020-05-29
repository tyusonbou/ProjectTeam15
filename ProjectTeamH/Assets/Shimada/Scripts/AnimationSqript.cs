using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSqript : MonoBehaviour
{
    public GameObject obj;
    Rigidbody2D rb2d;
    GameObject prefab;
    private Transform tra;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        tra = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Delete()
    {
        Destroy(gameObject);
    }

    public void Create()
    {
        prefab = Instantiate(obj, tra.position, tra.rotation);
        prefab.transform.parent = transform;
    }

    private IEnumerator Animation()
    {
        transform.Find("溶ける").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Create();
        transform.Find("歯車アイコン11").gameObject.SetActive(false);
        transform.Find("歯車アイコン12").gameObject.SetActive(false);
        transform.Find("溶ける").gameObject.SetActive(false);


        yield return null;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Acid")
        {
            StartCoroutine("Animation");
        }
    }
}
