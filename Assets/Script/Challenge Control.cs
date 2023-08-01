using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeControl : MonoBehaviour
{
    public float speed = 3f;
    public Background background;

    public Item item;

    public Spawner spawner;

    public float challenge = 0.1f;
    // Start is called before the first frame update
    void Awake()
    {
        background.SetSpeed(speed);
        //item.SetSpeed(speed);
    }

    private void Start()
    {

        InvokeRepeating(nameof(UpdateItemSpawn), 0f, 1.0f);

    }
    // Update is called once per frame
    void Update()
    {
        //TODO: farlo in modo logaritmico
        speed += challenge * Time.deltaTime;

        background.SetSpeed(speed);
        //item.SetSpeed(speed);

    }

    void UpdateItemSpawn()
    {
        spawner.Rinormalize();
    }
}
