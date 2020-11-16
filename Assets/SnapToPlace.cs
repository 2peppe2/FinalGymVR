﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using System;




namespace Valve.VR.Extras
{
    public class SnapToPlace : MonoBehaviour
    {
        public SteamVR_Action m_Action;
        public GameObject snaper;
        public UnityEvent debugAudio;
        private Transform snaperTransform;
        private MeshFilter otherMesh;
        private MeshFilter thisMesh;
        bool inside = false;
        

        void Start()
        {
            snaper.transform.localScale = this.transform.localScale;
            
        }
        private void Awake()
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
                thisMesh = this.GetComponent<MeshFilter>();
                otherMesh = snaper.GetComponent<MeshFilter>();

                snaper.GetComponent<Renderer>().enabled = false;

            }
            else
            {
                
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
