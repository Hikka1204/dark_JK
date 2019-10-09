using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class GaugeCtrl : MonoBehaviour
{
    
    public Image ui;


    Color[] color;
    public Sprite[] giratina;


    bool Feverflg;  //フィーバー
    Slider _slider;
   
    float Gauge = 0;            //ゲージ初期化


    void Start()
    {
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

        if (Input.GetMouseButtonDown(0)&&Feverflg==false)
        {
            // HP上昇
            Gauge += 0.2f;
            if (Gauge >= 1)
            {
                Feverflg = true;
                ui.GetComponent<Image>().color = color[1];
                ui.GetComponent<Image>().sprite = giratina[1];
            }
        }
        if (Feverflg == true)
        {
            

            Gauge -= 0.01f;
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