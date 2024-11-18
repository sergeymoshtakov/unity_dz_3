using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction OnDirtPickUp;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Dirt dirt))
        {
            dirt.gameObject.SetActive(false);
            OnDirtPickUp?.Invoke();
        }
    }
}
