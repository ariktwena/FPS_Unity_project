using UnityEngine;

namespace Project.Scripts.Enemy
{
    public class Enemy : MonoBehaviour, IKillable
    {
        [SerializeField] private Transform player;
        [SerializeField] private float attackDistance = 30f;
        public Transform Player => player;
        public float AttackDistance => attackDistance;

        public float GetPlayerDistance() => Vector3.Distance(player.position, transform.position);

        public void Kill()
        {
            gameObject.SetActive(false);
        }
    }
}