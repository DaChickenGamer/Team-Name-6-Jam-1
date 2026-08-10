using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDash : MonoBehaviour
{
    private static readonly int Spin = Animator.StringToHash("spin");
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [Header("Dash")]
    [SerializeField] float dashSpeed = 25f;
    [SerializeField] float dashDuration = 0.5f;
    [SerializeField] float dashCooldown = 1f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] private AudioClip dashSoundClip;
    [SerializeField] private PlayerShell shell;

    Vector2 moveDirection;

    private PlayerMovement movement;
    private Animator _animator;

    public InputActionAsset inputActions;
    private InputAction moveAction;
    private InputAction dashAction;
    public bool canDash = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
        _animator = GetComponentInChildren<Animator>();
        var playerMap = inputActions.FindActionMap("Player");
        if (inputActions != null)
        {
            moveAction = playerMap.FindAction("Move");
            moveAction.Enable();

            dashAction = playerMap.FindAction("Ability");
            dashAction.Enable();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.isDashing || !canDash)
        {
            return;
        }

        Vector2 inputVector = moveAction.ReadValue<Vector2>();
        float moveX = inputVector.x;
        float moveY = inputVector.y;

        moveDirection = new Vector2(moveX, moveY).normalized;

        //On Keypress dash
        if (dashAction.WasPressedThisFrame())
        {
            StartCoroutine(Dash());
        }
    }

    private IEnumerator Dash()
    {
        if (shell.isEquipped)
        {
            //Debug.Log("Got Here");
            //Debug.Log(moveDirection);
            SoundFXManager.Instance.PlaySoundFXClip(dashSoundClip, transform, 1f);
            movement.isDashing = true;
            _animator.SetTrigger(Spin);
            rb.linearVelocity = new Vector2(moveDirection.x * dashSpeed, moveDirection.y * dashSpeed);
            yield return new WaitForSeconds(dashDuration);
            movement.isDashing = false;
        }
    }
}