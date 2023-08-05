using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteEffect : MonoBehaviour
{
    [SerializeField] Material material;

    public float minEffect = 45f;

    public float maxEffect = 75f;

    public float incresceEffect = 0.1f;

    private float value;
    private bool effectIncresce = true;

    private void Start()
    {
        value = minEffect;
    }

    private void Update()
    {
        if (effectIncresce) {
            value += incresceEffect * Time.deltaTime;
            if (value>maxEffect) {
                effectIncresce = false;
            }
        }
        else
        {
            value -= incresceEffect * Time.deltaTime;
            if (value < minEffect)
            {
                effectIncresce = true;
            }
        }
        material.SetFloat("_WhiteEffect",value);

    }
}
