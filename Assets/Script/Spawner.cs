using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

// Definizione della classe personalizzata per ItemType
[System.Serializable]
public class ItemType
{
    public Item item;       // Riferimento all'oggetto Item
    public float probability;   // Probabilità dell'oggetto
    public float incresceProbability; // Aumento della probabilità
}

public class RangeProb
{
    public Item item;
    public float startProb;
    public float finishProb;

    public RangeProb(Item item, float startProb, float finishProb)
    {
        this.item = item;
        this.startProb = startProb;
        this.finishProb = finishProb;
    }
}

public class Spawner : MonoBehaviour
{
    public Transform BG;
    //TODO: vedere se servono dei oggetti
    public List<ItemType> items;

    public int rows = 3;
    public float height = 1;

    public float timeSpawn = 3;
    private float startTime;

    private List<RangeProb> rangeProbabilities = new();

    private bool notStart = false;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

        Rinormalize();

        notStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        float newTime = Time.time;

        if(newTime >= startTime + timeSpawn)
        {
            //item random TODO: rendere lo spawn diversamente random (ogni oggetto ha una probailità diversa)
            double randoProbability = Math.Round(UnityEngine.Random.Range(0f, 1f), 3); 

            RangeProb spawningItem = rangeProbabilities.Find((element) => { return element.startProb <= randoProbability && element.finishProb > randoProbability; });


            int randoRow = UnityEngine.Random.Range(0, rows);
            Item itemSpawn = Instantiate(spawningItem.item, new Vector3(transform.position.x, transform.position.y + randoRow * height, transform.position.z), transform.rotation);

            itemSpawn.transform.SetParent(BG);

            startTime = newTime;
        }
        
    }

// Rinormalizzazione delle probabilità: da ottimizzare se possibile
    public void Rinormalize()
    {
        rangeProbabilities.RemoveAll((i)=> { return true; });

        // vedere se conviene passargli il parametro items come variabile (scalabilità)

        float totProb = 0f;
        for (int i = 0; i < items.Count; i++)
        {
            float probability = items[i].probability;

            //incremento delle probabilità degli oggetti ogni volta che viene richiamata la funzione tranne la prima volta
            if (notStart) {
                probability += items[i].incresceProbability;
                items[i].probability = probability;
            }

            totProb += probability;
        }

        for (int i = 0; i < items.Count; i++)
        {

            float prob = items[i].probability / totProb;

            rangeProbabilities.Add(new RangeProb(items[i].item,
            rangeProbabilities.Count == 0f ? 0f : rangeProbabilities[i - 1].finishProb,
            rangeProbabilities.Count == 0f ? prob : rangeProbabilities[i - 1].finishProb + prob));
            
        }
    }


}
