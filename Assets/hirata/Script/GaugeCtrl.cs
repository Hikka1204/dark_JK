using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class GaugeCtrl : MonoBehaviour
{
    
    public Image ui;

    bool hitflg;

    Color[] color;
    public Sprite[] giratina;
    float Gauge;

    bool Feverflg;  //フィーバー
    Slider _slider;
   
   


    void Start()
    {
        Gauge = 0;
        // スライダーを取得する
        _slider = GameObject.Find("Slider").GetComponent<Slider>();

       

        ui.GetComponent<Image>().sprite = giratina[0];
        

        Feverflg = false;           //フィーバーフラグ
        color = new Color[2];
        color[0] = ui.GetComponent<Image>().color;
        color[1] = new Color(0.8396f, 0f, 0f);


    }

    



    void Update()
    {
        hitflg = Scoretest.Gethitflg();
        Debug.Log(hitflg);
        if (Feverflg==false&&hitflg==true)
        {
            // HP上昇
            Gauge += 0.2f;
            if (Gauge>=1)
            {
         
                Feverflg = true;
                ui.GetComponent<Image>().color = color[1];
                ui.GetComponent<Image>().sprite = giratina[1];
            }
        }
        if (Feverflg == true)
        {


            Gauge -= 0.1f;
            if (Gauge <= 0)
            {
                Feverflg = false;
                ui.GetComponent<Image>().color = color[0];
                ui.GetComponent<Image>().sprite = giratina[0];
            }
        }

        // HPゲージに値を設定
        ui.GetComponent<Image>().fillAmount = Gauge;

    }
}