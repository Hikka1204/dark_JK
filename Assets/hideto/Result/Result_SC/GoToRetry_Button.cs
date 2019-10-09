using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToRetry_Button : MonoBehaviour {
    public static bool changeflg_retry;

    void Start()
    {
        changeflg_retry = false;   
    }

    public void OnClick()
    {
        changeflg_retry = true;
        getChangeFlg_Retry();
    }

    public static bool getChangeFlg_Retry()
    {
        return changeflg_retry;
    }
}
