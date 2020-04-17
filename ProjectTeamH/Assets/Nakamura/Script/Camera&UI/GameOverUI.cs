using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    private GameObject Player;

    //ポーズした時に表示するUI
    [SerializeField]
    private GameObject GameoverUI;


    [SerializeField]
    private Text RestartText;
    [SerializeField]
    private Text TitleBackText;

    string state;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        state = "RESTART";
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            //　ゲームオーバーUIのアクティブ、非アクティブを切り替え
            GameoverUI.SetActive(true);
        }

        //　ゲームオーバーUIが表示されてる時は停止
        if (GameoverUI.activeSelf)
        {
            Time.timeScale = 0f;

            ChangeUI();
        }
        else
        {
            //　ゲームオーバーUIが表示されてなければ通常通り進行
            Time.timeScale = 1f;
        }
    }

    //ゲームオーバー画面の操作
    private void ChangeUI()
    {
        switch (state)
        {

            case "RESTART":
                RestartText.color = Color.red;
                TitleBackText.color = Color.black;

                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    state = "TITLE BACK";
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    state = "TITLE BACK";
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

                RestartText.color = Color.black;
                TitleBackText.color = Color.red;
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    state = "RESTART";
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    state = "RESTART";
                }
                break;
        }
    }
}
