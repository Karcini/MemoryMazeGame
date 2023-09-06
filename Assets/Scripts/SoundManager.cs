using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField]
    AudioSource _BGMusic;
    public void BGMusicStop() { _BGMusic.Stop(); }
    public void BGMusicStart() { _BGMusic.Play(); }

    [SerializeField]
    AudioSource _coinAudio;
    public void CoinAudio() { _coinAudio.Play(); }

    [SerializeField]
    AudioSource _mistAudio;
    public void MistAudio() { _mistAudio.Play(); }
    public void MistAudioStop() { _mistAudio.Stop(); }

    [SerializeField]
    AudioSource _eagleAudio;
    public void EagleAudio() { _eagleAudio.Play(); }

    [SerializeField]
    AudioSource _pickAudio;
    public void PickAudio() { _pickAudio.Play(); }
    public override void Init()
    {

    }

}
