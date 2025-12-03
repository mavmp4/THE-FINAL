using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public GameEnding gameEnding;
    public Transform player;
    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_IsPlayerInRange = true;
		}
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            m_IsPlayerInRange = true;
		
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))        
        {
            m_IsPlayerInRange = false;

        }
    }

    void Update()
    {
        if (!m_IsPlayerInRange)
            return;

        Vector3 direction = player.position - transform.position + Vector3.up;
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if (gameEnding != null)
                    gameEnding.CaughtPlayer();
            }
        }
    }
}