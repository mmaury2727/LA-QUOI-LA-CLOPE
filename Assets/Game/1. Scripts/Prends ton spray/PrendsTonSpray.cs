using System.Collections;
using UnityEngine;

public class PrendsTonSpray : MonoBehaviour
{
    public GameObject GameOver;
    public GameObject ccSpray;
    public GameObject click;
    public GameObject Victory;
    public GameObject SpraySmoke;

    public AudioSource SpraySound; 
    public AudioSource victorySound;
    public AudioSource GameOverSound;

    private bool hasClickedAtRightMoment = false;
    private bool hasClickedTooEarlyOrLate = false;
    private bool isGameOver = false;
    private float startTime;

    private Animator animatorClick;
    private Animator animatorVictory;

    private bool clickEnabled = true;

    void Start()
    {
        animatorClick = click.GetComponent<Animator>();
        animatorVictory = Victory.GetComponent<Animator>();
        StartCoroutine(WaitForRightMoment());
    }



    IEnumerator EnableClickAfterDelay()
    {
        yield return new WaitForSeconds(3f); // Attendre 3 secondes avant d'activer le clic
        clickEnabled = true; // Activer le clic après le délai
    }

    IEnumerator WaitForRightMoment()
    {
                
        if (animatorClick != null)
        {
            animatorClick.enabled = true;
        }


        yield return new WaitForSeconds(3f);
        startTime = Time.time;

        if (!hasClickedAtRightMoment && !hasClickedTooEarlyOrLate && !isGameOver)
        {
            if (animatorClick != null && !hasClickedAtRightMoment)
            {
                animatorClick.SetBool("setClick", true);
                animatorVictory.enabled = false;

            }

            yield return new WaitForSeconds(0.8f);

            if (GameOver != null) //quand il ne clique pas
            {
                Animator animatorGameOver = GameOver.GetComponent<Animator>();
                if ((animatorGameOver && GameOverSound) != null)
                {
                    GameOverSound.Play();
                    animatorGameOver.enabled = true;
                }
            }

            isGameOver = true;
        }
    }

    IEnumerator ActivateVictoryAnimation()
    {
        yield return new WaitForSeconds(0.1f);
        animatorVictory.enabled = true;

    }

    void OnMouseDown()
    {
        if (clickEnabled && !isGameOver)
        {
            float clickTime = Time.time;

            if (clickTime - startTime < 0.2f)
            {
                if (GameOver != null)
                {
                    Animator animatorGameOver = GameOver.GetComponent<Animator>();

                    if (animatorGameOver != null)
                    {
                        animatorGameOver.enabled = true;
                    }
                }

                hasClickedTooEarlyOrLate = true;
                isGameOver = true;

                if (GameOverSound != null)
                {
                    GameOverSound.Play();
                }
            }
            else if (clickTime - startTime >= 1f && clickTime - startTime <= 3f) //victoire
            {
                Animator animatorVictory = Victory.GetComponent<Animator>();

                if(SpraySmoke != null)
                {
                    SpraySmoke.SetActive(true);
                }
                
                if (animatorVictory != null)
                {
                    StartCoroutine(ActivateVictoryAnimation());
                    
                    if(victorySound != null){
                        victorySound.Play();
                    }
                }

                if (SpraySound != null)
                {
                    SpraySound.Play();
                }

               // Debug.Log("Félicitations ! Vous avez gagné !");
                hasClickedAtRightMoment = true;
                isGameOver = true;
            }
            else if (!hasClickedAtRightMoment)
            {

                if (GameOver != null)
                {
                    
                    Animator animatorGameOver = GameOver.GetComponent<Animator>();
                    if (animatorGameOver != null)
                    {
                        animatorGameOver.enabled = true;
                        // SpraySmoke.SetActive(false);
                        // Victory.SetActive(false);

                    }
                }
                hasClickedTooEarlyOrLate = true;
                isGameOver = true;
            }

            clickEnabled = false;
            ccSpray.GetComponent<Collider>().enabled = false;
        }
    }
}
