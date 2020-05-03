//2020/2/7
//移動する床
//島田一宏
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MoveFloor : MonoBehaviour
{
    //変数定義
    private Rigidbody2D rb;
    private Vector2 defaultpass;
    private float moveTime;//時間
    [SerializeField]
    private float speed;//動く速さ
    [SerializeField]
    private float length;//動く範囲
    [SerializeField]
    private int FlagNo;//床とスイッチの紐づけ
    [SerializeField]
    private bool MoveDirectionFlag;//動く方向
    [SerializeField]
    private bool SwichType;//スイッチ式かどうか

    void Start()
    {
        FlagManager.Instance.ResetFlags();//フラグ全消し
        rb = this.GetComponent<Rigidbody2D>();
        defaultpass = this.transform.position;
    }

    void Update()
    {
        //スイッチ式なら
        if (SwichType == true)
        {
            if (FlagManager.Instance.flags[FlagNo] == true)
            {
                //MoveDirectionFlagがfalseなら横方向
                if (MoveDirectionFlag == false)
                {
                    this.moveTime += Time.deltaTime;
                    //X座標のみ横移動
                    this.rb.transform.position = new Vector2(defaultpass.x + Mathf.PingPong(moveTime * speed, length), defaultpass.y);
                }
                //MoveDirectionFlagがtrueなら縦方向
                else if (MoveDirectionFlag == true)
                {
                        this.moveTime += Time.deltaTime;
                        //Y座標のみ横移動
                        this.rb.transform.position = new Vector2(defaultpass.x, defaultpass.y + Mathf.PingPong(moveTime * speed, length));
                }
            }
        }
        else if(SwichType == false)
        {
            //MoveDirectionFlagがfalseなら横方向
            if (MoveDirectionFlag == false)
            {
                this.moveTime += Time.deltaTime;
                //X座標のみ横移動
                this.rb.transform.position = new Vector2(defaultpass.x + Mathf.PingPong(moveTime * speed, length), defaultpass.y);
            }
            //MoveDirectionFlagがtrueなら縦方向
            else if (MoveDirectionFlag == true)
            {
                this.moveTime += Time.deltaTime;
                //Y座標のみ横移動
                this.rb.transform.position = new Vector2(defaultpass.x, defaultpass.y + Mathf.PingPong(moveTime * speed, length));
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //上に乗っているオブジェクトを子要素に
        collision.gameObject.transform.SetParent(this.transform);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //子要素から外す
        collision.gameObject.transform.SetParent(null);
    }

#if UNITY_EDITOR
    /**
     * Inspector拡張クラス
     */
    [CustomEditor(typeof(MoveFloor))]               // 拡張するときのお決まり
    public class MoveFloorEditor : Editor           // Editorを継承
    {
        bool folding = false;

        public override void OnInspectorGUI()
        {
            //値の変更をする
            Undo.RecordObject(target, "move");
            // target は処理コードのインスタンスだよ！ 処理コードの型でキャストして使ってね！
            MoveFloor move = target as MoveFloor;
            // -- カスタム表示

            // -- 速度 --
            move.speed = EditorGUILayout.FloatField("速度", move.speed);

            // -- 動く範囲 --
            move.length = EditorGUILayout.FloatField("動く範囲", move.length);

            // -- 床とスイッチの紐づけ --
            move.FlagNo = EditorGUILayout.IntField("スイッチとの紐づけ", move.FlagNo);

            // -- 移動方向 --
            move.MoveDirectionFlag = EditorGUILayout.Toggle("チェックなら縦移動", move.MoveDirectionFlag);

            // -- スイッチ式かどうか
            move.SwichType = EditorGUILayout.Toggle("スイッチ式かどうか", move.SwichType);

            //値の変更を保存
            EditorUtility.SetDirty(move);
        }

    }
#endif
}