using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JRPG.Dialogue
{
    public class DialogueActivator : MonoBehaviour
    {

        public string[] lines;
        private bool canActive = false;
        public bool isPerson = true;
        
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if(canActive && Input.GetButtonDown("Fire1") && !DialogueManager.instance.GetActiveInHierarchy())
            {
                DialogueManager.instance.ShowDialogue(lines, isPerson);
            }
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.tag == "Player")
            {
                canActive = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            if(other.tag == "Player")
            {
                canActive = false;
            }
        }
    }

}