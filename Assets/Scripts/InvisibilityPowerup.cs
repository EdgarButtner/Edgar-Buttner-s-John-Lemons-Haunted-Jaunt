using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibilityPowerup : MonoBehaviour
{
    public Transform player;

    [Header("Bob Settings")]
    public float bobSpeed = 0.8f;
    public float bobLow = 0.3f;
    public float bobHigh = 0.3f;

    [Header("Spin Settings")]
    public float spinSpeed = 90f;

    [Header("Invisibility Settings")]
    public float invisibilityDuration = 5f;

    float m_StartY;


    void Start()
    {
        if (!player)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
        }

        m_StartY = transform.position.y;
    }

    void Update()
    {
        float t = (Mathf.Sin(Time.time * bobSpeed) + 1f) / 2f;
        float newY = m_StartY + Mathf.Lerp(bobLow, bobHigh, t);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f, Space.World);
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.transform == player)
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController) playerController.SetInvisible(invisibilityDuration);
            Destroy(gameObject);
        }
    }
}