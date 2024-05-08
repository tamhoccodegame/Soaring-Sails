using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();


    void Start  ()
    {
        audioClips.Add("enemyHitImpact", Resources.Load<AudioClip>("EnemyHitImpact"));
        audioClips.Add("footstep", Resources.Load<AudioClip>("FootStep"));
        audioClips.Add("footstep2", Resources.Load<AudioClip>("FootStep2"));
        audioClips.Add("levelup", Resources.Load<AudioClip>("LevelUp"));
        audioClips.Add("attack", Resources.Load<AudioClip>("Attack"));
        audioClips.Add("bossmusic", Resources.Load<AudioClip>("BossMusic"));
    }

    public void PlayAudioClip(string clipName)
    {
        if (audioClips.ContainsKey(clipName))
        {
            AudioSource.PlayClipAtPoint(audioClips[clipName], transform.position);
        }
        else
        {
            Debug.Log("Ko");
        }
    }

	public AudioClip GetAudioClip(string clipName)
	{
		if (audioClips.ContainsKey(clipName))
		{
			return audioClips[clipName];
		}
        return null;
	}
}
