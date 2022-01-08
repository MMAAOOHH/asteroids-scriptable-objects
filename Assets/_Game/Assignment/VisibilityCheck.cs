using DefaultNamespace.GameEvents;
using UnityEngine;

namespace Assignment
{
    public class VisibilityCheck : MonoBehaviour
    {
        [SerializeField] private GameEvent _OnShipInvisible;
    
        private void OnBecameInvisible()
        {
            _OnShipInvisible.Raise();
        }
    }
}
