using System;
using System.Collections;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerShell : MonoBehaviour
{
    private static readonly int Costume = Animator.StringToHash("costume");
    private static readonly int Throw = Animator.StringToHash("throw");
    public ShellSO startingShell;
    private ShellSO _currentShell;

    private Vector2 throwDir;

    public Animator animator;
    public SpriteRenderer shellSpriteRenderer;
    
    public bool isEquipped = true;
    private bool isThrowing = false;

    public Action<ShellSO> EquipShellEvent;
    public Action UnequipShellEvent;

    [SerializeField] AudioClip equipSoundClip;

    private void Start()
    {
        if (startingShell)
        {
            _currentShell = startingShell;
            EquipShell();
        }
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
        if (!_currentShell) return;

        if (_currentShell.onEquipEffects.Count > 0){
            foreach (ShellEffect effect in _currentShell.onEquipEffects)
                effect.Trigger(transform.parent.transform);
        }
        SoundFXManager.Instance.PlaySoundFXClip(equipSoundClip, transform, 1f);
        transform.parent = GameObject.FindGameObjectWithTag("Player").transform;

        EquipShellEvent?.Invoke(_currentShell);
        isEquipped = true;
        shellSpriteRenderer.enabled = false;
    }
    
    public void UnequipShell()
    {
        if (_currentShell.onUnequipEffects.Count > 0)
        {
            foreach (ShellEffect effect in _currentShell.onUnequipEffects)
                if (effect)
                    effect.Trigger(transform.parent.transform);
        }
        StartCoroutine(HideShell());
    }
    
    IEnumerator HideShell()
    {
        yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).IsName("Throw"));
        yield return new WaitUntil(() => !animator.GetCurrentAnimatorStateInfo(0).IsName("Throw"));

        UnequipShellEvent?.Invoke();
        shellSpriteRenderer.sprite = _currentShell.shellSprite;
        shellSpriteRenderer.enabled = true;
        isEquipped = false;
    }

    public void PickupShell()
    {
        
    }
    
    public void ThrowShell(Vector2 dir)
    {
        if (!isEquipped) return;

        transform.parent = null;
        throwDir = dir;
        isThrowing = true;
        
        animator.SetTrigger(Throw);
        UnequipShell();
    }

    public void BreakShell()
    {
       _currentShell = null; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isEquipped) return;

        if (_currentShell.onHitEffects.Count > 0)
        {
            foreach (ShellEffect effect in _currentShell.onHitEffects)
            {
                if(effect)
                    effect.Trigger(transform.parent.transform);
            }
        }

        // TODO: Make a more well defined way of stopping a throw later
        if(isThrowing && other.CompareTag("Enemy"))
        {
            isThrowing = false;
            EnemyHealth enemyHealth = other.GetComponentInParent<EnemyHealth>();
            enemyHealth.RemoveHealth(1); // needs to account for glass shell
        }
        else if (isThrowing && !other.CompareTag("Player") && !other.CompareTag("Projectile"))
        {
            isThrowing = false;
        }

        if(!isThrowing && other.CompareTag("Player"))
            EquipShell();
    }

    private void FixedUpdate()
    {
        // Move Effects should probably be a subset that also gets the shell movement info given to it and than returns a position rather than it setting the position in the script

        if (!isThrowing) return;
        
        if(!_currentShell.moveEffect)
            transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(throwDir.x, throwDir.y, 0), 10 * Time.deltaTime);
        else
            transform.position = _currentShell.moveEffect.TriggerMove(transform);
        
    }

    public Vector2 GetThrowDir()
    {
        return throwDir;
    }
}
