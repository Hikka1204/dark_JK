
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class AppearScript : MonoBehaviour
{
    GameObject haikei; //Unityちゃんそのものが入る変数
    BackgroundController script; //UnityChanScriptが入る変数

    GameObject gage; //Unityちゃんそのものが入る変数
    GaugeCtrl Uscript; //UnityChanScriptが入る変数


    GameObject ENEMY; //Unityちゃんそのものが入る変数
    BackgroundController escript; //UnityChanScriptが入る変数
    public bool feverenemy = false;
    public bool feverflg = false;
    private int fever = 1;
    //　出現させる敵を入れておく
    [SerializeField] GameObject[] enemys;
    //　次に敵が出現するまでの時間
    [SerializeField] float appearNextTime = -0.1f;
    //　この場所から出現する敵の数
    [SerializeField] int maxNumOfEnemys;
    //　今何人の敵を出現させたか（総数）
    private int numberOfEnemys;
    //　待ち時間計測フィールド
    private float elapsedTime;

    // Use this for initialization
    void Start()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;
        // Destroy(gameObject, 10f); // 三秒後に削除

        haikei = GameObject.Find("haikei"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
        script = haikei.GetComponent<BackgroundController>(); //unitychanの中にあるUnityChanScriptを取得して変数に格納する


        // ENEMY = GameObject.Find("ENEMY"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
        //escript = ENEMY.GetComponent<ENEMYMOVE>(); //unitychanの中にあるUnityChanScriptを取得して変数に格納する

        gage = GameObject.Find("GaugeCtrl"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
        Uscript = gage.GetComponent<GaugeCtrl>(); //unitychanの中にあるUnityChanScriptを取得して変数に格納

    }
    
    // Update is called once per frame
    void Update()
    {
      feverflg =  Uscript.Feverflg;
        
       // Tecount
        if (feverflg == false)
        {
            if (script.Getscroll() == -0.1f || script.Getscroll() == -0.15f)appearNextTime = Random.Range(3f, 6f);
             if (script.Getscroll() == -0.2f|| script.Getscroll() == -0.25f) appearNextTime = Random.Range(1.5f, 4f);
              if (script.Getscroll() <= -0.3f) appearNextTime = Random.Range(1.5f, 2.5f);



        }
        else appearNextTime = 1f;

        //if (elapsedTime == 15f)
        //{
        //    numberOfEnemys--;

        //}

        ////　この場所から出現する最大数を超えてたら何もしない
        //if (numberOfEnemys >= maxNumOfEnemys)
        //{

        //    return;
        //}
        //　経過時間を足す
        elapsedTime += Time.deltaTime;


        //　経過時間が経ったら
        if (elapsedTime > appearNextTime)
        {
            elapsedTime = 0f;

            AppearEnemy();
        }


       // Destroy(gameObject, 1.0f); // 三秒後に削除

    }
    //　敵出現メソッド
    void AppearEnemy()
    {
        //　出現させる敵をランダムに選ぶ
        // var randomValue = Random.Range(0, enemys.Length);
        //　敵の向きをランダムに決定
        //var randomRotationY = Random.value * 360f;

        //if(fever == 1)
        //{
        //    randomValue = 0;
        //}
        if (feverflg == false)
        {
            if (Probability(30))
            {
                if (Probability(30))
                {
                    //30％の確率で起こるイベント
                    fever = 1;
                }
                else if (Probability(30))
                {
                    fever = 2;
                }
                else fever = 3;
            }
            else fever = 0;
            feverenemy = false;
        }
        else
        {
            fever = 0;
            feverenemy = true;
        }
        Debug.Log(fever);
        GameObject.Instantiate(enemys[fever], transform.position, Quaternion.Euler(0f, 0f, 0f));

        numberOfEnemys++;
        elapsedTime = 0f;
    }
    public static bool Probability(float fPercent)
    {
        float fProbabilityRate = UnityEngine.Random.value * 100.0f;

        if (fProbabilityRate < fPercent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Setfever(bool _feverflg)
    {

        feverflg = _feverflg;
    }


    public bool Getfever()
    {
        return feverflg ;
    }
}
