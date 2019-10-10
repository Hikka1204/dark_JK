using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class GaugeCtrl : MonoBehaviour
{
    
    public Image ui;

    bool hitflg;

    Color[] color;
    public Sprite[] GaugeImage;
    float Gauge;

    bool Feverflg;  //フィーバー
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

    



    void Update()
    {
        hitflg = EnemyScore.Gethitflg();
        
        if (Feverflg==false&&hitflg==true)
        {
            // HP上昇
            Gauge += 0.2f;
            Debug.Log(hitflg);
            if (Gauge>=1)
            {
         
                Feverflg = true;
                ui.GetComponent<Image>().color = color[0];
                ui.GetComponent<Image>().sprite = GaugeImage[1];
            }
        }
        if (Feverflg == true)
        {


            Gauge -= 0.05f;
            if (Gauge <= 0)
            {
                Feverflg = false;
                ui.GetComponent<Image>().color = color[0];
                ui.GetComponent<Image>().sprite = GaugeImage[0];
            }
        }

        // HPゲージに値を設定
        ui.GetComponent<Image>().fillAmount = Gauge;

    }
}