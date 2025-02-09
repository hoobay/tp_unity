using UnityEngine;

public class FallingObject : MonoBehaviour // Implement the IResettable interface
{
    private Rigidbody rb;
    private bool hasFallen = false;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        // Cache the Rigidbody component
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogError("Rigidbody component missing on " + gameObject.name);
        }
        else
        {
            // Ensure the Rigidbody is kinematic at the start
            rb.isKinematic = true;
            rb.useGravity = false; // Disable gravity initially
        }

        // Save the initial position and rotation for resetting
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the plank hasn't fallen and the player stepped on it
        if (!hasFallen && other.CompareTag("Player"))
        {
            Debug.Log("Player stepped on plank: " + gameObject.name);
            MakePlankFall();
        }
    }

    private void MakePlankFall()
    {
        if (rb != null)
        {
            Debug.Log("Making plank fall: " + gameObject.name);
            rb.isKinematic = false; // Enable physics
            rb.useGravity = true; // Enable gravity
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse); // Apply downward force
            hasFallen = true; // Prevent multiple falls
        }
        else
        {
            Debug.LogError("Rigidbody component missing on " + gameObject.name);
        }
    }

    // Implement the IResettable interface
    public void ResetObject()
    {
        if (rb != null)
        {
            hasFallen = false; // Allow it to fall again

            // Temporarily disable kinematic to reset velocity and angular velocity
            rb.isKinematic = false;
            rb.linearVelocity = Vector3.zero; // Reset velocity
            rb.angularVelocity = Vector3.zero; // Reset angular velocity

            // Re-enable kinematic and disable gravity for the reset state
            rb.isKinematic = true;
            rb.useGravity = false;

            // Reset position and rotation
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }
    }
}