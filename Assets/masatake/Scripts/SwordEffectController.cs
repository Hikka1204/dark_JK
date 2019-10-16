using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordEffectController : MonoBehaviour {

    float fillAmount = 0;
    float alpha = 1.0f;

	//// Use this for initialization
	//void Start () {
		
	//}
	
	// Update is called once per frame
	void Update () {
        if (fillAmount < 1.0f)
        {
            fillAmount += 0.03f;
            GetComponent<Image>().fillAmount = fillAmount;
        }
        else if (alpha > 0)
        {
            alpha -= 0.1f;
            GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, alpha);
        }
        else
            Destroy(this.gameObject, 0.1f);
	}
}
