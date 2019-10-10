using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sword : MonoBehaviour {

    public AudioClip sound1;
    AudioSource audioSource;

    //public GameObject obj;      //親にしたいオブジェクトを入れておく
    public int SwordInitcount;
    public float InitRotation;
    public float SwordSpeed;



    PlayerController script;

    PlayerController GetFlg;

    Color color;

    // 位置座標
    private Vector3 mouseposition;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;


    public bool flg = false;
    int Swordcount = 0;
    

	// Use this for initialization
	void Start () {
        
        script = transform.root.GetComponent<PlayerController>();
        audioSource = GetComponent<AudioSource>();

        this.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {


        // Vector3でマウス位置座標を取得する
        mouseposition = Input.mousePosition;
        // Z軸修正
        mouseposition.z = 0.0f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(mouseposition);



        if (Input.GetMouseButtonDown(0) && flg == false && screenToWorldPointPosition.x >= 0 &&　script.flg == 0)
        {
            Swordcount = SwordInitcount;

            if (transform.root.gameObject.GetComponent<Animator>().GetBool("SwingFlag") == false)
            {
                audioSource.PlayOneShot(sound1);
            }

            transform.root.gameObject.GetComponent<CallAnimation>().CallSwingSwordAnim();

            flg = true;

            //transform.root.gameObject.GetComponent<CallAnimation>().CallSwingSwordAnim();
            //GetComponent<Animator>().GetBool("SwingFlag") == false
            
        }

        if (flg == true && Swordcount-- <= 0)
        {
            flg = false;
        }

        if (transform.root.gameObject.GetComponent<PlayerController>().GetFlg() == 2)
        {
            color = this.GetComponent<Renderer>().material.color;
            color = new Color(color.r, color.g, color.b, 0.0f);
            GetComponent<Renderer>().material.color = color;
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

