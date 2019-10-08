﻿
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class ENEMYMOVE : MonoBehaviour
{
   // Rigidbody2D rb;
    public int moveSpeed = 2;

    void Start()
    {
        //GetComponentの処理をキャッシュしておく
        //  rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 15f); // 三秒後に削除

    }

    // 更新用の関数
    void Update()
    {

        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector2 pos = myTransform.position;
        pos.x -= 0.02f;    // x座標へ0.01加算
      //pos.y += 0.01f;    // y座標へ0.01加算
       //pos.z += 0.01f;    // z座標へ0.01加算

        myTransform.position = pos;  // 座標を設定
    }
}