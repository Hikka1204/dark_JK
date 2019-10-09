
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class AppearScript : MonoBehaviour
{
    public int fever = 1;
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


    }

    // Update is called once per frame
    void Update()
    {

        appearNextTime = Random.Range(3f, 15f);

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
        var randomValue = Random.Range(0, enemys.Length);
        //　敵の向きをランダムに決定
        //var randomRotationY = Random.value * 360f;
        
        //if(fever == 1)
        //{
        //    randomValue = 0;
        //}

        GameObject.Instantiate(enemys[randomValue], transform.position, Quaternion.Euler(0f, 0f, 0f));

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
}
