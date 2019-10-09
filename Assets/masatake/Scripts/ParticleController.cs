using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

    BackgroundController getScrollSpeed;

	// Use this for initialization
	void Start () {
        getScrollSpeed = GameObject.Find("haikei").GetComponent<BackgroundController>();
	}
	
	// Update is called once per frame
	void Update () {
        if(!this.GetComponent<ParticleSystem>().IsAlive())
        {
            Destroy(this.gameObject, 2.0f);
        }

        transform.Translate(getScrollSpeed.Getscroll(), 0, 0);
	}
}
