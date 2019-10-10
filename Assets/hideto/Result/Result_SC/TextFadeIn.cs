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

    // スコアフェードイン完了フラグ
    public static bool scorefadeinflg;

	// Use this for initialization
	void Start () {
        // スコアのカラーを取得してアルファ値を0に初期化
        textcolor = this.NowScore.GetComponent<Text>().color;
        textcolor.a = 0;
        this.NowScore.GetComponent<Text>().color = textcolor;

        // フェードインフラグをfalse
        scorefadeinflg = false;
	}
	
	// Update is called once per frame
	void Update () {
        // 画面をクリックするとスコアをすぐに表示
        if(Input.GetMouseButtonDown(0))
        {
            scoretextintime = 0.0f;
        }

        Invoke("FadeIn", scoretextintime);
	}

    void FadeIn()
    {
        // スコアのテキストのアルファ値をだんだん上げる
        if(textcolor.a <= 1)
        {
            textcolor.a += textfadespeed;
            this.NowScore.GetComponent<Text>().color = textcolor;
        }
        else if(textcolor.a >= 1)
        {
            scorefadeinflg = true;
            getScoreFadeInFlg();
        }
    }

    public static bool getScoreFadeInFlg()
    {
        return scorefadeinflg;
    }
}
