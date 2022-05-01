using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JRPG.Portal
{
    public class FadeScript : MonoBehaviour
    {

        public static FadeScript instance;
        [SerializeField] Image fadeScreen;

        public float fadeSpeed = 0.1f;

        public bool shouldFadeIn;
        public bool shouldFadeOut;


        private void Start() 
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        private void Update() {
            
            if(shouldFadeIn)
            {
                Fade(1f);

                if(fadeScreen.color.a == 1f)
                {
                    shouldFadeIn = false;
                }
            }

            if (shouldFadeOut)
            {
                Fade(0f);

                if(fadeScreen.color.a == 0f)
                {
                    shouldFadeOut = false;
                }
            }
        }

        private void Fade(float alphaTarget)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, alphaTarget, fadeSpeed * Time.deltaTime));
        }

        public void FadeIn()
        {
            shouldFadeIn = true;
            shouldFadeOut = false;
        }

        public void FadeOut()
        {
            shouldFadeIn = false;
            shouldFadeOut = true;
        }
    }

}