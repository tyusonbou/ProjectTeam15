using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gameObjects;

    [SerializeField]
    private string[] SceneName;

    // 大きさをInspector上で自由に設定できるようにする
    public Vector3 scale;

    string PageState;
    string StageState;

    // Start is called before the first frame update
    void Start()
    {
        PageState = "PAGE1";
        StageState = "STAGE1";
    }

    // Update is called once per frame
    void Update()
    {
        PageChange();
        StageSelect();
        StageChoice();
    }

    private void StageChoice()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch (PageState)
            {
                case "PAGE1":
                    switch (StageState)
                    {
                        case "STAGE1":
                            SceneManager.LoadScene(SceneName[1]);

                            break;

                        case "STAGE2":
                            SceneManager.LoadScene(SceneName[2]);

                            break;

                        case "STAGE3":
                            SceneManager.LoadScene(SceneName[3]);

                            break;

                        case "STAGE4":
                            SceneManager.LoadScene(SceneName[4]);

                            break;

                        case "STAGE5":
                            SceneManager.LoadScene(SceneName[5]);

                            break;

                        case "STAGE6":
                            SceneManager.LoadScene(SceneName[6]);

                            break;

                        case "STAGE7":
                            SceneManager.LoadScene(SceneName[7]);

                            break;

                        case "STAGE8":
                            SceneManager.LoadScene(SceneName[8]);

                            break;
                    }

                    break;
            }
        }
        
    }

    private void PageChange()
    {
        switch (PageState)
        {
            case "PAGE1":
                gameObjects[1] = GameObject.Find("StageImage1");
                gameObjects[2] = GameObject.Find("StageImage2");
                gameObjects[3] = GameObject.Find("StageImage3");
                gameObjects[4] = GameObject.Find("StageImage4");
                gameObjects[5] = GameObject.Find("StageImage5");
                gameObjects[6] = GameObject.Find("StageImage6");
                gameObjects[7] = GameObject.Find("StageImage7");
                gameObjects[8] = GameObject.Find("StageImage8");

                break;
        }
    }

    private void StageSelect()
    {
        switch (StageState)
        {
            case "STAGE1":
                gameObjects[1].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                gameObjects[2].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[3].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[4].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[5].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[6].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[7].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[8].transform.localScale = new Vector3(1, 1, 1);

                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    StageState = "STAGE2";
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    StageState = "STAGE5";
                }

                break;

            case "STAGE2":
                gameObjects[1].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[2].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                gameObjects[3].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[4].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[5].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[6].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[7].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[8].transform.localScale = new Vector3(1, 1, 1);

                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    StageState = "STAGE3";
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    StageState = "STAGE1";
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    StageState = "STAGE6";
                }

                break;

            case "STAGE3":
                gameObjects[1].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[2].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[3].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                gameObjects[4].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[5].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[6].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[7].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[8].transform.localScale = new Vector3(1, 1, 1);

                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    StageState = "STAGE4";
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    StageState = "STAGE2";
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    StageState = "STAGE7";
                }

                break;

            case "STAGE4":
                gameObjects[1].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[2].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[3].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[4].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                gameObjects[5].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[6].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[7].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[8].transform.localScale = new Vector3(1, 1, 1);

                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    StageState = "STAGE3";
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    StageState = "STAGE8";
                }

                break;

            case "STAGE5":
                gameObjects[1].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[2].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[3].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[4].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[5].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                gameObjects[6].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[7].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[8].transform.localScale = new Vector3(1, 1, 1);

                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    StageState = "STAGE6";
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    StageState = "STAGE1";
                }

                break;

            case "STAGE6":
                gameObjects[1].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[2].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[3].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[4].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[5].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[6].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                gameObjects[7].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[8].transform.localScale = new Vector3(1, 1, 1);

                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    StageState = "STAGE7";
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    StageState = "STAGE5";
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    StageState = "STAGE2";
                }

                break;

            case "STAGE7":
                gameObjects[1].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[2].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[3].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[4].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[5].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[6].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[7].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                gameObjects[8].transform.localScale = new Vector3(1, 1, 1);

                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    StageState = "STAGE8";
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    StageState = "STAGE6";
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    StageState = "STAGE3";
                }

                break;

            case "STAGE8":
                gameObjects[1].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[2].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[3].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[4].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[5].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[6].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[7].transform.localScale = new Vector3(1, 1, 1);
                gameObjects[8].transform.localScale = new Vector3(scale.x, scale.y, scale.z);

                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    StageState = "STAGE7";
                }
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {
                    StageState = "STAGE4";
                }

                break;
        }
    }
}
