using UnityEngine;
using UnityEngine.UI;

namespace Project.Scripts.Enemy.Health
{
    public class Health : MonoBehaviour, IHealth
    {
        [Range(0, 200)] [SerializeField] private float maxHealth;
        [SerializeField] private Image health;

        public void TakeDamage(float amount)
        {
            var healthToReduce = amount / maxHealth;
            health.fillAmount -= healthToReduce;
            Debug.Log(health.fillAmount);
        }

        public void ResetHealth()
        {
            health.fillAmount = maxHealth;
        }

        public bool IsDead() => health.fillAmount <= 0;
    }
}