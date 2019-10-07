using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createfloor : MonoBehaviour {

    public GameObject floor;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 15; i++)
        {
            float positionX = (i * 1.57f) + floor.transform.position.x;
            float positionY = floor.transform.position.y;
            Instantiate(floor, new Vector2(positionX, positionY), Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
