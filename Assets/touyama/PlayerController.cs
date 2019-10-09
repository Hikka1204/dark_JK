using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    Jump PlayerJump;
    public byte flg = 0;
    Color color;
    public GameObject zombi;
    GameObject Sword;

    Sword Sword_script;

    // Use this for initialization
    void Start () {
        zombi.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        Sword = GameObject.Find("katana");
        Sword_script = Sword.GetComponent<Sword>();

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0) && flg == 0)
        {
            flg = 1;
        }

        //Debug.Log(flg);

        switch (flg)
        {
            case 1:
                
                if(GetComponent<Jump>().PlayerJump() == false)
                {
                    flg = 0;
                }
                break;

            case 2:
                Debug.Log(zombi.GetComponent<Renderer>().material.color);
                color = GetComponent<Renderer>().material.color;
                color = new Color(color.r, color.g, color.b, color.a - 0.05f);
                GetComponent<Renderer>().material.color = color;
                color = zombi.GetComponent<Renderer>().material.color;
                color = new Color(color.r, color.g, color.b, color.a + 0.05f);
                zombi.GetComponent<Renderer>().material.color = color;

                if(color.a >= 1.0f)
                {
                    flg = 3;
                    
                }
                break;

        }
    }

    public void SetFlg(byte _flg)
    {

        flg = _flg;
    }

    public byte GetFlg()
    {
        return flg;
    }

    void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "ENEMY" && Sword_script.flg == false) 
        {
            Debug.Log("感染した");
            SetFlg(2);
            

        }

        if (Collision.gameObject.tag == "Obutu" && flg == 0)
        {
            Debug.Log("衝突した");
        }
    }

}
