using UnityEngine;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float yVel = 15f;
    [SerializeField] AudioClip[] audioClips;
    [Range(0, 2)] [SerializeField] float randomFactor = 0.2f;
    Vector2 paddleToBallVector;

    //ref
    AudioSource myAudioSource;
    Rigidbody2D rb;

    //stats
    bool hasLaunch = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
        paddleToBallVector = transform.position - paddle1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLaunch)
        {
            LockBall();
            LaunchBall();
        }
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasLaunch = true;
            rb.velocity = new Vector2(UnityEngine.Random.Range(-2f, 2f), yVel);
        }
    }

    private void LockBall()
    {
        Vector2 paddle1Pos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddle1Pos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2
        (Random.Range(0, randomFactor), 
         Random.Range(0, randomFactor));
        if (hasLaunch)
        {  
           AudioClip audioClip = audioClips[Random.Range(0, audioClips.Length)];
           myAudioSource.PlayOneShot(audioClip);
            rb.velocity += velocityTweak;
        }
    }
}
