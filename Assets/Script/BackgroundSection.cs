using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSection : MonoBehaviour
{
    public float size = 10;

    // Update is called once per frame
    void Update()
    {

        if(transform.position.x < - size * 1.5)
        {
            transform.position = new Vector3(transform.position.x + size*3, transform.position.y, transform.position.z);
        }
    }


}
