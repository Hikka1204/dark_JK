using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour {

    Jump PlayerJump;
    public byte flg = 0;
    Color color;
    public GameObject zombi;
    GameObject Sword;

    public AudioClip sound1;
    AudioSource audioSource;


    Sword Sword_script;

    public Renderer[] PlayerPearts;

    // 位置座標
    private Vector3 mouseposition;
    // スクリーン座標をワールド座標に変換した位置座標
    private Vector3 screenToWorldPointPosition;


    // Use this for initialization
    void Start () {
        zombi.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        Sword = GameObject.Find("wrist");
        Sword_script = Sword.GetComponent<Sword>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update () {

        // Vector3でマウス位置座標を取得する
        mouseposition = Input.mousePosition;
        // Z軸修正
        mouseposition.z = 0.0f;
        // マウス位置座標をスクリーン座標からワールド座標に変換する
        screenToWorldPointPosition = Camera.main.ScreenToWorldPoint(mouseposition);


        if (Input.GetMouseButtonDown(0) && screenToWorldPointPosition.x < 0 && flg == 0 )
        {
            flg = 1;
            GetComponent<Animator>().enabled = false;
            
        }

        //Debug.Log(flg);

        switch (flg)
        {
            case 1:
                
                if(GetComponent<Jump>().PlayerJump() == false)
                {
                    flg = 0;
                    GetComponent<Animator>().enabled = true;
                }
                break;

            case 2:
                Debug.Log(zombi.GetComponent<Renderer>().material.color);
                color = GetComponent<Renderer>().material.color;
                color = new Color(color.r, color.g, color.b, color.a - 0.05f);
                GetComponent<Renderer>().material.color = color;
                
                for(int i = 0; i < 10; i++)
                {
                    PlayerPearts[i].GetComponent<Renderer>().material.color = color;
                }

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
        GameObject.Find("Text").GetComponent<Text>().text = "109";
        GameObject.Find("Text2").GetComponent<Text>().text = GetComponent<Animator>().GetBool("SwingFlag").ToString();

        if (Collision.gameObject.tag == "ENEMY" && GetComponent<Animator>().GetBool("SwingFlag") == false)
        {
            GameObject.Find("Text").GetComponent<Text>().text = "114";
            Debug.Log("感染した");
            SetFlg(2);
            GameObject.Find("Text").GetComponent<Text>().text = "115";
            audioSource.PlayOneShot(sound1);

            StartCoroutine("SceneMove");
        }

        if (Collision.gameObject.tag == "Obutu" && flg == 0)
        {
            Debug.Log("衝突した");
            GetComponent<CallAnimation>().GameOverFlagSet();
            StartCoroutine("SceneMove");
        }
    }

    IEnumerator SceneMove()
    {
        yield return new WaitForSeconds(1.0f);
        GameObject.Find("Text").GetComponent<Text>().text = "130";
        SceneManager.LoadScene("Result");
    }

}
