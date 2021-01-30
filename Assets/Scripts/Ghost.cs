using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    float _lastAttack;

    [SerializeField] float _speed;
    [SerializeField] float _minDamage;
    [SerializeField] float _maxDamage;
    [SerializeField] float _attackSpeed;

    public Player Player;


    void Update()
    {
        if (Player)
        {
            if(Vector3.Distance(transform.position,Player.transform.position) < .5)
            {
                if(_lastAttack+_attackSpeed < Time.time)
                {
                    Player.Damage(Random.Range(_minDamage, _maxDamage));
                    _lastAttack = Time.time;
                }
            }
            else
            {
                Vector3 direction = Player.transform.position - transform.position;
                transform.position += direction.normalized * _speed * Time.deltaTime;
            }
        }
    }
}
