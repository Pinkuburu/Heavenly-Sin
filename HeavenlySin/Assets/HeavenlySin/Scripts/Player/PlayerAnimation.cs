using UnityEngine;

namespace HeavenlySin.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        /// <summary>
        /// This class updates the player's animations
        /// </summary>

        #region Fields
        public PlayerScript playerScript;
        private Animator anim;
        private int _horizontal, _vertical;
        public float horizontal, vertical;
        private int _isMoving;
        public bool isMoving;
        private SpriteRenderer _renderer;
        #endregion

        #region LifeCycle
        private void Start()
        {
            anim = GetComponent<Animator>();
            _horizontal = Animator.StringToHash("horizontal");
            _vertical = Animator.StringToHash("vertical");
            _isMoving = Animator.StringToHash("isMoving");
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            Vector3 direction = playerScript.playerMovement.direction;
            horizontal = direction.x;
            vertical = direction.z;
            isMoving = direction.magnitude > 0.1f;
            Animate();
        }

        public void Animate()
        {
            anim.SetFloat(_horizontal, horizontal);
            anim.SetFloat(_vertical, vertical);
            anim.SetBool(_isMoving, isMoving);

            if(horizontal > 0)
            {
                _renderer.flipX = false;
            }
            else if(horizontal < 0)
            {
                _renderer.flipX = true;
            }

        }

        //flip the sprite with direction
        /*if(_playerBody.transform.position.x > transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if(_playerBody.transform.position.x<transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }*/
        #endregion
    }
}
