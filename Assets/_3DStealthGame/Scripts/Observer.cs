using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public GameEnding gameEnding;
    public Transform player;
    bool m_IsPlayerInRange;

    void Start()
    {
        Debug.Log("Observer.Start() on " + gameObject.name);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter with " + other.name + " (tag: " + other.tag + ")");

        if (other.CompareTag("Player"))
        {
            m_IsPlayerInRange = true;
            Debug.Log("Player entered trigger");
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit with " + other.name + " (tag: " + other.tag + ")");

        if (other.CompareTag("Player"))        
        {
            m_IsPlayerInRange = false;
            Debug.Log("Player left trigger");
        }
    }

    void Update()
    {
        if (!m_IsPlayerInRange)
            return;

        Debug.Log("Update: Player is in range, casting ray...");

        Vector3 direction = player.position - transform.position + Vector3.up;
        Ray ray = new Ray(transform.position, direction);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(">>> Player was caught!  (from " + gameObject.name + ")");

            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log(">>> Player was caught!");
                if (gameEnding != null)
                    gameEnding.CaughtPlayer();
            }
        }
        else
        {
            Debug.Log("Raycast hit NOTHING");
        }
    }
}