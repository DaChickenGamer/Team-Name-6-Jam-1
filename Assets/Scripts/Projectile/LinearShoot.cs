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
        if(t > 10f)
        {
            Destroy(gameObject);
        }
    }
    public void Shoot(float x, float y, float spd)
    {
        Vector2 dir = new Vector2(x, y).normalized;
        double angle = Math.Atan2((double)dir.y, (double)dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, (float)angle);
        rb.linearVelocity = dir * spd;
    }

    public void Shoot(Vector2 dir, float spd)
    {
        rb.linearVelocity = dir.normalized * spd;
    }
}
