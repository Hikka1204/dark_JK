using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class GaugeCtrl : MonoBehaviour
{
    
    public Image ui;

    

    Color[] color;
    public Sprite[] GaugeImage;

    
    float Gauge;
    int Score;

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


    }

    

    public void ScoreCtrl()
    {

        if(Feverflg==false)//フィーバーではないとき
        {
            Gauge += 0.2f;
            if (Gauge >= 1)
            {

                Feverflg = true;
                ui.GetComponent<Image>().color = color[0];
                ui.GetComponent<Image>().sprite = GaugeImage[1];
            }
             ui.GetComponent<Image>().fillAmount = Gauge;
        }
      Score += 500;

    }

    void Update()
    {
      
        
        
        if (Feverflg == true)
        {


            Gauge -= 0.05f;
            if (Gauge <= 0)
            {
                Feverflg = false;
                ui.GetComponent<Image>().color = color[0];
                ui.GetComponent<Image>().sprite = GaugeImage[0];
            }
            ui.GetComponent<Image>().fillAmount = Gauge;
        }

      
       

    }
}