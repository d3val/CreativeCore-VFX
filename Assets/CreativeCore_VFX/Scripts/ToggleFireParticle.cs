using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class ToggleFireParticle : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Space;

    private ParticleSystem fireParticle;
    public ParticleSystem igniteParticle;
    public ParticleSystem extinguishParticle;
    public ParticleSystem rainParticle;
    public GameObject pointLight;

    bool isPlaying = true;

    private void Start()
    {
        fireParticle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if(isPlaying)
            {
                fireParticle.Stop();
                pointLight.SetActive(false);
                if (extinguishParticle != null)
                    extinguishParticle.Play();
                if (rainParticle != null)
                    rainParticle.Play();
                isPlaying = false;
            } 
            else
            {
                if (rainParticle != null)
                    rainParticle.Stop();
                fireParticle.Play();
                pointLight.SetActive(true);
                if (igniteParticle != null)
                    igniteParticle.Play();
                isPlaying = true;
            }
        }
    }
}
