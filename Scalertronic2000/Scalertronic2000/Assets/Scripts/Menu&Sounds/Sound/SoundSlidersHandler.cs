using UnityEngine;
using UnityEngine.Audio;
using System;
using System.Collections.Generic;

public class SoundSlidersHandler : MonoBehaviour
{
    public UnityEngine.UI.Slider SndVolumeSlider, MscVolumeSlider, AmbVolumeSlider;
    private SoundManager sndm;

    void Start()
    {
        sndm = SoundManager.sndm;
        UpdateSliders();
    }

    void OnEnable()
    {
        if (sndm != null)
        {
            UpdateSliders();
        }
    }

    private void UpdateSliders()
    {
        // Update slider values based on current SoundManager settings
        SndVolumeSlider.value = sndm.SoundVolume;
        MscVolumeSlider.value = sndm.MusicVolume;
        AmbVolumeSlider.value = sndm.AmbientVolume;
    }

    public void SetMusicVolume()
    {
        sndm.UpdateMusicVolume(MscVolumeSlider.value);
    }

    public void SetSoundVolume()
    {
        sndm.UpdateSoundVolume(SndVolumeSlider.value);
    }

    public void SetAmbientVolume()
    {
        sndm.UpdateAmbientVolume(AmbVolumeSlider.value);
    }
}
