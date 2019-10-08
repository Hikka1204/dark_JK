using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public GameObject Sw;
    public GameObject obj;      //親にしたいオブジェクトを入れておく
    public int SwordInitcount;
    public float InitRotation;
    public float SwordSpeed;

    int flg = 0;
    int Swordcount = 0;
    float rotation_z;
    

	// Use this for initialization
	void Start () {
        Sw.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        //transformを取得
        Transform myTransform = this.transform;

        //objを親として設定
        myTransform.parent = obj.transform;

        Vector3 localAngle = obj.transform.localEulerAngles;


        if (Input.GetMouseButtonDown(1) && flg == 0)
        {
            Swordcount = SwordInitcount;

            // ローカル座標を基準に、回転を取得
            localAngle.z = InitRotation; // ローカル座標を基準に、z軸を軸にした回転を10度に変更
            obj.transform.localEulerAngles = localAngle; // 回転角度を設定


            Sw.SetActive(true);
            flg = 1;
        }



        if (flg == 1 && Swordcount-- <= 0)
        {
            Sw.SetActive(false);
            flg = 0;
        }
        else if (flg == 1)
        {
            obj.transform.Rotate(0, 0, -SwordSpeed);
        }

        //transform.position = new Vector2(transform.position.x, Player1.transform.position.y);

    }
}
