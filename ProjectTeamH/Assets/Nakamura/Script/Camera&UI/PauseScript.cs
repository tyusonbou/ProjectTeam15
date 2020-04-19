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
    float menuSelect;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        state = "CLOSE";
        menuSelect = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("START")) && (Player != null))
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

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            menuSelect = 0;
        }
        else
        {
            menuSelect = 1;
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

                if ((Input.GetAxisRaw("Vertical") < 0) && (menuSelect == 0))
                {
                    state = "RESTART";
                }
                if ((Input.GetAxisRaw("Vertical") > 0) && (menuSelect == 0))
                {
                    state = "TITLE BACK";
                }

                if (Input.GetButtonDown("A"))
                {
                    //　ポーズUIのアクティブ、非アクティブを切り替え
                    pauseUI.SetActive(!pauseUI.activeSelf);
                }

                break;

            case "RESTART":
                CloseText.color = Color.black;
                RestartText.color = Color.red;
                TitleBackText.color = Color.black;

                if ((Input.GetAxisRaw("Vertical") < 0) && (menuSelect == 0))
                {
                    state = "TITLE BACK";
                }
                if ((Input.GetAxisRaw("Vertical") > 0) && (menuSelect == 0))
                {
                    state = "CLOSE";
                }

                if (Input.GetButtonDown("A"))
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
                if ((Input.GetAxisRaw("Vertical") < 0) && (menuSelect == 0))
                {
                    state = "CLOSE";
                }
                if ((Input.GetAxisRaw("Vertical") > 0) && (menuSelect == 0)) 
                {
                    state = "RESTART";
                }
                break;
        }
    }
}
