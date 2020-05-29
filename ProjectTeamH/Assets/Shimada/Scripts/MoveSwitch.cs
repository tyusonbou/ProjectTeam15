//2020/2/7
//動く床のスイッチ
//島田一宏
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MoveSwitch : MonoBehaviour
{
    [SerializeField]
    private int FlagNo;//床とスイッチの紐づけ
    private bool Swich;//オンかオフか
    [SerializeField]
    private Sprite on;//オンの画像
    [SerializeField]
    private Sprite off;//オフの画像
    [SerializeField]
    private AudioClip sound;
    private AudioSource audioSource;
    void Start()
    {
        Swich = false;//最初はオフ 
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //プレイヤーが触れたら
        if (col.gameObject.tag=="Player")
        {
            if (Swich == false)
            {
                Swich = true;//スイッチオン
                audioSource.PlayOneShot(sound);
                FlagManager.Instance.flags[FlagNo] = true;
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = on;
            }
            else if (Swich == true)
            {
                Swich = false;//スイッチオフ
                audioSource.PlayOneShot(sound);
                FlagManager.Instance.flags[FlagNo] = false;
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = off;
            }
        }
    }

#if UNITY_EDITOR
    /**
     * Inspector拡張クラス
     */
    [CustomEditor(typeof(MoveSwitch))]               // 拡張するときのお決まり
    public class MoveSwitchEditor : Editor           // Editorを継承
    {
        bool folding = false;

        public override void OnInspectorGUI()
        {
            //値の変更をする
            Undo.RecordObject(target, "moveswich");
            // target は処理コードのインスタンスだよ！ 処理コードの型でキャストして使ってね！
            MoveSwitch moveswich = target as MoveSwitch;

            // -- カスタム表示

            // -- 床とスイッチの紐づけ --
            moveswich.FlagNo = EditorGUILayout.IntField("移動床との紐づけ", moveswich.FlagNo);



            //値の変更を保存
            EditorUtility.SetDirty(moveswich);
        }
    }
#endif
}