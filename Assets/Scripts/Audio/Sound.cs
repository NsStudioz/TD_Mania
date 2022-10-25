
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;

    public AudioClip clip;


    [Range(0f, 1f)]
    public float volume;

    [Range(0f, 1f)]
    public float pitch;

    [Range(0f, 1f)]
    public float spatialBlend;

    // Property:
    public enum VolumeRolloff { LogarithmicRolloff, LinearRolloff, CustomRolloff }
    public VolumeRolloff volumeRolloff;
    //
    [Range(0f, 50f)]
    public float minDistance;

    [Range(0f, 100f)]
    public float maxDistance;

    public bool loop;
    public bool mute;

    [HideInInspector]
    public AudioSource source;
}
