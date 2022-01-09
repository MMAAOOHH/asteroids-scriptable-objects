using DefaultNamespace.GameEvents;
using UnityEngine;

public class OnBecameInvisble : MonoBehaviour
{
    [SerializeField] private GameEvent _event;

    private void OnBecameInvisible()
    {
        _event.Raise();
    }
}
