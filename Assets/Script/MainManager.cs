using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public bool win;

    private void Awake()
    {
        Debug.Log(Instance);
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
