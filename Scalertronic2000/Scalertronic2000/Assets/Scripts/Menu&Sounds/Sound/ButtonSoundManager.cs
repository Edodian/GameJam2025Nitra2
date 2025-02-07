using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundManager : MonoBehaviour
{
    public void PlayYes()
    {
        if (SoundManager.sndm != null)
        {
            SoundManager.sndm.Play("Yes");
        }
    }
    public void PlayNo()
    {
        if (SoundManager.sndm != null)
        {
            SoundManager.sndm.Play("No");
        }
    }
    public void PlayEmpty()
    {
        if (SoundManager.sndm != null)
        {
            SoundManager.sndm.Play("Empty");
        }
    }
    public void PlayClick()
    {
        if (SoundManager.sndm != null)
        {
            SoundManager.sndm.Play("Click");
        }
    }
}

