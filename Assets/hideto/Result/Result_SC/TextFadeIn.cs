using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeIn : MonoBehaviour {

    // スコアテキストのフェードイン
    float scoretextintime = 2.0f;

    // フェードインのスピード
    float textfadespeed = 0.01f;

    // テキストカラー変数
    private Color textcolor;

    // Uiテキストを格納
    public GameObject NowScore;

	// Use this for initialization
	void Start () {
        // スコアのカラーを取得してアルファ値を0に初期化
        textcolor = this.NowScore.GetComponent<Text>().color;
        textcolor.a = 0;
        this.NowScore.GetComponent<Text>().color = textcolor;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))
        {
            scoretextintime = 0.0f;
        }

        Invoke("FadeIn", scoretextintime);
	}

    void FadeIn()
    {
        if(textcolor.a <= 1)
        {
            textcolor.a += textfadespeed;
            this.NowScore.GetComponent<Text>().color = textcolor;
        }
    }
}
