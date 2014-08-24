using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{
    private bool sound;

    private float volumeEfect;
    private float volumeMusic;
    private float tempVolumeEfect;
    private float tempVolumeMusic;

    //Sounds
    public  AudioSource rocketBag;
    public AudioSource checkPointSignal;
    public AudioSource music;

    public AudioClip rocketBagClip = Resources.Load("Sounds/147796__joshun__rocket-take-off-sound") as AudioClip;
    public AudioClip checkPointSignalClip = Resources.Load("Sounds/220173__gameaudio__spacey-1up-power-up") as AudioClip;
    
    //Music
    public AudioClip musicClip = Resources.Load("Sounds/ONO_-_09_-_BETRAY_09") as AudioClip;

    void Awake() {
        //rocketBag = gameObject.AddComponent<AudioSource>();
        //rocketBag.audio.clip = rocketBagClip;
        //checkPointSignal = gameObject.AddComponent<AudioSource>();
        //checkPointSignal.audio.clip = checkPointSignalClip;
        music = gameObject.AddComponent<AudioSource>();
        music.loop = true;
        music.audio.clip = musicClip;
    }
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
