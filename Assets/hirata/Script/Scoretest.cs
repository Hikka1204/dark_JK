using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoretest : MonoBehaviour
{

    public static bool hitflg;


	// Use this for initialization
	void Start ()
    {
        hitflg =false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		
        if(Input.GetMouseButtonDown(0))
        {
            hitflg = true;
            Gethitflg();
        }
        else
        {
            hitflg = false;
            Gethitflg();
        }
        
	}

    public static bool Gethitflg()
    {
        return hitflg;
    }
}
