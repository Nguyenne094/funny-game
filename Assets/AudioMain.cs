using Unity.VisualScripting;
using UnityEngine;

public class AudioMain : MonoBehaviour
{
    private Bucket bucket;
    [SerializeField] private AudioSource audioBackground;

    private void Start() {
        bucket = GameObject.FindWithTag("Bucket").GetComponent<Bucket>();
    }

    private void Update() {
        if(bucket.isWinGame)
            audioBackground?.Stop();
    }
}
