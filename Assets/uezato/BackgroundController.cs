using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(-0.1f, 0, 0);
        if (transform.position.x < -16.5f)
        {
            transform.position = new Vector3(16.4f, 0, 0);
        }
    }
}
