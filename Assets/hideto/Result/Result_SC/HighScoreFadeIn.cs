using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreFadeIn : MonoBehaviour {

    // ハイスコアテキストのフェードイン
    float highscoreintime = 0.0f;

    // フェードインスピード
    float highscorespeed = 0.02f;

    // テキストカラー変数
    private Color highscorecolor;

    // UIテキストを格納
    public GameObject HighScore;

	// Use this for initialization
	void Start () {
        // スコアのカラーを取得してアルファ値を0に初期化
        highscorecolor = this.HighScore.GetComponent<Text>().color;
        highscorecolor.a = 0;
        this.HighScore.GetComponent<Text>().color = highscorecolor;

	}
	
	// Update is called once per frame
	void Update () {
        Invoke("FadeIn", highscoreintime);
	}

    void FadeIn()
    {
        if(highscorecolor.a <= 1)
        {
            highscorecolor.a += highscorespeed;
            this.HighScore.GetComponent<Text>().color = highscorecolor;
        }
    }
}
