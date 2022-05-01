using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JRPG.Controller;

namespace JRPG.Core
{
    public class PlayerLoader : MonoBehaviour
    {

        [SerializeField] GameObject player;
        // Start is called before the first frame update
        void Start()
        {
            if(PlayerController.instance == null)
            {
                Instantiate(player);
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
