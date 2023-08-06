using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class Ring : MonoBehaviour, IPointerClickHandler
{
    public BoxCollider2D playerCollider;
    public SpriteRenderer playerRerender;

    public float maxDurationTime = 3;
    public float maxCooldown = 7;

    public Animator animatorRing;

    public TextMeshProUGUI textCooldown;
    public Image pannelColldown;

    public Image imageReference;

    private float startTime;
    private float finalTime;

    private bool ringActivated = false;
    private bool ringReady = true;

    private float actualCooldown = 0;




    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        finalTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;

        //scadenza durata ring
        // ring active ---> ring in cooldown   |   player deactive ---> player active
        if (time > startTime + maxDurationTime && ringActivated)
        {
            finalTime = time;
            ringActivated = false;
            ringReady = false;
    

            ActivatePlayer();
            CooldownActual(maxDurationTime);
        }

        //vedo se il cooldown è finito
        //ring in cooldown ---> ring ready

        if (ringReady)
        {
            RingReady();
        } else
        {
            //show cooldown
            textCooldown.text = (Mathf.FloorToInt(actualCooldown)).ToString();
            actualCooldown -= 1 * Time.deltaTime;

            RingInCooldown();
            DeactivateAnimation();
        }


    }

    //Detect if a click occurs
    public void OnPointerClick(PointerEventData pointerEventData)
    {

        if (ringReady)
        {
            ActivateAnimation();
            if (ringActivated)
            {
                //clicco per disattivare l'anello prima del previsto
                //ring active ---> ring in cooldown    |    deactive player ---> active player

                finalTime = Time.time;
                ringActivated = false;
                DeactivateAnimation();
                ActivatePlayer();
                //TODO: Cooldown da diminuire in percentuale a quello non usato in precedenza
                CooldownActual(finalTime - startTime);
                RingInCooldown();
            }
            else
            {
                //clicco per attivate l'anello
                //ring ready ---> ring active   |   player active ---> player deactive
                startTime = Time.time;
                ringActivated = true;
                DeactivatePlayer();
            }
        }

    }

    private void ActivateAnimation()
    {
        animatorRing.SetTrigger("Click");
        animatorRing.SetBool("Deactivate", false);
    }

    private void DeactivateAnimation()
    {
        animatorRing.SetBool("Deactivate", true);
    }

    private void DeactivatePlayer()
    {
        playerCollider.enabled = false;
        playerRerender.color = new Color(1f, 1f, 1f, .75f);
    }

    private void ActivatePlayer()
    {
        playerCollider.enabled = true;
        playerRerender.color = new Color(1f, 1f, 1f, 1f);
    }

    private void CooldownActual(float durationRing)
    {
        float percDuration = durationRing / maxDurationTime;
        actualCooldown = maxCooldown * percDuration;
    }
    private void RingInCooldown()
    {
        textCooldown.enabled = true;
        pannelColldown.enabled = true;
        ringReady = actualCooldown <= 0;
        imageReference.color = new Color(1f, 1f, 1f, .75f);
    }

    private void RingReady()
    {
        textCooldown.enabled = false;
        pannelColldown.enabled = false;
        imageReference.color = new Color(1f, 1f, 1f, 1f);
    }
}
