using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace Valve.VR.InteractionSystem.Sample
{

    [RequireComponent(typeof(AudioSource))]

    public class eventScript : MonoBehaviour
    {
        public HoverButton hoverButton;
        
        AudioSource audioSource;
        AudioSource audioData;
        bool playing = false;

        // Start is called before the first frame update
        void Start()
        {
            //Fetch the AudioSource from the GameObject
            
            
                audioData = GetComponent<AudioSource>();

            hoverButton.onButtonDown.AddListener(OnButtonDown);

        }


        private void OnButtonDown(Hand hand)
        {
            Debug.Log("Button pressed", hoverButton);
            if (!playing)
            {
                audioData.Play(0);
                playing = true;
            }
            else
            {
                audioData.Pause();
                playing = false;
            }
        }
    }
}