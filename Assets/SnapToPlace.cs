using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;



namespace Valve.VR.Extras
{
    public class SnapToPlace : MonoBehaviour
    {
        public GameObject snaper;
        public UnityEvent debugAudio;
        private Transform snaperTransform;
        
        bool inside = false;
        
        void Start()
        {
            
        }

        

        // Update is called once per frame
        void Update()
        {
            if (inside == true)
            {
                snaperTransform = snaper.transform;
                this.transform.position = snaperTransform.position;
                this.transform.rotation = snaperTransform.rotation;
                
            }
        }


        void OnTriggerEnter(Collider other)
        {
            if (GameObject.ReferenceEquals(snaper, other.gameObject))
            {
                inside = true;
                debugAudio.Invoke();
            }
        }
        void OnTriggerExit(Collider other)
        {
            if (GameObject.ReferenceEquals(snaper, other.gameObject))
            {
                inside = false;

            }
        }
    }
}
