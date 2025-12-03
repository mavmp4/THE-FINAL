using UnityEngine;

public class ShieldPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerShield shield = other.GetComponentInParent<PlayerShield>();
            if (shield != null)
            {
                shield.ActivateShield();
            }

            Destroy(gameObject);  // remove the pickup once collected
        }
    }
}