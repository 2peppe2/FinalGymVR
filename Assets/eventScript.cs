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

        // Start is called before the first frame update
        void Start()
        {
            //Fetch the AudioSource from the GameObject
            
            audioData = GetComponent<AudioSource>();
            audioData.Play(0);
            hoverButton.onButtonDown.AddListener(OnButtonDown);

        }


        private void OnButtonDown(Hand hand)
        {
            Debug.Log("Button pressed", hoverButton);


            audioData.Pause();
        }
    }
}