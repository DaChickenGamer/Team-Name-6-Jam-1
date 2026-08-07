using System;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class LinearShoot : MonoBehaviour
{
    private Rigidbody2D rb;
    private float t;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        t = 0;
    }
    void Update()
    {
        t += Time.deltaTime;
        if(t > 20f)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            // hurt player
            Destroy(gameObject);
        }
        /*if(other.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }*/
    }
    public void Shoot(float x, float y, float spd)
    {
        Vector2 dir = new Vector2(x, y);
        rb.linearVelocity = dir.normalized * spd;
    }

    public void Shoot(Vector2 dir, float spd)
    {
        rb.linearVelocity = dir.normalized * spd;
    }
}
