using UnityEngine;

namespace Assignment
{
    [CreateAssetMenu]
    class SpeedIncreaseInvulnerable : Ability
    {
        [SerializeField] private float _speedMultiplier = 2f;

        private Collider2D _shipCollider;
        
        public override void Activate(GameObject parent)
        {
            Rigidbody2D shipEngine = parent.GetComponent<Rigidbody2D>();
            _shipCollider = parent.GetComponentInChildren<Collider2D>();
            
            shipEngine.velocity *= _speedMultiplier;
            _shipCollider.enabled = false;
        }

        public override void Reset()
        {
            _shipCollider.enabled = true;
        }
    }
}