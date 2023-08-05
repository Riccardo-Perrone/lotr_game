using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI textField;
    // Start is called before the first frame update
    void Start()
    {
        if (MainManager.Instance.win)
            textField.text = "Hai VINTO";
        else
        {
            textField.text = "Hai PERSO";

        }
    }

}
