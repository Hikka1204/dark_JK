﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {

    float JumpPower;
    float JumpSpeed;
    int JumpCount;



    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	//void Update () {

 //       if (Input.GetMouseButtonDown(0) && flg == 0)
 //       {
 //           this.JumpPower = JumpSpeed;
 //           flg = 1;
 //           //print("左ボタンが押されている");
 //       }
 //       if (flg == 1)
 //       {
 //           if (JumpCount++ <= 10)
 //               JumpPower = 0.2f;
 //           else if (JumpCount <= 20)
 //               JumpPower = 0.1f;
 //           else if (JumpCount <= 30)
 //               JumpPower = 0.05f;
 //           else if (JumpCount <= 40)
 //               JumpPower = -0.05f;
 //           else if (JumpCount <= 50)
 //               JumpPower = -0.1f;
 //           else if (JumpCount <= 60)
 //               JumpPower = -0.2f;
 //           else
 //           {
 //               flg = 0;
 //               JumpCount = 0;
 //               JumpPower = 0;
 //               transform.position = new Vector2(transform.position.x, -2.04f);
 //           }
 //       }


 //           transform.position = new Vector2(transform.position.x, transform.position.y + this.JumpPower);


 //       //if (Input.GetMouseButtonDown(0))
 //       //{
 //       //    this.JumpPower = JumpSpeed;
 //       //    flg = 1;
 //       //    //print("左ボタンが押されている");
 //       //}

 //       //if (this.JumpPower <= 0.01f && flg == 1)
 //       //{
 //       //    this.JumpPower = JumpSpeed;
 //       //    flg = 0;
 //       //    Gensui *= -1;
 //       //}

 //       //transform.position = new Vector2(transform.position.x, transform.position.y + this.JumpPower);

 //       //this.JumpPower *= Gensui;



 //   }
    public bool PlayerJump()
    {
        
        
        if (JumpCount++ <= 10)
            JumpPower = 0.2f;
        else if (JumpCount <= 20)
            JumpPower = 0.1f;
        else if (JumpCount <= 30)
            JumpPower = 0.05f;
        else if (JumpCount <= 40)
            JumpPower = -0.05f;
        else if (JumpCount <= 50)
            JumpPower = -0.1f;
        else if (JumpCount <= 60)
            JumpPower = -0.2f;
        else
        {
            JumpCount = 0;
            JumpPower = 0;
            transform.position = new Vector2(transform.position.x, -2.04f);
            return false;
        }

        transform.position = new Vector2(transform.position.x, transform.position.y + this.JumpPower);

        return true;
    }

}
