using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChallengeControl : MonoBehaviour
{
    public float timeToWin = 10f;


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
        timeToWin = Time.time + timeToWin;
        InvokeRepeating(nameof(UpdateItemSpawn), 0f, 1.0f);

    }
    // Update is called once per frame
    void Update()
    {
        //TODO: farlo in modo logaritmico
        speed += challenge * Time.deltaTime;

        background.SetSpeed(speed);
        //item.SetSpeed(speed);

        if (Time.time >= timeToWin) {
            MainManager.Instance.win = true;
            SceneManager.LoadScene("end");
        }

    }

    void UpdateItemSpawn()
    {
        spawner.Rinormalize();
    }


}
