using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour, IDamageable
{
    float _lastAttack;
    Collider2D[] _colliders;

    float _lastSeparation;
    float _separationTime = .1f;
    Vector3 _separationDirection = Vector3.zero;

    [SerializeField] float _minSpeed;
    [SerializeField] float _maxSpeed;
    [SerializeField] float _minDamage;
    [SerializeField] float _maxDamage;
    [SerializeField] float _attackSpeed;
    [SerializeField] float _maxLife;
    private float _currentLife;
    private float _speed;

    [SerializeField] float _personalSpaceRadius;
    [SerializeField] ContactFilter2D _contactFilter;

    public Player Player;

    public delegate void OnDie(Ghost ghost);
    public event OnDie Die;




    private void Start()
    {
        _colliders = new Collider2D[30];
        _speed = Random.Range(_minSpeed, _maxSpeed);
        _currentLife = _maxLife;
    }

    void Update()
    {
        if (Player)
        {
            if (Vector3.Distance(transform.position, Player.transform.position) < 1)
            {
                if (_lastAttack + _attackSpeed < Time.time)
                {
                    Player.GetDamage(Random.Range(_minDamage, _maxDamage));
                    _lastAttack = Time.time;
                }
            }
            else
            {
                Vector3 direction = Player.transform.position - transform.position;

                if (_lastSeparation + _separationTime < Time.time)
                {
                    _separationDirection = GetDirection();
                }

                transform.position += (_separationDirection + direction.normalized) * _speed * Time.deltaTime;
                _separationDirection = Vector3.zero;
            }
        }
    }

    public Vector2 GetDirection()
    {
        Vector3 direction = Vector3.zero;

        Physics2D.OverlapCircle(transform.position, 1.5f, _contactFilter, _colliders);

        foreach (Collider2D item in _colliders)
        {
            if (!item) return Vector2.zero;
            Vector3 offset = this.transform.position - item.transform.position; //opposite direction to avoid collisions

            if (offset.magnitude < _personalSpaceRadius)
            {
                float scale = offset.magnitude / Mathf.Sqrt(_personalSpaceRadius); //force inversely proportional to distance
                Vector3 forceVector = offset.normalized / scale;
                direction += forceVector;
            }
        }
        return direction.normalized;
    }

    public void GetDamage(float damage)
    {
        if (_currentLife <= 0)
        {
            Die(this);
            Destroy(this.gameObject);
        }
        else
        {
            _currentLife -= damage;
            print("el fantasma tiene vida = " + _currentLife);
        }
    }
}
