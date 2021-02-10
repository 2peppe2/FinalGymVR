using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class runingWater : MonoBehaviour
{

    public ParticleSystem system;
    public UnityEvent stopWaterSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartWater()
    {
        system.Play();
    }
    public void StopWater()
    {
        system.Stop();
        stopWaterSound.Invoke();
    }
}
