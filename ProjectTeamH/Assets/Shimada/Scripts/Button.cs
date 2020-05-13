//2020/04/17
//ボタン
//島田一宏
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    int number;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //caseを増やすことで流用可能
    public void OnClick(int number)
    {
        switch (number)
        {
            case 0:
                FadeManager.Instance.LoadScene("Ending", 2.0f);
                break;

            case 1:
                FadeManager.Instance.LoadScene("StageSelect", 2.0f);
                break;

            case 2:
                FadeManager.Instance.LoadScene("Title", 2.0f);
                break;

            case 3:
                
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif
                    break;
        }
    }

}
