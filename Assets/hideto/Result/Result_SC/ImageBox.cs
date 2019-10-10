using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageBox : MonoBehaviour {

    // 画像変数
    public GameObject image_highscore;

    // ハイスコア判定フラグ
    bool _highscoreflg;

    // スコアのフェードインフラグ回収変数
    bool _scorefadeinflg;
	
	// Update is called once per frame
	void Update () {
        _highscoreflg = HighScore.getPassHighScoreFlg();
        _scorefadeinflg = TextFadeIn.getScoreFadeInFlg();

        Debug.Log(_scorefadeinflg);

        // 画像判定処理
        // false➡ハイスコア更新無し true➡ハイスコア更新
        if(_highscoreflg == true && _scorefadeinflg == true)
        {
            image_highscore.SetActive(true);
        }
        else
        {
            image_highscore.SetActive(false);
        }
	}
}
