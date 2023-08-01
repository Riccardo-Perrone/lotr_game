using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{
    private float speed = 0;

    // Use this for initialization
    void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        transform.position = new Vector3(transform.position.x + -speed * Time.deltaTime, 0, 0);
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }
}

