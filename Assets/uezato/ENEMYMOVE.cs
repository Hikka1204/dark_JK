﻿
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ENEMYMOVE : MonoBehaviour
{
   // Rigidbody2D rb;
    public float moveSpeed ;
    public int Sflg = 0;

    public GameObject particle;

    GameObject haikei; //Unityちゃんそのものが入る変数
    GameObject haikei2; //Unityちゃんそのものが入る変数
    GameObject Player; //Unityちゃんそのものが入る変数
    public BackgroundController BackGround;

    BackgroundController script; //UnityChanScriptが入る変数
    BackgroundController script2; //UnityChanScriptが入る変数
    //PlayerController Pscript; //
    void Start()
    {
        //GetComponentの処理をキャッシュしておく
        //  rb = GetComponent<Rigidbody2D>();
        haikei= GameObject.Find("haikei"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
        script = haikei.GetComponent<BackgroundController>(); //unitychanの中にあるUnityChanScriptを取得して変数に格納する

        haikei2 = GameObject.Find("haikei2"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
        script2 = haikei2.GetComponent<BackgroundController>(); //unitychanの中にあるUnityChanScriptを取得して変数に格納する

        //Player = GameObject.Find("Player_v1.5"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
        //Pscript = Player.GetComponent<PlayerController>();

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
            Debug.Log("Playerと当たった");
            //Destroy(gameObject, 0.5f); // 三秒後に削除
            script.scroll = 0;
            script2.scroll = 0;
            GameObject.Find("haikei").gameObject.GetComponent<BackgroundController>().Scrollstop();
        }
        if(collision.gameObject.tag == "Sword")
        {
            Debug.Log("Sword");
            GameObject insParticle = Instantiate(particle);
            insParticle.transform.position = this.transform.position;
            Destroy(gameObject, 0.05f); 
        }
    }

 
}
