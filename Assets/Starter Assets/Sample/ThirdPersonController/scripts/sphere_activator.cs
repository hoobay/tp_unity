using UnityEngine;

public class TriggerAction : MonoBehaviour
{
    public Rigidbody targetObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetObject != null)
            {
                targetObject.isKinematic = false;
                Debug.Log("L'objet n'est plus kinematic !");
            }
            else
            {
                Debug.LogWarning("Aucun objet assigné dans le script !");
            }
        }
    }
}