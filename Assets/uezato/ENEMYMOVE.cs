
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ENEMYMOVE : MonoBehaviour
{
   // Rigidbody2D rb;
    public float moveSpeed ;
    public int Sflg = 0;

    GameObject haikei; //Unityちゃんそのものが入る変数

    BackgroundController script; //UnityChanScriptが入る変数
    void Start()
    {
        //GetComponentの処理をキャッシュしておく
        //  rb = GetComponent<Rigidbody2D>();
        haikei= GameObject.Find("haikei"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
        script = haikei.GetComponent<BackgroundController>(); //unitychanの中にあるUnityChanScriptを取得して変数に格納する
        Destroy(gameObject, 15f); // 三秒後に削除
        
    }

    // 更新用の関数
    void Update()
    {

        moveSpeed = script.scroll; //新しく変数を宣言してその中にUnityChanScriptの変数HPを代入する

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
            Debug.Log("GAMEOVER");
            Sflg = 1;
        }
    }


}
