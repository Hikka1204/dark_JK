using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    Jump PlayerJump;
    public byte flg = 0;
    Color color;
    public GameObject zombi;

    // Use this for initialization
    void Start () {
        zombi.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0) && flg == 0)
        {
            flg = 1;
        }
        else if(flg == 0)
        {
            transform.position = new Vector2(transform.position.x, -2.04f);
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
                    flg = 0;
                    
                }
                break;

        }
    }

    public void SetFlg()
    {
        flg = 2;
    }

}
