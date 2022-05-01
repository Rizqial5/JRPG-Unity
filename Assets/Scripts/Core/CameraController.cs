using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using JRPG.Controller;

namespace JRPG.Core
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] Transform target;
        [SerializeField] Tilemap tilemap;

        private Vector3 topRightLimit;
        private Vector3 bottomLeftLimit;
        private float halfWidth;
        private float halfHeight;
        private void Start() 
        {
            target = PlayerController.instance.transform;

            halfHeight = Camera.main.orthographicSize;
            halfWidth = halfHeight * Camera.main.aspect;

            topRightLimit = tilemap.localBounds.max + new Vector3(-halfWidth,-halfHeight, 0f);
            bottomLeftLimit = tilemap.localBounds.min + new Vector3(halfWidth,halfHeight, 0f);

            PlayerController.instance.SetBounds(tilemap.localBounds.min, tilemap.localBounds.max);
        }
        
        void LateUpdate()
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
            
            CameraBoundary();
        }

        private void CameraBoundary()
        {

            // keep the kamera inside tilemap
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
        }
    }
}
 