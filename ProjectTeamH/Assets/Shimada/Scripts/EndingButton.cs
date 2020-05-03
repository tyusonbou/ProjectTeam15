//2020/04/17
//エンディングシーンのボタン
//島田一宏
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void toGameScene()
    {

        FadeManager.Instance.LoadScene("Title", 2.0f);
    }
}
