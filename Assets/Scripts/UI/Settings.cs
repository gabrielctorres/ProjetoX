using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    #region DEFAULT
    private AudioClip[] auClipMusic; // array of music
    public static AudioClip auClipSfx0; // sfx audio
    public GameObject[] stMasterManager; // settings master manager
    public static bool check_Music; // check play music
    public PlayerScript pScript;
    void Start()
    {
        SaveStates(); // load states
        AudioManager(); // load audio
        stMasterManager[2].GetComponent<Toggle>().isOn = true;
    }

    void Update()
    {
        #region CHECK OUT - MUSIC NOT PLAYING
        if (!stMasterManager[0].GetComponent<AudioSource>().isPlaying)
        {
            stMasterManager[0].GetComponent<AudioSource>().clip = auClipMusic[Random.Range(0, auClipMusic.Length)];
            stMasterManager[0].GetComponent<AudioSource>().Play();
            check_Music = !check_Music;
        }
        #endregion
    }
    #endregion

    #region CHECK STATES 
    public void SettingsStates(int i)
    {
        switch (i)
        {
            // music
            case 0:
                if (stMasterManager[2].GetComponent<Toggle>().isOn == false)
                {
                    PlayerPrefs.SetInt("MUSIC", 0);
                    stMasterManager[0].GetComponent<AudioSource>().mute = true;
                    stMasterManager[4].GetComponent<Slider>().interactable = false;
                }
                else
                {
                    PlayerPrefs.SetInt("MUSIC", 1);
                    stMasterManager[0].GetComponent<AudioSource>().mute = false;
                    stMasterManager[4].GetComponent<Slider>().interactable = true;
                }
                break;

            // volume music
            case 1:
                stMasterManager[0].GetComponent<AudioSource>().volume = stMasterManager[4].GetComponent<Slider>().value;
                PlayerPrefs.SetFloat("VOLUMEMUSIC", stMasterManager[4].GetComponent<Slider>().value);
                PlayerPrefs.Save();
                break;

            // audio
            case 2:
                if (stMasterManager[3].GetComponent<Toggle>().isOn == false)
                {
                    PlayerPrefs.SetInt("AUDIO", 0);
                    stMasterManager[1].GetComponent<AudioSource>().mute = true;
                    stMasterManager[1].GetComponent<AudioSource>().playOnAwake = false;
                    stMasterManager[5].GetComponent<Slider>().interactable = false;

                }
                else
                {
                    PlayerPrefs.SetInt("AUDIO", 1);
                    stMasterManager[1].GetComponent<AudioSource>().mute = false;
                    stMasterManager[1].GetComponent<AudioSource>().playOnAwake = true;
                    stMasterManager[1].GetComponent<AudioSource>().PlayOneShot(auClipSfx0);
                    stMasterManager[5].GetComponent<Slider>().interactable = true;
                }
                break;

            // volume audio
            case 3:
                stMasterManager[1].GetComponent<AudioSource>().volume = stMasterManager[5].GetComponent<Slider>().value;
                PlayerPrefs.SetFloat("VOLUMEAUDIO", stMasterManager[5].GetComponent<Slider>().value);
                PlayerPrefs.Save();
                break;
            //giroscopio
            case 4:
                if(stMasterManager[6].GetComponent<Toggle>().isOn == false)
                {
                    pScript.giroscopio = false;
                }
                else
                {
                    pScript.giroscopio = true;
                }
                break;
        }
    }

    void SaveStates()
    {
        stMasterManager[4].GetComponent<Slider>().value = PlayerPrefs.GetFloat("VOLUMEMUSIC"); // SAVE SETTINGS VOLUME OF MUSIC
        stMasterManager[5].GetComponent<Slider>().value = PlayerPrefs.GetFloat("VOLUMEAUDIO"); // SAVE SETTINGS VOLUME OF AUDIO

        // SAVE MUSIC SETTINGS
        if (PlayerPrefs.GetInt("MUSIC") == 0)
        {
            stMasterManager[2].GetComponent<Toggle>().isOn = false;
            stMasterManager[0].GetComponent<AudioSource>().mute = true;
            stMasterManager[4].GetComponent<Slider>().interactable = false;
            stMasterManager[0].GetComponent<AudioSource>().volume = stMasterManager[4].GetComponent<Slider>().value;
        }
        else
        {
            stMasterManager[2].GetComponent<Toggle>().isOn = true;
            stMasterManager[0].GetComponent<AudioSource>().mute = false;
            stMasterManager[4].GetComponent<Slider>().interactable = true;
            stMasterManager[0].GetComponent<AudioSource>().volume = stMasterManager[4].GetComponent<Slider>().value;
        }

        // SAVE AUDIO SETTINGS
        if (PlayerPrefs.GetInt("AUDIO") == 0)
        {
            stMasterManager[3].GetComponent<Toggle>().isOn = false;
            stMasterManager[1].GetComponent<AudioSource>().mute = true;
            stMasterManager[5].GetComponent<Slider>().interactable = false;
            stMasterManager[1].GetComponent<AudioSource>().volume = stMasterManager[5].GetComponent<Slider>().value;
        }
        else
        {
            stMasterManager[3].GetComponent<Toggle>().isOn = true;
            stMasterManager[1].GetComponent<AudioSource>().mute = false;
            stMasterManager[5].GetComponent<Slider>().interactable = true;
            stMasterManager[1].GetComponent<AudioSource>().volume = stMasterManager[5].GetComponent<Slider>().value;
        }
    }

    void AudioManager()
    {
        // get components audio source  and load audios
        stMasterManager[0].GetComponent<AudioSource>();
        stMasterManager[1].GetComponent<AudioSource>();
        auClipMusic = Resources.LoadAll<AudioClip>("Audios/Musics");
        stMasterManager[0].GetComponent<AudioSource>().clip = auClipMusic[Random.Range(0, auClipMusic.Length)];
        stMasterManager[0].GetComponent<AudioSource>().Play();
        check_Music = true;
        auClipSfx0 = Resources.Load<AudioClip>("Audios/Sfxs/Clicks/0"); // click
    }
    #endregion
}