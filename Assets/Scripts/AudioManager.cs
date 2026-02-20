using UnityEngine;
using System.Collections.Generic;


public enum soundType {
    Shoot,
    Hit,
    Explode
}

[System.Serializable]
public  class MySounds {
    public soundType name;
    public AudioClip clip;

    [Range(0f, 100f)] public float Shootingvolume;
}

public class AudioManager : MonoBehaviour
{
[Header("Shooting SFX")]
[SerializeField] AudioClip ShootingClip;
[SerializeField] [Range(0,100)] float  Shootingvolume;


[SerializeField] List<MySounds> soundsObj;

[Header("Hit SFX")]
[SerializeField] AudioClip HitClip;
[SerializeField] [Range(0,100)] float  Hitvolume;

[Header("Explode SFX")]
[SerializeField] AudioClip ExplodeClip;
[SerializeField] [Range(0,100)] float  Explodevolume;

public void PlayShootingSFX()
    {
        playClip(ShootingClip,Shootingvolume);
    }
public void PlayHiySFX()
    {
        playClip(HitClip,Hitvolume);
    }

public void ExplodeSFX()
    {
        playClip(ExplodeClip,Explodevolume);

    }

    public void playClip(AudioClip clip,float volume)
    {
            if (clip!=null)
        {
            AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position,volume/100);
        }
        
    }
        

}
