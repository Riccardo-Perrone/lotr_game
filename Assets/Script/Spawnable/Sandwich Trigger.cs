using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool effectiveHealth;
        if (collision.name == "Player")
        {
            effectiveHealth = collision.GetComponent<Hearts>().Health();

            if (effectiveHealth)
            {
                GetComponent<Item>().PlaySound();
            }
        }
    }
}
