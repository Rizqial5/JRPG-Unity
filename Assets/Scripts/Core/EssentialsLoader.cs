using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JRPG.Controller;
using JRPG.Portal;

namespace JRPG.Core
{
    public class EssentialsLoader : MonoBehaviour
    {
        [SerializeField] GameObject UIScreen;
        [SerializeField] GameObject player;

        [SerializeField] Transform spawnPosition;
        void Start()
        {
            if(FadeScript.instance == null)
            {
                Instantiate(UIScreen);
            }

            if(PlayerController.instance == null)
            {
                Instantiate(player, spawnPosition.position,spawnPosition.rotation );
            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
