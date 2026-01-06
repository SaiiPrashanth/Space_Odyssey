using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Manages ship collisions and level reloading
public class ShipCollisionManager : MonoBehaviour
{
    [Header("Crash Settings")]
    [Tooltip("Time in seconds to wait before reloading the level.")]
    [SerializeField] private float levelLoadDelay = 2f;
    [Tooltip("Particle system to play upon collision.")]
    [SerializeField] private ParticleSystem explosionParticles;

    // References
    private MeshRenderer _shipMeshRenderer;
    private SpaceShipController _shipController;
    private BoxCollider _shipCollider;
    private bool _isTransitioning = false;

    private void Start()
    {
        // Cache components
        _shipMeshRenderer = GetComponent<MeshRenderer>();
        _shipController = GetComponent<SpaceShipController>();
        _shipCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Stop if we are already crashing
        if (_isTransitioning) return;

        InitiateCrashSequence();
    }

    // Handles the crash sequence
    private void InitiateCrashSequence()
    {
        _isTransitioning = true;
        
        // Play VFX and disable controls
        if (explosionParticles != null) explosionParticles.Play();
        if (_shipMeshRenderer != null) _shipMeshRenderer.enabled = false;
        if (_shipController != null) _shipController.enabled = false;
        if (_shipCollider != null) _shipCollider.enabled = false;

        // Start reload timer
        StartCoroutine(ReloadLevelRoutine());
    }

    private IEnumerator ReloadLevelRoutine()
    {
        yield return new WaitForSeconds(levelLoadDelay);
        ReloadCurrentLevel();
    }

    private void ReloadCurrentLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
