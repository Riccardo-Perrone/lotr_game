using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool effectiveHit;
        if (collision.name == "Player")
        {
            effectiveHit = collision.GetComponent<Hearts>().Hit();

            if (effectiveHit)
            {
                GetComponent<Item>().PlaySound();
            }
        }
    }
}
