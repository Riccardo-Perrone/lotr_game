using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger2D HIT");
    }
}
