using System;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private Bucket bucket;
    public float speedWave1 = 2f;
    public float speedUpWave2 = 4f;
    public float speedUpWave3 = 8f;

    private void Awake() {
        bucket = FindObjectOfType<Bucket>().GetComponent<Bucket>();
    }

    private void Update() {
        Movement();
        if(bucket.isGamerOver || bucket.isWinGame)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bucket")){
            if(bucket == null){
                Debug.Log("Can't not find Bucket Scipt");
            }
            else{
                GameEvent.scoreInscrease.Invoke(1);
                Destroy(gameObject);
            }
        }
    }

    private void Movement()
    {
        if(bucket.score < 10)
            transform.Translate(Vector3.down * speedWave1 * Time.deltaTime);
        else if(10 <= bucket.score && bucket.score < 30)
            transform.Translate(Vector3.down * speedUpWave2 * Time.deltaTime);
        else
            transform.Translate(Vector3.down * speedUpWave3 * Time.deltaTime);
        if(transform.position.y < -6){
            GameEvent.scoreDescrease.Invoke(1);
            Destroy(gameObject);
        }
    }
}
