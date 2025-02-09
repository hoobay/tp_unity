using UnityEngine;

public class BallController : MonoBehaviour
{
    public float pushForce = 10f; // Force de pouss�e sur le player

    private void OnCollisionEnter(Collision collision)
    {
        // V�rifier si on touche le player
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                // Calculer la direction de la pouss�e
                Vector3 pushDirection = collision.transform.position - transform.position;
                pushDirection.y = 0; // On �vite de pousser en hauteur

                // Appliquer la force
                playerRb.AddForce(pushDirection.normalized * pushForce, ForceMode.Impulse);
            }
        }
    }
}
