using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPayer : MonoBehaviour
{
    public float speed = 10;
    public float scaleEffect = 1;

    public float maxY = 3;
    public float minY = -3;


    // Update is called once per frame
    void Update()
    {

        float input = Input.GetAxis("Vertical");

        //limiti sopra e sotto
        if(transform.position.y <= minY && input < 0 || transform.position.y >= maxY && input > 0)
        {
            return;
        }
        
        transform.position = new Vector3(0, transform.position.y + input * Time.deltaTime * speed, 0);
        transform.localScale = new Vector3(transform.localScale.x + -input * Time.deltaTime * scaleEffect, transform.localScale.y + -input * Time.deltaTime * scaleEffect);
    }
}
