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
    private Text MainText;
    [SerializeField]
    private Text CloseText;
    [SerializeField]
    private Text RestartText;
    [SerializeField]
    private Text StageText;
    [SerializeField]
    private Text TitleBackText;

    string state;
    float menuSelect;
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        MainText = pauseUI.transform.Find("PauseText").GetComponent<Text>();
        CloseText = pauseUI.transform.Find("CloseText").GetComponent<Text>();
        RestartText = pauseUI.transform.Find("RestartText").GetComponent<Text>();
        StageText = pauseUI.transform.Find("StageSelect").GetComponent<Text>();
        TitleBackText = pauseUI.transform.Find("TitleText").GetComponent<Text>();

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
        if (pauseUI.activeSelf && Player != null) 
        {
            Time.timeScale = 0f;

            ChangeUI();
        }
        else
        {
            //　ポーズUIが表示されてなければ通常通り進行
            Time.timeScale = 1f;
        }

        if (Player == null)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
            //　ゲームオーバーUIのアクティブ、非アクティブを切り替え
            GameOverUI();
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
                StageText.color = Color.black;
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
                StageText.color = Color.black;
                TitleBackText.color = Color.black;

                if ((Input.GetAxisRaw("Vertical") < 0) && (menuSelect == 0))
                {
                    state = "STAGE SELECT";
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

            case "STAGE SELECT":
                CloseText.color = Color.black;
                RestartText.color = Color.black;
                StageText.color = Color.red;
                TitleBackText.color = Color.black;
                if ((Input.GetAxisRaw("Vertical") < 0) && (menuSelect == 0))
                {
                    state = "TITLE BACK";
                }
                if ((Input.GetAxisRaw("Vertical") > 0) && (menuSelect == 0))
                {
                    state = "RESTART";
                }

                if (Input.GetButtonDown("A"))
                {
                    SceneManager.LoadScene("StageSelect");
                }

                break;

            case "TITLE BACK":
                CloseText.color = Color.black;
                RestartText.color = Color.black;
                StageText.color = Color.black;
                TitleBackText.color = Color.red;
                if ((Input.GetAxisRaw("Vertical") < 0) && (menuSelect == 0))
                {
                    state = "CLOSE";
                }
                if ((Input.GetAxisRaw("Vertical") > 0) && (menuSelect == 0)) 
                {
                    state = "STAGE SELECT";
                }

                if (Input.GetButtonDown("A"))
                {
                    SceneManager.LoadScene("Title");
                }

                break;
        }
    }

    private void GameOverUI()
    {
        MainText.text = "GAME OVER";
        CloseText.text = "RESTART";
        RestartText.text = "STAGE SELECT";
        StageText.text = "TITLE BACK";
        TitleBackText.text = "";

        switch (state)
        {

            case "CLOSE":
                CloseText.color = Color.red;
                RestartText.color = Color.black;
                StageText.color = Color.black;

                if ((Input.GetAxisRaw("Vertical") < 0) && (menuSelect == 0))
                {
                    state = "RESTART";
                }
                if ((Input.GetAxisRaw("Vertical") > 0) && (menuSelect == 0))
                {
                    state = "STAGE SELECT";
                }

                if (Input.GetButtonDown("A"))
                {
                    // 現在のScene名を取得する
                    Scene loadScene = SceneManager.GetActiveScene();
                    // Sceneの読み直し
                    SceneManager.LoadScene(loadScene.name);
                }

                break;

            case "RESTART":

                CloseText.color = Color.black;
                RestartText.color = Color.red;
                StageText.color = Color.black;

                if ((Input.GetAxisRaw("Vertical") < 0) && (menuSelect == 0))
                {
                    state = "STAGE SELECT";
                }
                if ((Input.GetAxisRaw("Vertical") > 0) && (menuSelect == 0))
                {
                    state = "CLOSE";
                }

                if (Input.GetButtonDown("A"))
                {
                    SceneManager.LoadScene("StageSelect");
                }

                break;

            case "STAGE SELECT":

                CloseText.color = Color.black;
                RestartText.color = Color.black;
                StageText.color = Color.red;

                if ((Input.GetAxisRaw("Vertical") < 0) && (menuSelect == 0))
                {
                    state = "CLOSE";
                }
                if ((Input.GetAxisRaw("Vertical") > 0) && (menuSelect == 0))
                {
                    state = "RESTART";
                }

                if (Input.GetButtonDown("A"))
                {
                    SceneManager.LoadScene("Title");
                }

                break;
        }
    }
}
