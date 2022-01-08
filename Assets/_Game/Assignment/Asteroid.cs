using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private TrackableInt _asteroidDestroyedTrackableInt;
        
        [Header("Config:")]
        [SerializeField] private float _minForce;
        [SerializeField] private float _maxForce;
        [SerializeField] private float _minSize;
        [SerializeField] private float _maxSize;
        [SerializeField] private float _minTorque;
        [SerializeField] private float _maxTorque;

        [Header("References:")]
        [SerializeField] private Transform _shape;

        private AsteroidPool _pool;
        private Rigidbody2D _rigidbody;
        private Vector3 _direction;
        private float _size;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _pool = AsteroidPool.Instance;
            
            SetSize();
            _rigidbody.mass = _size;
            
            SetDirection();
            AddForce();
            AddTorque();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!string.Equals(other.tag, "Laser")) return;

            if (_size > _maxSize * 0.5)
            {
                Split(2);
            }
            
            _pool.Return(gameObject);
            _asteroidDestroyedTrackableInt.Value += 1;
        }
        
        private void SetDirection()
        {
            var size = new Vector2(3f, 3f);
            var target = new Vector3
            (
                Random.Range(-size.x, size.x),
                Random.Range(-size.y, size.y)
            );

            _direction = (target - transform.position).normalized;
        }

        private void AddForce()
        {
            var force = Random.Range(_minForce, _maxForce);
            _rigidbody.AddForce( _direction * force, ForceMode2D.Impulse);
        }

        private void AddTorque()
        {
            var torque = Random.Range(_minTorque, _maxTorque);
            var roll = Random.Range(0, 2);

            if (roll == 0)
                torque = -torque;
            
            _rigidbody.AddTorque(torque, ForceMode2D.Impulse);
        }

        private void SetSize()
        {
            _size = Random.Range(_minSize, _maxSize);
            _shape.localScale = new Vector3(_size, _size, 0f);
        }

        private void Split(int numberOfChildren)
        {
            for (int i = 0; i < numberOfChildren; i++)
            {
                var go = _pool.Get();
                var newAsteroid = go.GetComponent<Asteroid>();
                newAsteroid._size = _size * 0.5f;

                go.transform.position = transform.position;
            }
        }
    }
}
