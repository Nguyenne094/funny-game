using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    public GameObject eggPrefab;
    private Bucket bucket;
    private bool isSpawing = true;
    private Vector3 spawnPos;
    public float spawnRate = 1f;

    private void Awake() {
        bucket = FindObjectOfType<Bucket>().GetComponent<Bucket>();
    }

    void Start()
    {
        StartCoroutine(StartSpawing(spawnRate));
    }

    private IEnumerator StartSpawing(float _spawnRate){
        while(isSpawing){
            if(bucket.score >= 50)
                isSpawing = false;
            if(bucket.score < 10)
                _spawnRate = 2f;
            else if(bucket.score <= 10 && bucket.score < 30)
                _spawnRate = 1f;
            else
                _spawnRate = .5f;
            yield return new WaitForSeconds(_spawnRate);
            spawnPos = new Vector3(Random.Range(-2.63f, 2.09f), 6f, 0);
            GameObject newEgg = Instantiate(eggPrefab, spawnPos, Quaternion.identity);
        }
    }
}
