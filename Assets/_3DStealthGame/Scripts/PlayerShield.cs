using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [Header("Shield settings")]
    public GameObject shieldVisual;
    public bool shieldActive = false;

    public void ActivateShield()
    {
        shieldActive = true;
        if (shieldVisual != null)
            shieldVisual.SetActive(true);
    }

    public void DeactivateShield()
    {
        shieldActive = false;
        if (shieldVisual != null)
            shieldVisual.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleGhostHit(other.gameObject);
    }

    private void HandleGhostHit(GameObject other)
    {
        if (!shieldActive)
            return;

        if (other.CompareTag("Ghost"))
        {
            Destroy(other);
            DeactivateShield();
        }
    }
}