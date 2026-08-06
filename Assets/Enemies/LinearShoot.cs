using Unity.VisualScripting;
using UnityEngine;

public class LinearShoot : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // need to add collision destruction
    public void Shoot(float x, float y, float spd)
    {
        Vector2 dir = new Vector2(x, y).normalized;
        rb.linearVelocity = dir * spd;
    }

    public void Shoot(Vector2 dir, float spd)
    {
        rb.linearVelocity = dir.normalized * spd;
    }
}
