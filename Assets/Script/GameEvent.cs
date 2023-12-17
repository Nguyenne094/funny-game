using UnityEngine;
using UnityEngine.Events;

public class GameEvent : MonoBehaviour
{
    public static UnityAction<int> scoreInscrease;
    public static UnityAction<int> scoreDescrease;
}
