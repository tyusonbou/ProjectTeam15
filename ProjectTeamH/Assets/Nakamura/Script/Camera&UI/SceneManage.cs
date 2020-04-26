using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    [SerializeField]
    private string SceneName;
    [SerializeField]
    private string SecretName;
    [SerializeField]
    int SecretGoalCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) { return; }

        //隠し条件設定なし時通常ゴール
        if (PlayerController.GetGoal()  && SecretGoalCount == 0)
        {
            SceneManager.LoadScene(SceneName);
        }

        //かくｓ条件設定あり時通常ゴール
        if (PlayerController.GetGoal() && PlayerController.GetNeutralizer() != SecretGoalCount && SecretGoalCount != 0) 
        {
            SceneManager.LoadScene(SceneName);
        }

        //隠し条件設定あり時隠しゴール
        if (PlayerController.GetGoal() && PlayerController.GetNeutralizer() == SecretGoalCount && SecretGoalCount != 0)
        {
            SceneManager.LoadScene(SecretName);
        }
    }
}
