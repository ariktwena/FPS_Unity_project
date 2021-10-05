using UnityEngine;

namespace Project.Scripts
{
    public class MineScript : MonoBehaviour
    {
        
        public GameObject explosionPrefab;
        
        private BoxCollider _mineCollider;
        
        // Start is called before the first frame update
        void Start()
        {
            _mineCollider = GetComponentInChildren<BoxCollider>();

        }

        void Explode()
        {
            var _radius = 5.0F;
            var _power = 10.0F;
            
            var explosionPos = transform.position;
            var colliders = Physics.OverlapSphere(explosionPos, _radius);
            foreach (var hit in colliders)
            {
                var rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(_power, explosionPos, _radius, 3.0F);
            }

            foreach (var ps in explosionPrefab.GetComponentsInChildren<ParticleSystem>())
            {
                ps.Play();
                Destroy(gameObject, ps.main.duration);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Floor")) return;
            Explode();
            var killable = other.GetComponent<IKillable>();
            killable?.Kill();
        }
    }
}
