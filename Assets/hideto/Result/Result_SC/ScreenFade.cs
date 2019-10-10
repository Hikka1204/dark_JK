using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenFade : MonoBehaviour {

    public AudioSource background_GBM;
    public AudioSource background_SE;

    // ボタンフラグ
    bool _changeflg_retry;
    bool _changeflg_title;

    // 透明度変更スピード
    float fadespeed = 0.01f;
    float red, green, blue, alfa;

    Image fadeimage;

    bool fadeinflg;

	// Use this for initialization
	void Start () {
        fadeimage = GetComponent<Image>();
        red = fadeimage.color.r;
        green = fadeimage.color.g;
        blue = fadeimage.color.b;
        alfa = fadeimage.color.a;

        fadeinflg = true;
        fadeimage.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        _changeflg_retry = GoToRetry_Button.getChangeFlg_Retry();
        _changeflg_title = GoToTitle_Button.getChangeFlg_Title();

        if(fadeinflg == true)
        {
            StartFadeIn();
        }

        if(_changeflg_retry || _changeflg_title)
        {
            background_SE.PlayOneShot(background_SE.clip);
        }

        if(_changeflg_retry == true)
        {
            StartFadeOut();
        }
        else if(_changeflg_title == true)
        {
            StartFadeOut();
        }
	}

    void StartFadeIn()
    {
        // 不透明度を徐々に下げる
        alfa -= fadespeed;

        // 変更した透明度を反映
        SetAlpha();

        // 完全に見えるようになったら終了
        if(alfa <= 0)
        {
            fadeinflg = false;
            fadeimage.enabled = false;
        }
    }

    void StartFadeOut()
    {
        background_GBM.Stop();

        // パネルの表示をON
        fadeimage.enabled = true;

        // 不透明度を徐々に上げる
        alfa += fadespeed;

        // 変更した透明度をパネルに反映
        SetAlpha();

        // 完全に透明になったら処理を終了
        if (alfa >= 1)
        {
            if(_changeflg_retry == true)
            {
                //ゲームメインへ
                //SceneManager.LoadScene("Main");
            }
            else if(_changeflg_title == true)
            {
                // タイトルへ
                SceneManager.LoadScene("Title");
            }
        }
    }

    void SetAlpha()
    {
        fadeimage.color = new Color(red, green, blue, alfa);
    }
}
