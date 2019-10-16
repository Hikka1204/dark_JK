using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NowScore_Text : MonoBehaviour {

    // スコアの値取得用変数
    int _nowscore;

    // Textオブジェクト
    public GameObject score_object = null;

	// Use this for initialization
	void Start () {
        // 他のスクリプトの変数から値を取得
        if (PlayerPrefs.HasKey("NOWSCORE"))
        {
            _nowscore = PlayerPrefs.GetInt("NOWSCORE");
        }

        // スコア表示関数
        ShowScore();
	}
	
	// Update is called once per frame
	void ShowScore () {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();

        // 適すとの内容を入れる
        score_text.text = "SCORE：" + _nowscore;
	}
}
