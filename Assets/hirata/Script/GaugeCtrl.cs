using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class GaugeCtrl : MonoBehaviour
{
    
    public Image ui;
    

    public GameObject score_object = null; // Textオブジェクト

    Color[] color;
    public Sprite[] GaugeImage;

    public float Tcount;

    float Gauge;
    public int Score;

    public bool Feverflg;  //フィーバー
    Slider _slider;
   
   


    void Start()
    {
        Gauge = 0;
        // スライダーを取得する
        //_slider = GameObject.Find("Slider").GetComponent<Slider>();

       
        ui.GetComponent<Image>().sprite = GaugeImage[0];
        

        Feverflg = false;           //フィーバーフラグ
        color = new Color[2];
        color[0] = ui.GetComponent<Image>().color;
        color[1] = new Color(0.8396f, 0f, 0f);

        // オブジェクトからTextコンポーネントを取得
        score_object.GetComponent<Text>().text = "Score : 0";

    }



    public void ScoreCtrl()
    {

        if(Feverflg==false)//フィーバーではないとき
        {
            Debug.Log(Gauge);
            Gauge += 0.1f;
            if (Gauge >= 1.0f)
            {
                Debug.Log(Gauge);
                Feverflg = true;
                ui.GetComponent<Image>().color = color[0];
                ui.GetComponent<Image>().sprite = GaugeImage[1];
            }
             ui.GetComponent<Image>().fillAmount = Gauge;
        }
        Score += 500;

        // オブジェクトからTextコンポーネントを取得
        Text score_text = score_object.GetComponent<Text>();

        // テキストの表示を入れ替える
        score_text.text = "Score : " + Score;


    }

    void Update()
    {

        ui.GetComponent<Image>().fillAmount = Gauge;
        Debug.Log(Feverflg);

        if (Feverflg == true)
        {
            Gauge -= 0.005f;

            //if (Tcount++ / 30 == 1) { 
            //         Gauge -= 0.15f;
            //        Tcount = 0;
            //     }
            if (Gauge <= 0)
            {
                Feverflg = false;
                ui.GetComponent<Image>().color = color[0];
                ui.GetComponent<Image>().sprite = GaugeImage[0];
                Gauge = 0;
                
            }
            ui.GetComponent<Image>().fillAmount = Gauge;
        }




    }

    public int GetScore()
    {
        return Score;
    }
}