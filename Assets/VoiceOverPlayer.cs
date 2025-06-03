using UnityEngine;

public class VoiceOverPlayer : MonoBehaviour
{
    public AudioSource voiceAudio;
    public AudioClip voiceClip;

    public void PlayVoiceOver()
    {
        if (voiceAudio != null && voiceClip != null)
        {
            voiceAudio.clip = voiceClip;
            voiceAudio.Play();
        }
    }
}
