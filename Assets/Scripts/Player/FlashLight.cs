using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _hitDelay;
    private List<IDamageable> _targets = new List<IDamageable>();

    private void Update()
    {
        StartCoroutine(DelayToAttack(_hitDelay));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var targetToAdd = collision.gameObject.GetComponent<IDamageable>();
        _targets.Add(targetToAdd);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var targetToRemove = collision.gameObject.GetComponent<IDamageable>();
        _targets.Remove(targetToRemove);
    }

    private void AttackTargets()
    {
        foreach (var target in _targets)
        {
            target.GetDamage(_damage);
        }
    }

    IEnumerator DelayToAttack(float delay)
    {
        yield return new WaitForSeconds(delay);
        AttackTargets();
    }
}
