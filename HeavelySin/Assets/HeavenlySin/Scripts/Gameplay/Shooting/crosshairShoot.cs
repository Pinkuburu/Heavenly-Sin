using System.Collections;
using System.Collections.Generic;
using HeavenlySin.Enemy;
using UnityEngine;

namespace HeavenlySin
{
    public class crosshairShoot : MonoBehaviour
    {
        private Vector3 targetPos;
        /*public float speed = 2.0f;
        public float shootSpeed = 3.0f;
        public Rigidbody Projectile;*/
        public float damage;
        public Camera UIcamera;

        void Start()
        {
            targetPos = transform.position;

        }
        
        void Update()
        {

            float distance = transform.position.z + UIcamera.transform.position.z;
            targetPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            targetPos = UIcamera.ScreenToWorldPoint(targetPos);

            Vector3 followXonly = new Vector3(targetPos.x, targetPos.y, transform.position.z);
            transform.position = followXonly;

            if (Input.GetMouseButtonDown(0))
                PlayerShoot();
        }

        void PlayerShoot()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity)){
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    //Destroy(hit.transform.gameObject);
                    hit.transform.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
                }
            }
        }
    }
}

