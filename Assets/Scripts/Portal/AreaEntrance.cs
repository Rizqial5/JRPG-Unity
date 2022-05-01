using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JRPG.Controller;


namespace JRPG.Portal
{
    public class AreaEntrance : MonoBehaviour
    {
        public string transitionName;
        void Start()
        {
            if(PlayerController.instance == null) return;

            if(transitionName == PlayerController.instance.areaTransitionName)
            {
                PlayerController.instance.transform.position = transform.position;
            }

            if(FadeScript.instance == null) return;

            FadeScript.instance.FadeOut();
        }

        
    }
}
