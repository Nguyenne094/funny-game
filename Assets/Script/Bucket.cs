using System;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    public float speed = 5f;
    public int score;
    [SerializeField] internal bool isGamerOver = false;
    [SerializeField] internal bool isWinGame = false;

    private void Start() {
        score = 0;
        transform.position = new Vector3(0f, -3f, 0f);
    }

    private void Update(){
        Movement();
        if(score < 0)
            isGamerOver = true;
        if(score >= 30)
            isWinGame = true;
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);

        if(score < 10)
            transform.Translate(movement * speed * Time.deltaTime);
        else if(10 <= score && score < 20)
            transform.Translate(movement * speed * 1.5f * Time.deltaTime);
        else
            transform.Translate(movement * speed * 2f * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x,-2.339f, 2.339f), transform.position.y, 0);
    }
}