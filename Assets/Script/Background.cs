using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed = 3;
    public float size = 10;

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(transform.position.x + -speed * Time.deltaTime, 0, 0);
        if(transform.position.x < - size * 1.5)
        {
            transform.position = new Vector3(transform.position.x + size*3, 0, 0);
        }
    }
}
