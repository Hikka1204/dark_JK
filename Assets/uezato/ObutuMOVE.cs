
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ObutuMOVE: MonoBehaviour
{
    // Rigidbody2D rb;
    public float moveSpeed ;
    GameObject haikei; //Unityちゃんそのものが入る変数
    BackgroundController script; //UnityChanScriptが入る変数
    GameObject haikei2; //Unityちゃんそのものが入る変数
    BackgroundController script2; //UnityChanScriptが入る変数



    void Start()
    {
        haikei = GameObject.Find("haikei"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
        script = haikei.GetComponent<BackgroundController>(); //unitychanの中にあるUnityChanScriptを取得して変数に格納する

        haikei2 = GameObject.Find("haikei2"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
        script2 = haikei2.GetComponent<BackgroundController>(); //unitychanの中にあるUnityChanScriptを取得して変数に格納する
        //GetComponentの処理をキャッシュしておく
        //  rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 15f); // 三秒後に削除

    }

    // 更新用の関数
    void Update()
    {


        moveSpeed = script.scroll;

        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector2 pos = myTransform.position;
        pos.x += moveSpeed;    // x座標へ0.01加算
                           //pos.y += 0.01f;    // y座標へ0.01加算
                           //pos.z += 0.01f;    // z座標へ0.01加算

        myTransform.position = pos;  // 座標を設定


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("おぶつ");
            script.scroll = 0;
            script2.scroll = 0;
        }
    }


}