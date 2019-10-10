using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class ScoreManager : MonoBehaviour
{

    GameObject gage; //Unityちゃんそのものが入る変数
    GaugeCtrl Uscript; //UnityChanScriptが入る変数

    public GameObject score_object = null; // Textオブジェクト
    
    // 初期化
    void Start()
    {
        gage = GameObject.Find("GaugeCtrl"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
        Uscript = gage.GetComponent<GaugeCtrl>(); //unitychanの中にあるUnityChanScriptを取得して変数に格納

    }

    // 更新
    void Update()
    {
        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();
        // テキストの表示を入れ替える
        score_text.text = "s";
    }
}