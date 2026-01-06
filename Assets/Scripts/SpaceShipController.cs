using UnityEngine;

// Handles player input and movement
public class SpaceShipController : MonoBehaviour
{
    [Header("Movement Settings")]
    [Tooltip("General movement speed.")]
    [SerializeField] private float movementSpeed = 25f;
    [Tooltip("Horizontal limit.")]
    [SerializeField] private float xLimit = 12f;
    [Tooltip("Vertical limit.")]
    [SerializeField] private float yLimit = 8f;
    
    [Header("Weapon System")]
    [SerializeField] private GameObject[] laserCannons;

    [Header("Rotation Tuning")]
    [SerializeField] private float positionPitchFactor = -2f;
    [SerializeField] private float controlPitchFactor = -15f;
    [SerializeField] private float positionYawFactor = 2f;
    [SerializeField] private float controlRollFactor = -20f;

    private float _horizontalInput;
    private float _verticalInput;

    private void Update()
    {
        HandleMovementInput();
        ApplyMovement();
        ApplyRotation();
        HandleFiring();
    }

    private void HandleMovementInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
    }

    private void ApplyMovement()
    {
        // Calculate new positions
        float xOffset = _horizontalInput * Time.deltaTime * movementSpeed;
        float newXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXPos, -xLimit, xLimit);

        float yOffset = _verticalInput * Time.deltaTime * movementSpeed;
        float newYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYPos, -yLimit, yLimit);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void ApplyRotation()
    {
        // Calculate rotation based on position and input
        float pitch = (transform.localPosition.y * positionPitchFactor) + (_verticalInput * controlPitchFactor);
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = _horizontalInput * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void HandleFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            ToggleLasers(true);
        }
        else
        {
            ToggleLasers(false);
        }
    }

    private void ToggleLasers(bool isActive)
    {
        foreach (GameObject laser in laserCannons)
        {
            if (laser == null) continue;
            
            var emission = laser.GetComponent<ParticleSystem>().emission;
            emission.enabled = isActive;
        }
    }
}
