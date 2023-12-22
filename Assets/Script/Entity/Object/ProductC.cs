using UnityEngine;

public class ProductC : MonoBehaviour, IProduct
{
    private Bucket bucket;
    private AudioSource audioSource;
    public float speedWave1 = 3f;
    public float speedWave2 = 4f;
    public float speedWave3 = 5f;

    private void Awake()
    {
        bucket = FindObjectOfType<Bucket>().GetComponent<Bucket>();
        audioSource = GameObject.Find("DestroyProductC").GetComponentInChildren<AudioSource>();
    }

    private void Update()
    {
        Movement();
        if (bucket.isGamerOver || bucket.isWinGame)
            Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bucket"))
        {
            if (bucket == null)
            {
                Debug.Log("Can't not find Bucket Scipt");
            }
            else
            {
                GameEvent.scoreInscrease.Invoke(2);
                audioSource?.Stop();
                audioSource?.Play();
                Destroy(gameObject);
            }
        }
    }

    public void Movement()
    {
        if (bucket.score < 10)
            transform.Translate(Vector3.down * speedWave1 * Time.deltaTime);
        else if (10 <= bucket.score && bucket.score < 30)
            transform.Translate(Vector3.down * speedWave2 * Time.deltaTime);
        else
            transform.Translate(Vector3.down * speedWave3 * Time.deltaTime);
        if (transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }
}
