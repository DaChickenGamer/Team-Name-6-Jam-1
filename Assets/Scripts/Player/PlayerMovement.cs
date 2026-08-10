using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private static readonly int IsWalking = Animator.StringToHash("move");
    [SerializeField] private float speed = 5;

    private Vector2 direction;
    private Rigidbody2D rb;

    public Animator animator;

    public bool isDashing;
    public float stunDuration = 2;
    private float stunTimer = 0;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    public void OnMovement(InputAction.CallbackContext ctxt)
    {
        if(stunTimer <= 0) {
            direction = ctxt.ReadValue<Vector2>();
        
            if (direction.x != 0 || direction.y != 0)
            {
                animator.transform.localScale = direction.x switch
                {
                    > 0 => new Vector3(-1, 1, 1),
                    < 0 => new Vector3(1, 1, 1),
                    _ => animator.transform.localScale
                };

                animator.SetBool(IsWalking, true);
            }
            else
            {
                animator.SetBool(IsWalking, false);
            }
        }
    }
    public void Stun()
    {
        stunTimer = stunDuration;
    }
    public void ScaleSpeed(float s)
    {
        speed *= s;
    }
    void Update()
    {
        if(stunTimer >= 0)
        {
            stunTimer -= Time.deltaTime;
            rb.linearVelocity *= 0;
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        if(stunTimer <= 0) rb.MovePosition(rb.position + direction * (speed * Time.fixedDeltaTime));
    }

}