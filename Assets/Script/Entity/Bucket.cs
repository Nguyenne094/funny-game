using UnityEngine;

public class Bucket : MonoBehaviour
{
    public float speed = 5f;
    public int score;
    [SerializeField] internal bool isGamerOver = false;
    [SerializeField] internal bool isWinGame = false;
    [SerializeField] private Sprite bucket;
    [SerializeField] private Sprite bucket1;
    [SerializeField] private Sprite bucket2;
    [SerializeField] private Sprite bucket3;
    SpriteRenderer spriteRenderer;
    ParticleSystem winGameParticle;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        winGameParticle = GetComponentInChildren<ParticleSystem>();
    }

    private void Start() {
        score = 0;
        transform.position = new Vector3(0f, -3f, 0f);
    }

    private void Update(){
        BucketUpdate();
        if(score < 0)
            isGamerOver = true;
        if(score >= 50){
            isWinGame = true;
            winGameParticle?.Stop();
            winGameParticle?.Play();
        }
    }

    private void BucketUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        if(score < 10){
            spriteRenderer.sprite = bucket;
            transform.Translate(movement * speed * Time.deltaTime);
        }

        else if(10 <= score && score < 20){
            spriteRenderer.sprite = bucket1;
            transform.Translate(movement * speed * 1.5f * Time.deltaTime);
        }
        else if(20 <= score && score < 30){
            spriteRenderer.sprite = bucket2;
            transform.Translate(movement * speed * 1.75f * Time.deltaTime);
        }
        else if(30 <= score && score < 50){
            spriteRenderer.sprite = bucket3;
            transform.Translate(movement * speed * 2f * Time.deltaTime);
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-2.3f, 1.79f), transform.position.y, 0);
    }
}