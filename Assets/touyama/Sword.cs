using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public GameObject obj;      //親にしたいオブジェクトを入れておく
    public int SwordInitcount;
    public float InitRotation;
    public float SwordSpeed;

    GameObject Player; 

    PlayerController script; 

    bool flg = false;
    int Swordcount = 0;
    float rotation_z;
    

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player");
        script = Player.GetComponent<PlayerController>();

        this.gameObject.SetActive(true);
        Vector3 localAngle = obj.transform.localEulerAngles;
        localAngle.z = InitRotation; // ローカル座標を基準に、z軸を軸にした回転をInitRotation度に変更
        obj.transform.localEulerAngles = localAngle; // 回転角度を設定
    }
	
	// Update is called once per frame
	void Update () {


        Vector3 localAngle = obj.transform.localEulerAngles;

        if (Input.GetMouseButtonDown(1) && flg == false && script.flg == 0)
        {
            Swordcount = SwordInitcount;

            // ローカル座標を基準に、回転を取得
            localAngle.z = InitRotation; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
            obj.transform.localEulerAngles = localAngle; // 回転角度を設定


            this.gameObject.SetActive(true);
            flg = true;
        }

        if (flg == true && Swordcount-- <= 0)
        {
            //this.gameObject.SetActive(false);
            flg = false;
            localAngle.z = InitRotation; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
            obj.transform.localEulerAngles = localAngle; // 回転角度を設定
        }

        else if (flg == true)
        {
            obj.transform.Rotate(0, 0, -SwordSpeed);
        }

    }

    


    void OnTriggerEnter2D(Collider2D Collision)
    {
        if (Collision.gameObject.tag == "ENEMY" && flg == true)
        {
            Debug.Log("倒した");
        }
    }


}

