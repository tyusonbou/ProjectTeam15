//2020/02/14
//酸を受けて消えるオブジェクト
//島田一宏
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class AcidDestroy : MonoBehaviour
{
    //[SerializeField]
    //private int hp;//消えるまでの値
    [SerializeField]
    private float AcidTime;//消える前での時間

    //メインカメラについているタグ名
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    //カメラに表示されているか
    private bool _isRendered = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isRendered)
        {
            AcidTime -= Time.deltaTime;
            //マイナス値にならないように
            AcidTime = Mathf.Max(AcidTime, 0.0f);
            if(AcidTime == 0)
            {
                Destroy(gameObject);
            }
        }
        _isRendered = false;
    }

    //カメラに写っている間に呼ばれる
    private void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRederedを有効に
        if(Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "acid")
    //    {
    //        if (hp > 1)
    //        {
    //            //相手を削除
    //            Destroy(collision.gameObject);
    //            hp = hp - 1;
    //        }
    //        else
    //        {
    //            //自分を削除
    //            Destroy(gameObject);
    //        }
    //    }
    //}

#if UNITY_EDITOR
    /**
     * Inspector拡張クラス
     */
    [CustomEditor(typeof(AcidDestroy))]               // 拡張するときのお決まり
    public class AcidDestroyEditor : Editor           // Editorを継承
    {
        bool folding = false;

        public override void OnInspectorGUI()
        {
            //値の変更をする
            Undo.RecordObject(target, "aciddestroy");
            // target は処理コードのインスタンスだよ！ 処理コードの型でキャストして使ってね！
            AcidDestroy aciddestroy = target as AcidDestroy;

            // -- カスタム表示 --

            //// -- 消滅するまでの回数 --
            //aciddestroy.hp = EditorGUILayout.IntField("消滅までの回数", aciddestroy.hp);
            //消滅するまでの時間
            aciddestroy.AcidTime = EditorGUILayout.FloatField("消滅するまでの時間", aciddestroy.AcidTime);
            //値の変更を保存
            EditorUtility.SetDirty(aciddestroy);
        }
    }
#endif
}