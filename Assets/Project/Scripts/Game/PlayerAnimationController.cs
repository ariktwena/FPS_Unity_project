using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Project.Scripts.Game
{
    public class PlayerAnimationController : MonoBehaviour
    {

        [SerializeField] private Animator _animator;
    
        private FirstPersonController _firstPersonController;
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Shoot = Animator.StringToHash("Shoot");


        // Start is called before the first frame update
        void Start()
        {
            _firstPersonController = GetComponent<FirstPersonController>();
        
        }

        // Update is called once per frame
        void Update()
        {
            if (_firstPersonController.MCharacterController.velocity == Vector3.zero)
            {
                _animator.SetFloat(Speed, 0); 
            }
            else if (!_firstPersonController.MIsWalking && Input.GetKey(KeyCode.LeftShift))
            {
                _animator.SetFloat(Speed, 2);
            }   
            else if (_firstPersonController.MIsWalking)
            {
                _animator.SetFloat(Speed, 1);
            }
        
            //Debug.Log(_animator.GetFloat("Speed"));
            //Debug.Log(_firstPersonController.MCharacterController.velocity);  

            if (Input.GetMouseButtonDown(0)) _animator.SetTrigger(Shoot);

            StartCoroutine(ResetTrigger());
            // _animator.ResetTrigger("Shoot");



        }

        private IEnumerator ResetTrigger()
        {
            yield return new WaitForSeconds(1);
            if (Input.GetMouseButtonUp(0)) _animator.ResetTrigger(Shoot);
        }
    }
}