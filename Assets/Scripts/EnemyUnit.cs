using UnityEngine;

// Controls enemy behavior, damage, and scoring
[RequireComponent(typeof(Rigidbody))]
public class EnemyUnit : MonoBehaviour
{
    [Header("Enemy Stats")]
    [SerializeField] private int scoreValue = 15;
    [SerializeField] private int healthPoints = 3;

    [Header("Effects")]
    [SerializeField] private GameObject destructionVFX;
    [SerializeField] private GameObject impactVFX;

    private GameScoreManager _gameScoreManager;
    private GameObject _runtimeSpawnParent;

    private void Start()
    {
        InitializeEnemy();
    }

    private void InitializeEnemy()
    {
        // Find dependencies
        _gameScoreManager = FindObjectOfType<GameScoreManager>();
        _runtimeSpawnParent = GameObject.FindWithTag("SpawnAtRuntime");

        SetupRigidbody();
    }

    private void SetupRigidbody()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.isKinematic = true;
    }

    private void OnParticleCollision(GameObject other)
    {
        RegisterHit();
        
        if (healthPoints <= 0)
        {
            DefeatEnemy();
        }
    }

    private void RegisterHit()
    {
        healthPoints--;
        
        // Spawn hit effect
        if (impactVFX != null)
        {
            GameObject vfx = Instantiate(impactVFX, transform.position, Quaternion.identity);
            if (_runtimeSpawnParent != null) vfx.transform.parent = _runtimeSpawnParent.transform;
        }
    }

    private void DefeatEnemy()
    {
        // Update score
        if (_gameScoreManager != null)
        {
            _gameScoreManager.AddScore(scoreValue);
        }

        // Spawn explosion
        if (destructionVFX != null)
        {
            GameObject vfx = Instantiate(destructionVFX, transform.position, Quaternion.identity);
            if (_runtimeSpawnParent != null) vfx.transform.parent = _runtimeSpawnParent.transform;
        }

        Destroy(gameObject);
    }
}
