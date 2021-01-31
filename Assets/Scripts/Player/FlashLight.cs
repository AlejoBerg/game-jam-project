using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _hitDelay;

    private int _i = 0;
    private List<IDamageable> _targets = new List<IDamageable>();

    private void Start()
    {
        StartCoroutine(AttackTargets());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var targetToAdd = other.gameObject.GetComponent<IDamageable>();
        _targets.Add(targetToAdd);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var targetToRemove = other.gameObject.GetComponent<IDamageable>();
        _targets.Remove(targetToRemove);

        if(_i > 0) { _i -= 1; }
    }

    IEnumerator AttackTargets()
    {
        while (true)
        {
            for (_i = 0; _i < _targets.Count; _i++)
            {
                if (_targets[_i] != null)
                {
                    _targets[_i].GetDamage(_damage);
                }
            }

            yield return new WaitForSeconds(_hitDelay);
        }
    }
}
