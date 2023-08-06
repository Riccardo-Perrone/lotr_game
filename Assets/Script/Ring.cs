using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Ring : MonoBehaviour, IPointerClickHandler
{
    public BoxCollider2D playerCollider;
    public SpriteRenderer playerRerender;
    public float durationTime = 3;
    public float coolDown = 7;
    public Animator animatorRing;

    private bool ringActivated = false;
    private float startTime;
    private float finalTime;

    private Image imageReference;


    private bool ringReady = true;




    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        finalTime = Time.time;
        imageReference = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;

        if (time > startTime + durationTime && ringActivated)
        {
            finalTime = time;
        }

        ringReady = time >= finalTime + coolDown;

        if (ringReady)
        {
            RingReady();
        } else
        {
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
                finalTime = Time.time;
                ringActivated = false;
                DeactivateAnimation();
                ActivatePlayer();
                //TODO: Cooldown da diminuire in percentuale a quello non usato in precedenza
                RingInCooldown();
            }
            else
            {
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

    private void RingInCooldown()
    {
        ringReady = false;
        imageReference.color = new Color(1f, 1f, 1f, .75f);

    }

    private void RingReady()
    {
        imageReference.color = new Color(1f, 1f, 1f, 1f);

    }
}
