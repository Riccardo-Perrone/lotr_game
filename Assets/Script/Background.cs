using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.LookDev;

public class Background : MonoBehaviour
{
    public float speed = 0; //in game viene settata dal'challenge controller in start e end sono statici
    public Transform ground;
    public Transform layer1;
    public float percSpeedLayer1 = 1;
    public Transform layer2;
    public float percSpeedLayer2 = 1;
    public Transform sky;
    public float percSpeedSky = 1;


    // Use this for initialization
    void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
        ground.position = new Vector3(ground.position.x + -speed * Time.deltaTime, ground.position.y, ground.position.z);
        layer1.position = new Vector3(layer1.position.x + -speed * percSpeedLayer1 * Time.deltaTime, layer1.position.y, layer1.position.z);
        layer2.position = new Vector3(layer2.position.x + -speed * percSpeedLayer2 * Time.deltaTime, layer2.position.y, layer2.position.z);
        sky.position = new Vector3(sky.position.x + -speed * percSpeedSky * Time.deltaTime, sky.position.y, sky.position.z);
    }

    public void SetSpeed(float value)
    {
        speed = value;
    }
}

