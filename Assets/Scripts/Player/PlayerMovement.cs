using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private static readonly int IsWalking = Animator.StringToHash("move");
    [SerializeField] private int speed = 5;

    private Vector2 direction;
    private Rigidbody2D rb;

    public Animator animator;

    public bool isDashing;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    public void OnMovement(InputAction.CallbackContext ctxt)
    {
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
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.MovePosition(rb.position + direction * (speed * Time.fixedDeltaTime));
    }

}