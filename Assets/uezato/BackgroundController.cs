using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    public int Tcount;
    public float scroll;
    GameObject ENEMY; //Unityちゃんそのものが入る変数

    ENEMYMOVE script; //UnityChanScriptが入る変数

        void Start()
    {
        ENEMY = GameObject.Find("ENEMY"); //Unityちゃんをオブジェクトの名前から取得して変数に格納する
        script = ENEMY.GetComponent<ENEMYMOVE>(); //unitychanの中にあるUnityChanScriptを取得して変数に格納する
        scroll = -0.1f;
    }
    
    void Update()
    {
        Debug.Log(script.Sflg);
        if (script.Sflg == 1)
        {
            Scrollstop();
        }else if (Tcount++ / 3 == 600)
             {
                scroll -= 0.1f;
                Tcount = 0;
             }
       
        transform.Translate(scroll, 0, 0);

        if (transform.position.x < -18.5f) //切り替わるタイミング
        {
            transform.position = new Vector3(18.25f, 0, 0);
        }
    }
    void Scrollstop()
    {
        scroll = 0;
        Debug.Log("GAMEOVER");
    }
}

