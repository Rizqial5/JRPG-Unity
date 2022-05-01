using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using JRPG.Controller;

namespace JRPG.Portal
{
       public class AreaExit : MonoBehaviour
    { 
        public string areaTransitionName;
        public string areaToLoad;
        public float waitToLoad = 1f;
        private bool shouldLoadAfterFade;

        private void Update() 
        {
            if(shouldLoadAfterFade) 
            {
                waitToLoad -= Time.deltaTime;
                if(waitToLoad <= 0)
                {
                    shouldLoadAfterFade = false;
                    SceneManager.LoadScene(areaToLoad);
                }
            }   
        }
        private void OnTriggerEnter2D(Collider2D other) 
        {
            
            if(other.tag == "Player")
            {
                // SceneManager.LoadScene(areaToLoad);
                shouldLoadAfterFade = true;
                FadeScript.instance.FadeIn();

                PlayerController.instance.areaTransitionName = areaTransitionName;
            }


        }
    }


}
