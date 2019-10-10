using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallAnimation : MonoBehaviour {

    Animator PlayerAnimator;

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

}
