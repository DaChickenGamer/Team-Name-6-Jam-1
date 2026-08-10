using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShell : MonoBehaviour
{
    private static readonly int Throw = Animator.StringToHash("throw");
    public ShellSO startingShell;
    private ShellSO _currentShell;

    private Vector2 throwDir;
    private Rigidbody2D _rb;
    private Coroutine _hideShellRoutine;
    private float _canPickupTime;

    public Animator animator;
    public SpriteRenderer shellSpriteRenderer;
    
    public bool isEquipped = true;
    private bool isThrowing = false;

    public Action<ShellSO> EquipShellEvent;
    public Action UnequipShellEvent;

    [SerializeField] AudioClip equipSoundClip;
    [SerializeField] float pickupDelay = 0.2f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        if (_rb)
            _rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private IEnumerator Start()
    {
        if (!startingShell) yield break;

        _currentShell = startingShell;
        isEquipped = false;
        yield return null;
        EquipShell();
    }

    public void OnAttack(InputAction.CallbackContext ctxt)
    {
        if (ctxt.performed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 throwRot = Vector2.Normalize(new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y));
            
            ThrowShell(throwRot);
        }
    }

    public void EquipShell()
    {
        if (!_currentShell || isEquipped) return;

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.parent = player;
        transform.localPosition = Vector3.zero;

        if (_hideShellRoutine != null)
        {
            StopCoroutine(_hideShellRoutine);
            _hideShellRoutine = null;
        }

        foreach (ShellEffect effect in _currentShell.onEquipEffects)
        {
            if (effect)
                effect.Trigger(player);
        }

        if (SoundFXManager.Instance && equipSoundClip)
            SoundFXManager.Instance.PlaySoundFXClip(equipSoundClip, transform, 1f);

        EquipShellEvent?.Invoke(_currentShell);
        isEquipped = true;
        isThrowing = false;
        shellSpriteRenderer.enabled = false;
    }
    
    public void UnequipShell(Transform playerTransform = null)
    {
        Transform source = playerTransform != null ? playerTransform : transform.parent;
        foreach (ShellEffect effect in _currentShell.onUnequipEffects)
        {
            if (effect)
                effect.Trigger(source);
        }
        
        if (_hideShellRoutine != null)
            StopCoroutine(_hideShellRoutine);
        _hideShellRoutine = StartCoroutine(HideShell());
    }
    
    IEnumerator HideShell()
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Throw"));
        yield return new WaitUntil(() => !animator.GetCurrentAnimatorStateInfo(0).IsName("Throw"));

        if (isEquipped)
        {
            _hideShellRoutine = null;
            yield break;
        }

        UnequipShellEvent?.Invoke();
        shellSpriteRenderer.sprite = _currentShell.shellSprite;
        shellSpriteRenderer.enabled = true;
        _hideShellRoutine = null;
    }
    
    public void ThrowShell(Vector2 dir)
    {
        if (!isEquipped) return;

        Transform playerTransform = transform.parent;
        transform.parent = null;
        throwDir = dir;
        isThrowing = true;
        isEquipped = false;
        _canPickupTime = Time.time + pickupDelay;
        
        animator.SetTrigger(Throw);
        UnequipShell(playerTransform);
    }

    public void BreakShell()
    {
       _currentShell = null; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandleShellCollision(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        TryPickup(other);
    }

    private void HandleShellCollision(Collider2D other)
    {
        if (isEquipped) return;

        foreach (ShellEffect effect in _currentShell.onHitEffects)
        {
            if (effect)
                effect.Trigger(transform);
        }

        // TODO: Make a more well defined way of stopping a throw later
        if (isThrowing && other.CompareTag("Enemy"))
        {
            isThrowing = false;
            EnemyHealth enemyHealth = other.GetComponentInParent<EnemyHealth>();
            enemyHealth.RemoveHealth(1); // needs to account for glass shell
        }
        else if (isThrowing && !other.CompareTag("Player") && !other.CompareTag("Projectile"))
        {
            isThrowing = false;
        }

        TryPickup(other);
    }

    private void TryPickup(Collider2D other)
    {
        if (isEquipped || Time.time < _canPickupTime || isThrowing) return;
        if (!other.CompareTag("Player")) return;

        EquipShell();
    }

    private void FixedUpdate()
    {
        if (!isThrowing || !_currentShell) return;

        Vector3 nextPos = !_currentShell.moveEffect
            ? Vector2.MoveTowards(transform.position, transform.position + new Vector3(throwDir.x, throwDir.y, 0), 10 * Time.fixedDeltaTime)
            : _currentShell.moveEffect.TriggerMove(transform);

        if (_rb)
            _rb.MovePosition(nextPos);
        else
            transform.position = nextPos;
    }

    public Vector2 GetThrowDir()
    {
        return throwDir;
    }
}
