using UnityEngine;

public class PooledObject : MonoBehaviour
{
    private Pool pool;
    public Pool Pool { get => pool; set => pool = value; }
}
