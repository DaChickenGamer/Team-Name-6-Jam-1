using System;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerShell : MonoBehaviour
{
    public ShellSO startingShell;
    
    private ShellSO _currentShell;

    private Vector2 throwDir;

    private bool isEquipped = true;
    private bool isThrowing = false;

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
                effect.Trigger();
        }
        
        transform.parent = GameObject.FindGameObjectWithTag("Player").transform;

        isEquipped = true;
    }
    
    public void UnequipShell()
    {
        if (_currentShell.onUnequipEffects.Count <= 0) return;
        
        foreach(ShellEffect effect in _currentShell.onUnequipEffects)
            effect.Trigger();
        
        // Put it on floor here
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
                    effect.Trigger();
            }
        }

        // TODO: Make a more well defined way of stopping a throw later
        if (isThrowing && !other.CompareTag("Player"))
        {
            isThrowing = false;
        }

        if(!isThrowing && other.CompareTag("Player"))
            EquipShell();
    }

    private void FixedUpdate()
    {
        if(isThrowing)
            transform.position = Vector2.MoveTowards(transform.position, transform.position + new Vector3(throwDir.x, throwDir.y, 0), 10 * Time.deltaTime);
    }
}
