using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JRPG.Dialogue;

namespace JRPG.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] Rigidbody2D playerBody;
        [SerializeField] float speed = 2f;
        [SerializeField] Animator playerAnim;

        public string areaTransitionName;
        public static PlayerController instance;
        public bool canMove ;

        private Vector3 topRightLimit;
        private Vector3 bottomLeftLimit;

         
        private void Awake() {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                if(instance != this)
                {
                    Destroy(gameObject);
                }
                
            }
            DontDestroyOnLoad(gameObject);
        }
       
        void Update()
        {
            if(!DialogueManager.instance.GetMove())
            {
                playerBody.velocity = Vector2.zero;
                playerAnim.SetFloat("moveY", 0);
                playerAnim.SetFloat("moveX", 0);
                return;
            }

            playerBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * speed;

            playerAnim.SetFloat("moveY", playerBody.velocity.y);
            playerAnim.SetFloat("moveX", playerBody.velocity.x);

            if (DirectionPlayer())
            {
                playerAnim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                playerAnim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
        }

        private bool DirectionPlayer()
        {
            return Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1;
        }

        public void SetBounds(Vector3 botLeft, Vector3 topRight)
        {
            bottomLeftLimit = botLeft + new Vector3(0.5f,0.5f,0f);
            topRightLimit = topRight + new Vector3(-0.5f,-0.5f,0f);
        }

        
    }
}
