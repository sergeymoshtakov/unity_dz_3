using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize(Vector3 direction)
    {
        if (_rigidbody != null)
        {
            var movementVector = direction * (_speed * Time.deltaTime);

            _rigidbody.AddForce(transform.TransformDirection(movementVector), ForceMode.Acceleration);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Dirt dirt))
        {
            Destroy(dirt.gameObject);
            Destroy(gameObject);
        }
    }
}
