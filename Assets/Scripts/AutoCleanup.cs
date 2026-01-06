using UnityEngine;

// Destroys object after a delay
public class AutoCleanup : MonoBehaviour
{
    [Tooltip("Time in seconds before the object is destroyed.")]
    [SerializeField] private float lifetime = 3f;

    private void Start()
    {
        Destroy(gameObject, lifetime); 
    }
}
