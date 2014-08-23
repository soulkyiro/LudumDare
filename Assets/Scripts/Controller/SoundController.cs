using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{
    private bool sound;

    private float volumeEfect;
    private float volumeMusic;
    private float tempVolumeEfect;
    private float tempVolumeMusic;

	void Start () {
        sound = true;
        volumeMusic = 50.0F;
        volumeEfect = 50.0F;
	}

    public float VolumeMusic
    {
        get { return volumeMusic; }
        set { volumeMusic = value; }
    }

    public float VolumeEfect
    {
        get { return volumeEfect; }
        set { volumeEfect = value; }
    }

    public void Mute()
    {
        if (sound)
        {
            DisableSound();
        }
        else
        {
            EnableSound();
        }
    }

    private void EnableSound() {
        sound = true;
        volumeMusic = tempVolumeMusic;
        volumeEfect = tempVolumeEfect;
    }

    private void DisableSound()
    {
        sound = false;
        tempVolumeMusic = VolumeMusic;
        tempVolumeEfect = VolumeEfect;
        VolumeMusic = 0.0F;
        VolumeEfect = 0.0F;
    }
}
