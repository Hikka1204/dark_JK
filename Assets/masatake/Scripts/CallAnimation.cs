using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallAnimation : MonoBehaviour {

    Animator PlayerAnimator;
    [SerializeField] Image SwordEffectPre;
    [SerializeField] GameObject canvas;

    private void Start()
    {
    }

    //private void Update()
    //{
    //    if(Input.GetMouseButtonDown(0))
    //    {
    //        CallSwingSwordAnim();
    //    }

    //    Debug.Log(PlayerAnimator.GetBool("SwingFlag"));
    //}

    // 剣を振るアニメーションを再生
    public void CallSwingSwordAnim()
    {
        // 剣のエフェクトを生成
        Image swordeffect = Instantiate(SwordEffectPre);
        swordeffect.transform.SetParent(canvas.transform, false);

        //PlayerAnimator.Play("SwingSword");
        PlayerAnimator = GetComponent<Animator>();
        PlayerAnimator.SetBool("SwingFlag", true);
    }

    // SwingFlagをfalseにセット
    public void SwingFlag()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerAnimator.SetBool("SwingFlag", false);
    }

    // 剣を振る速度を変更
    public void SwingSpeedChange(bool flg)
    {
        PlayerAnimator = GetComponent<Animator>();

        // フラグがfalseならスピードを元に戻す
        if(!flg)
        {
            PlayerAnimator.SetFloat("Speed", 3);
        }
        // フラグがtrueならスピードを上げる
        else
        {
            PlayerAnimator.SetFloat("Speed", 5);

        }
    }

    // ゲームオーバー処理へ
    public void GameOverFlagSet()
    {
        PlayerAnimator = GetComponent<Animator>();
        PlayerAnimator.SetBool("GameOverFlag", true);
    }
}
