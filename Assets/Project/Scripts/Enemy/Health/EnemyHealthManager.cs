using System;
using UnityEngine;

namespace Project.Scripts.Enemy.Health
{
    public class EnemyHealthManager : MonoBehaviour
    {
        private IHealth _health;

        private void Awake()
        {
            _health = GetComponent<IHealth>();
        }

        private void OnCollisionEnter(Collision other)
        {
            var damaging = other.gameObject.GetComponent<IDamaging>();
            if (damaging == null) return;
            _health.TakeDamage(damaging.Damage);
        }

        private void Update()
        {
            if (_health.IsDead())
                _health.ResetHealth();
        }
    }
}