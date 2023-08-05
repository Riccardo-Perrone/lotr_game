using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Hearts : MonoBehaviour
{

    public Vector3 startPosition = new (0, 0, 0); // La posizione desiderata dell'immagine

    public Sprite fullHeartImg;
    public Sprite emptyHeartImg;
    public float size = 2;

    public Transform HUD;

    private readonly List<GameObject> hearts = new();

    private int totalHit = 0;
    public int maxHearts = 4;


    // Start is called before the first frame update
    void Start()
    {
        InitHearts(0);
    }

    /* empty: il numero dei cuori vuori < max (puo servire come cambio scena)
     */
    public void InitHearts(int empty)
    {
        for(int i= 1; i <= maxHearts; i++)
        {
            Vector2 position = new(startPosition.x * i, startPosition.y);

            hearts.Add(CreateHeart("fullHeart "+ i, fullHeartImg, position));
            CreateHeart("emptyHeart "+ i, emptyHeartImg, position);
        }
        for (int i = 1; i <= empty; i++)
        {
            Hit();
        }
    }

    public void Hit()
    {
        if (totalHit < maxHearts)
        {
            hearts[totalHit].SetActive(false);
            totalHit++;
        }
         CheckDeath();

    }

    void CheckDeath()
    {
        if(totalHit >= maxHearts)
        {
            MainManager.Instance.win = false;
            SceneManager.LoadScene("end");
        }

    }

    public void Health()
    {
        if (totalHit > 0)
        {
            totalHit--;
            hearts[totalHit].SetActive(true);
        }
    }


    GameObject CreateHeart(string nameHeart,Sprite img, Vector2 position)
    {
        // Creazione del nuovo oggetto Image
        GameObject newImageObject = new (nameHeart);
        newImageObject.transform.SetParent(HUD, false); // Imposta il Canvas come genitore, false per mantenere la posizione relativa al Canvas
        Image imageComponent = newImageObject.AddComponent<Image>();

        //aggiungo l'immagine
        imageComponent.sprite = img;


        // Ottieni il componente RectTransform dell'immagine
        RectTransform rectTransform = newImageObject.GetComponent<RectTransform>();

        // Imposta l'Anchor Preset in alto (top) e a destra (right)
        rectTransform.anchorMin = new Vector2(1, 1);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.pivot = new Vector2(1, 1); // Imposta anche il pivot in alto a destra

        // Setta la trasformazione dell'immagine secondo la posizione desiderata
        rectTransform.anchoredPosition = position;
        rectTransform.localScale = new Vector2(size, size);

        return newImageObject;
       }
}
