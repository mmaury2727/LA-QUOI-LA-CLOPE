using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    // [SerializeField] GameObject titleScreen;
    // [SerializeField] GameObject gameOverScreen;
    [SerializeField] SpawnManager spawnManager;
    [SerializeField] GameObject winAnim;
    [SerializeField] GameObject loseAnim;
    [SerializeField] Camera camera;
    public int score;
    public int scoreToWin = 6;
    private int livesRemaining;
    public bool won;
    public bool lost;
    // Duration of the movement in seconds
    public float duration = 8f;

    // Initial position of the camera
    private Vector3 initialPosition;

    // Time elapsed since the movement started
    private float elapsedTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        won = false;
        lost = false;
        if (camera != null) {
            initialPosition = camera.transform.position;
            Debug.Log(initialPosition);
        }
    }
    
    public void StartGame() 
    {
        score = 0;
        livesRemaining = 3;
        // titleScreen.SetActive(false);
        spawnManager.StartSpawning();
    }

    void Update(){
        if (camera != null && duration > 0f && ( won || lost )){
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the interpolation factor (0 to 1)
            float t = Mathf.Clamp01(elapsedTime / duration);

            // Calculate the new position of the camera along the z-axis
            Vector3 targetPosition = initialPosition - camera.transform.right * -25.5f; // Move 10 units backward

            camera.GetComponent<Follow>().player = GameObject.FindWithTag("WinAnim").gameObject.transform;
            camera.GetComponent<Follow>().xPos = 5f;
            camera.GetComponent<Follow>().zPos = 0f;

            // Interpolate between the initial position and the target position
            camera.transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
        }
    }

    public void UpdateScore(int addToScore)
    {
        AudioManager.Instance.PlayAudio("Clope Corbeille");
        score += addToScore;
        if (score >= scoreToWin) EndGame();
    }

    public void LostLife()
    {
        livesRemaining --;
        if (livesRemaining == 0)
        {
            EndGame();
        }
    }

    public void LoseGame()
    {
        // camera.GetComponent<Follow>().enabled = true;
        AudioManager.Instance.PlayAudio("Herbe Brule");
        camera.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        lost = true;
        Instantiate(loseAnim, loseAnim.transform.position, loseAnim.transform.rotation);
        spawnManager.xSpawnRange = 20.5f;
        spawnManager.startDelay = 0.03f; // Randomize
        spawnManager.clopeSpawnTime = 0.03f; // Randomize
        scoreToWin = 200;
        spawnManager.StopSpawning();
        spawnManager.StartSpawning();
    }

    public void EndGame()
    {
        // camera.GetComponent<Follow>().enabled = true;
        camera.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        AudioManager.Instance.PlayAudio("Victoire Corbeille");
        won = true;
        GameStats.Instance.winned = true;
        Instantiate(winAnim, winAnim.transform.position, winAnim.transform.rotation);
        spawnManager.StopSpawning();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
