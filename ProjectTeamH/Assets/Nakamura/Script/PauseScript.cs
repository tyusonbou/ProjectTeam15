using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    //ポーズした時に表示するUI
    [SerializeField]
    private GameObject pauseUI;

    [SerializeField]
    private Text CloseText;
    [SerializeField]
    private Text RestartText;
    [SerializeField]
    private Text TitleBackText;

    string state;

    // Start is called before the first frame update
    void Start()
    {
        state = "CLOSE";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {   //　ポーズUIのアクティブ、非アクティブを切り替え
            pauseUI.SetActive(!pauseUI.activeSelf);

            state = "CLOSE";
        }

        //　ポーズUIが表示されてる時は停止
        if (pauseUI.activeSelf)
        {
            Time.timeScale = 0f;

            ChangeUI();
        }
        else
        {
            //　ポーズUIが表示されてなければ通常通り進行
            Time.timeScale = 1f;
        }


        
    }

    //ポーズ画面の操作
    private void ChangeUI()
    {
        switch (state)
        {
            case "CLOSE":
                CloseText.color = Color.red;
                RestartText.color = Color.black;
                TitleBackText.color = Color.black;

                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    state = "RESTART";
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    state = "TITLE BACK";
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //　ポーズUIのアクティブ、非アクティブを切り替え
                    pauseUI.SetActive(!pauseUI.activeSelf);
                }

                break;

            case "RESTART":
                CloseText.color = Color.black;
                RestartText.color = Color.red;
                TitleBackText.color = Color.black;

                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    state = "TITLE BACK";
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    state = "CLOSE";
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    // 現在のScene名を取得する
                    Scene loadScene = SceneManager.GetActiveScene();
                    // Sceneの読み直し
                    SceneManager.LoadScene(loadScene.name);
                }

                break;

            case "TITLE BACK":
                CloseText.color = Color.black;
                RestartText.color = Color.black;
                TitleBackText.color = Color.red;
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    state = "CLOSE";
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    state = "RESTART";
                }
                break;
        }
    }
}
