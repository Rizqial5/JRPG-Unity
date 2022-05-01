using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace JRPG.Dialogue
{
    public class DialogueManager : MonoBehaviour
    {

        [SerializeField] GameObject dialogueBox;
        [SerializeField] GameObject nameBox;
        [SerializeField] Text dialogueText;
        [SerializeField] Text nameText;

        private bool justStarted;

        private bool isMove = true;

        public int currentLine;
        public string[] dialogLines;
        public static DialogueManager instance;
        // Start is called before the first frame update
        void Awake()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {
            if (!GetActiveInHierarchy())
            {
                isMove = true;
                return;
            } 
            if (Input.GetButtonUp("Fire1"))
            {
                if(!justStarted)
                {
                    DialogueController();
                }
                else
                {
                    justStarted = false;
                }
            }
            
        }

        private void DialogueController()
        {
            currentLine++;
            if (currentLine >= dialogLines.Length)
            {
                dialogueBox.SetActive(false);
                currentLine = 0;
            }
            else
            {
                CheckName();
                dialogueText.text = dialogLines[currentLine];
            }
        }

        public bool GetActiveInHierarchy()
        {
            return dialogueBox.activeInHierarchy;
        }

        

        public void ShowDialogue(string[] newLines, bool isPerson)
        {
            dialogLines = newLines;
            currentLine = 0;

            CheckName();

            dialogueText.text = dialogLines[currentLine];
            dialogueBox.SetActive(true);

            nameBox.SetActive(isPerson);
            justStarted = true;

            isMove = false;

        }

        public void CheckName()
        {
            if(dialogLines[currentLine].StartsWith("n-"))
            {
                nameText.text = dialogLines[currentLine].Replace("n-","");
                currentLine++;
            }
        }

        public bool GetMove()
        {
            return isMove;
        }
    }
}
