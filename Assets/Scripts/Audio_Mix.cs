using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class Audio_Mix : MonoBehaviour
{
    public AudioMixer MasterAudio;
    public void SetSfxLvl(float sfxLvl)
    {
        MasterAudio.SetFloat("sfxVol",sfxLvl); 
    }
    public void SetMusicLvl(float MusicLvl)
    {
        MasterAudio.SetFloat("musicVol", MusicLvl);
    }

}
