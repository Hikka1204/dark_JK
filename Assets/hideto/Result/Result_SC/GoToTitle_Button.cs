using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoToTitle_Button : MonoBehaviour {
    public static bool changeflg_title;

    void Start()
    {
        changeflg_title = false;
    }

    public void OnClick()
    {
        changeflg_title = true;
        getChangeFlg_Title();
    }

    public static bool getChangeFlg_Title()
    {
        return changeflg_title;
    }
}
