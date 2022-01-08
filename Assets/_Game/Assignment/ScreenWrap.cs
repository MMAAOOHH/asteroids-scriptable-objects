using DefaultNamespace.GameEvents;
using UnityEngine;

namespace Assignment
{
    public class ScreenWrap : MonoBehaviour
    {
        [SerializeField] private GameEvent _shipInvisibleEvent;
        
        private void Awake()
        {
            _shipInvisibleEvent.Register(WrapPosition);
        }
        
        private void OnDisable()
        {
            _shipInvisibleEvent.Unregister(WrapPosition);
        }

        private void WrapPosition()
        {
            var viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
            var wrapPosition = transform.position;

            if (viewportPosition.x > 1 || viewportPosition.x < 0)
                wrapPosition.x = -wrapPosition.x;
            
            if (viewportPosition.y > 1 || viewportPosition.y < 0)
                wrapPosition.y = -wrapPosition.y;
            
            transform.position = wrapPosition;
        }
    }
}
