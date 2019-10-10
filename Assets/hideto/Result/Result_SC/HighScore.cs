using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {
    // 今回のスコア取得変数(他のスクリプトの変数と区別する)
    int __nowscore;

    // ハイスコア判定変数
    public static bool highscoreflg;

    // Textオブジェクト
    public GameObject highscore_object = null;
    public int highscore = 0;

    // ハイスコア達成時の画像表示時間
    float highscoreimagetime = 3.0f;

	// Use this for initialization
	void Start () {
        // ハイスコアの判定をfalse
        highscoreflg = false;

        // 他のスクリプトの変数の値を取得
        //__nowscore = ;

        // ハイスコアのロード
        highscore = PlayerPrefs.GetInt("HIGHSCORE", 0);

        // ハイスコア比較関数
        HighScoreComparison();

    }

    // アプリを終了させてもハイスコアの値を残す
    void OnDestroy()
    {
        // ハイスコアの保存
        PlayerPrefs.SetInt("HIGHSCORE", highscore);
        PlayerPrefs.Save();
    }


    void HighScoreComparison() {
        // スコアとハイスコアの比較 (今回のスコアの方が多いなら更新,少ないなら変更なし)
        if (__nowscore > highscore)
        {
            // ハイスコアを更新
            highscore = __nowscore;

            // ハイスコアの保存
            PlayerPrefs.SetInt("HIGHSCORE", highscore);
            PlayerPrefs.Save();

            // ハイスコアのフラグをtrue
            highscoreflg = true;

            // ここに関数を入れる
            //getPassHighScoreFlg();
        }

        // オブジェクトからTextコンポーネントを取得
        Text highscore_text = highscore_object.GetComponent<Text>();

        // テキストの表示を入れ替える
        highscore_text.text = "HIGHSCORE：" + highscore;
    }

    public static bool getPassHighScoreFlg()
    {
        return highscoreflg;
    }
}
