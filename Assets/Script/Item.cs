using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    //TODO: magari renderla che varia casualmente
    //TODO: se va sempre come il back ground come fare?
    //private float speed = 0;

    private bool toRemove = false;
    private bool isVilible = false;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
        if (toRemove)
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound()
    {
        audioSource.Play();
    }

    private void OnBecameVisible()
    {
        isVilible = true;
    }
    private void OnBecameInvisible()
    {
        if (isVilible)
        {
            toRemove = true;
        }
    }
}
