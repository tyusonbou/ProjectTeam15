using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Pages; //ページ配列

    [SerializeField]
    private GameObject[] Stages; //ステージ配列

    [SerializeField]
    private string[] SceneName; //シーン名配列

    // 大きさをInspector上で自由に設定できるようにする
    public Vector3 scale;
    //ページ遷移スピード
    public float PageSpeed;

    public GameObject NextPage;
    public GameObject BackPage;

    string PageState; //何ページ目か
    string StageState; //どのステージを選択しているか

    float menuSelect;

    // Start is called before the first frame update
    void Start()
    {
        PageState = "PAGE1";
        StageState = "STAGE1";
        menuSelect = 0;
    }

    // Update is called once per frame
    void Update()
    {
        PageChange();
        StageSelect();
        StageChoice();

        if ((Input.GetAxisRaw("Horizontal") == 0))
        {
            menuSelect = 0;
        }
        else
        {
            menuSelect = 1;
        }
    }

    //ステージ決定
    private void StageChoice()
    {
        if (Input.GetButtonDown("A"))
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

                case "PAGE2":
                    switch (StageState)
                    {
                        case "STAGE1":
                            SceneManager.LoadScene(SceneName[9]);

                            break;

                        case "STAGE2":
                            SceneManager.LoadScene(SceneName[10]);

                            break;

                        case "STAGE3":
                            SceneManager.LoadScene(SceneName[11]);

                            break;

                        case "STAGE4":
                            SceneManager.LoadScene(SceneName[12]);

                            break;

                        case "STAGE5":
                            SceneManager.LoadScene(SceneName[13]);

                            break;

                        case "STAGE6":
                            SceneManager.LoadScene(SceneName[14]);

                            break;

                        case "STAGE7":
                            SceneManager.LoadScene(SceneName[15]);

                            break;

                        case "STAGE8":
                            SceneManager.LoadScene(SceneName[16]);

                            break;
                    }

                    break;

                case "PAGE3":
                    switch (StageState)
                    {
                        case "STAGE1":
                            SceneManager.LoadScene(SceneName[17]);

                            break;

                        case "STAGE2":
                            SceneManager.LoadScene(SceneName[18]);

                            break;

                        case "STAGE3":
                            SceneManager.LoadScene(SceneName[19]);

                            break;

                        case "STAGE4":
                            SceneManager.LoadScene(SceneName[20]);

                            break;

                        case "STAGE5":
                            SceneManager.LoadScene(SceneName[21]);

                            break;

                        case "STAGE6":
                            SceneManager.LoadScene(SceneName[22]);

                            break;

                        case "STAGE7":
                            SceneManager.LoadScene(SceneName[23]);

                            break;

                        case "STAGE8":
                            SceneManager.LoadScene(SceneName[24]);

                            break;
                    }

                    break;
            }
        }
        
    }

    //ページ変更描画
    private void PageChange()
    {
        RectTransform P1Pos = Pages[1].GetComponent<RectTransform>();
        RectTransform P2Pos = Pages[2].GetComponent<RectTransform>();
        RectTransform P3Pos = Pages[3].GetComponent<RectTransform>();


        switch (PageState)
        {
            case "PAGE1":
                //ステージ1~8まで格納
                for(int i = 1; i < Stages.Length; i++)
                {
                    Stages[i] = GameObject.Find("StageImage" + i);
                }

                BackPage.SetActive(false);

                if (P1Pos.localPosition.x != 0)
                {
                    P1Pos.localPosition += new Vector3(PageSpeed, 0, 0);
                    P2Pos.localPosition += new Vector3(PageSpeed, 0, 0);
                    P3Pos.localPosition += new Vector3(PageSpeed, 0, 0);
                }
                
                if(Input.GetButtonDown("RB"))
                {
                    PageState = "PAGE2";
                }

                break;

            case "PAGE2":
                //ステージ9~16まで格納
                for (int i = 1; i < Stages.Length; i++)
                {
                    Stages[i] = GameObject.Find("StageImage" + (i + 8));
                }

                BackPage.SetActive(true);
                NextPage.SetActive(true);

                if (P2Pos.localPosition.x != 0 && P2Pos.localPosition.x > 0)
                {
                    P1Pos.localPosition -= new Vector3(PageSpeed, 0, 0);
                    P2Pos.localPosition -= new Vector3(PageSpeed, 0, 0);
                    P3Pos.localPosition -= new Vector3(PageSpeed, 0, 0);
                }
                if (P2Pos.localPosition.x != 0 && P2Pos.localPosition.x < 0)
                {
                    P1Pos.localPosition += new Vector3(PageSpeed, 0, 0);
                    P2Pos.localPosition += new Vector3(PageSpeed, 0, 0);
                    P3Pos.localPosition += new Vector3(PageSpeed, 0, 0);
                }

                if (Input.GetButtonDown("LB"))
                {
                    PageState = "PAGE1";
                }

                if (Input.GetButtonDown("RB"))
                {
                    PageState = "PAGE3";
                }

                break;

            case "PAGE3":
                //ステージ17~24まで格納
                for (int i = 1; i < Stages.Length; i++)
                {
                    Stages[i] = GameObject.Find("StageImage" + (i + 16));
                }

                NextPage.SetActive(false);

                if (P3Pos.localPosition.x != 0)
                {
                    P1Pos.localPosition -= new Vector3(PageSpeed, 0, 0);
                    P2Pos.localPosition -= new Vector3(PageSpeed, 0, 0);
                    P3Pos.localPosition -= new Vector3(PageSpeed, 0, 0);
                }

                if (Input.GetButtonDown("LB"))
                {
                    PageState = "PAGE2";
                }

                break;
        }
    }


    //ステージ選択描画
    private void StageSelect()
    {
        

        //ページ変更時にSTAGE1状態にする
        if (Input.GetButtonDown("RB") || Input.GetButtonDown("LB"))
        {
            StageState = "STAGE1";
        }


        switch (StageState)
        {
            case "STAGE1":
                Stages[1].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                Stages[2].transform.localScale = new Vector3(1, 1, 1);
                Stages[3].transform.localScale = new Vector3(1, 1, 1);
                Stages[4].transform.localScale = new Vector3(1, 1, 1);
                Stages[5].transform.localScale = new Vector3(1, 1, 1);
                Stages[6].transform.localScale = new Vector3(1, 1, 1);
                Stages[7].transform.localScale = new Vector3(1, 1, 1);
                Stages[8].transform.localScale = new Vector3(1, 1, 1);

                if ((Input.GetAxisRaw("Horizontal") > 0) && (menuSelect == 0))
                {
                    StageState = "STAGE2";
                }
                if ((Input.GetAxisRaw("Vertical") < 0) && (menuSelect == 0))
                {
                    StageState = "STAGE5";
                }

                break;

            case "STAGE2":
                Stages[1].transform.localScale = new Vector3(1, 1, 1);
                Stages[2].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                Stages[3].transform.localScale = new Vector3(1, 1, 1);
                Stages[4].transform.localScale = new Vector3(1, 1, 1);
                Stages[5].transform.localScale = new Vector3(1, 1, 1);
                Stages[6].transform.localScale = new Vector3(1, 1, 1);
                Stages[7].transform.localScale = new Vector3(1, 1, 1);
                Stages[8].transform.localScale = new Vector3(1, 1, 1);

                if ((Input.GetAxisRaw("Horizontal") > 0) && (menuSelect == 0))
                {
                    StageState = "STAGE3";
                }
                if ((Input.GetAxisRaw("Horizontal") < 0) && (menuSelect == 0))
                {
                    StageState = "STAGE1";
                }
                if ((Input.GetAxisRaw("Vertical") < 0) && (menuSelect == 0))
                {
                    StageState = "STAGE6";
                }

                break;

            case "STAGE3":
                Stages[1].transform.localScale = new Vector3(1, 1, 1);
                Stages[2].transform.localScale = new Vector3(1, 1, 1);
                Stages[3].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                Stages[4].transform.localScale = new Vector3(1, 1, 1);
                Stages[5].transform.localScale = new Vector3(1, 1, 1);
                Stages[6].transform.localScale = new Vector3(1, 1, 1);
                Stages[7].transform.localScale = new Vector3(1, 1, 1);
                Stages[8].transform.localScale = new Vector3(1, 1, 1);

                if ((Input.GetAxisRaw("Horizontal") > 0) && (menuSelect == 0))
                {
                    StageState = "STAGE4";
                }
                if ((Input.GetAxisRaw("Horizontal") < 0) && (menuSelect == 0))
                {
                    StageState = "STAGE2";
                }
                if ((Input.GetAxisRaw("Vertical") < 0) && (menuSelect == 0))
                {
                    StageState = "STAGE7";
                }

                break;

            case "STAGE4":
                Stages[1].transform.localScale = new Vector3(1, 1, 1);
                Stages[2].transform.localScale = new Vector3(1, 1, 1);
                Stages[3].transform.localScale = new Vector3(1, 1, 1);
                Stages[4].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                Stages[5].transform.localScale = new Vector3(1, 1, 1);
                Stages[6].transform.localScale = new Vector3(1, 1, 1);
                Stages[7].transform.localScale = new Vector3(1, 1, 1);
                Stages[8].transform.localScale = new Vector3(1, 1, 1);

                if ((Input.GetAxisRaw("Horizontal") < 0) && (menuSelect == 0))
                {
                    StageState = "STAGE3";
                }
                if ((Input.GetAxisRaw("Vertical") < 0) && (menuSelect == 0))
                {
                    StageState = "STAGE8";
                }

                break;

            case "STAGE5":
                Stages[1].transform.localScale = new Vector3(1, 1, 1);
                Stages[2].transform.localScale = new Vector3(1, 1, 1);
                Stages[3].transform.localScale = new Vector3(1, 1, 1);
                Stages[4].transform.localScale = new Vector3(1, 1, 1);
                Stages[5].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                Stages[6].transform.localScale = new Vector3(1, 1, 1);
                Stages[7].transform.localScale = new Vector3(1, 1, 1);
                Stages[8].transform.localScale = new Vector3(1, 1, 1);

                if ((Input.GetAxisRaw("Horizontal") > 0) && (menuSelect == 0))
                {
                    StageState = "STAGE6";
                }
                if ((Input.GetAxisRaw("Vertical") > 0) && (menuSelect == 0))
                {
                    StageState = "STAGE1";
                }

                break;

            case "STAGE6":
                Stages[1].transform.localScale = new Vector3(1, 1, 1);
                Stages[2].transform.localScale = new Vector3(1, 1, 1);
                Stages[3].transform.localScale = new Vector3(1, 1, 1);
                Stages[4].transform.localScale = new Vector3(1, 1, 1);
                Stages[5].transform.localScale = new Vector3(1, 1, 1);
                Stages[6].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                Stages[7].transform.localScale = new Vector3(1, 1, 1);
                Stages[8].transform.localScale = new Vector3(1, 1, 1);

                if ((Input.GetAxisRaw("Horizontal") > 0) && (menuSelect == 0))
                {
                    StageState = "STAGE7";
                }
                if ((Input.GetAxisRaw("Horizontal") < 0) && (menuSelect == 0))
                {
                    StageState = "STAGE5";
                }
                if ((Input.GetAxisRaw("Vertical") > 0) && (menuSelect == 0))
                {
                    StageState = "STAGE2";
                }

                break;

            case "STAGE7":
                Stages[1].transform.localScale = new Vector3(1, 1, 1);
                Stages[2].transform.localScale = new Vector3(1, 1, 1);
                Stages[3].transform.localScale = new Vector3(1, 1, 1);
                Stages[4].transform.localScale = new Vector3(1, 1, 1);
                Stages[5].transform.localScale = new Vector3(1, 1, 1);
                Stages[6].transform.localScale = new Vector3(1, 1, 1);
                Stages[7].transform.localScale = new Vector3(scale.x, scale.y, scale.z);
                Stages[8].transform.localScale = new Vector3(1, 1, 1);

                if ((Input.GetAxisRaw("Horizontal") > 0) && (menuSelect == 0))
                {
                    StageState = "STAGE8";
                }
                if ((Input.GetAxisRaw("Horizontal") < 0) && (menuSelect == 0))
                {
                    StageState = "STAGE6";
                }
                if ((Input.GetAxisRaw("Vertical") > 0) && (menuSelect == 0))
                {
                    StageState = "STAGE3";
                }

                break;

            case "STAGE8":
                Stages[1].transform.localScale = new Vector3(1, 1, 1);
                Stages[2].transform.localScale = new Vector3(1, 1, 1);
                Stages[3].transform.localScale = new Vector3(1, 1, 1);
                Stages[4].transform.localScale = new Vector3(1, 1, 1);
                Stages[5].transform.localScale = new Vector3(1, 1, 1);
                Stages[6].transform.localScale = new Vector3(1, 1, 1);
                Stages[7].transform.localScale = new Vector3(1, 1, 1);
                Stages[8].transform.localScale = new Vector3(scale.x, scale.y, scale.z);

                if ((Input.GetAxisRaw("Horizontal") < 0) && (menuSelect == 0))
                {
                    StageState = "STAGE7";
                }
                if ((Input.GetAxisRaw("Vertical") > 0) && (menuSelect == 0))
                {
                    StageState = "STAGE4";
                }

                break;
        }
    }
}
