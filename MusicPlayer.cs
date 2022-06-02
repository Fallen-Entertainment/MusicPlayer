// MMORPG Kit 1.73c
// By Fallen
using UnityEngine;

namespace MultiplayerARPG
{
    public class MusicPlayer : MonoBehaviour
    {
        [Range(0, 100)]
        public int SoundMultiplier = 100;
        AudioSource BGM;
        private AudioClip[] Music;

        public void Start()
        {
            // Create Audio Source Object
            if (BGM == null)
            {
                GameObject audioSourceObject = new GameObject("_bgmAudioSource");
                audioSourceObject.transform.parent = GetComponentInParent<Transform>();
                audioSourceObject.transform.localPosition = Vector3.zero;
                audioSourceObject.transform.localRotation = Quaternion.identity;
                audioSourceObject.transform.localScale = Vector3.one;
                BGM = audioSourceObject.AddComponent<AudioSource>();
                BGM.spatialBlend = 1f;
            }

            // Get Music
            Music = GameInstance.Singleton.Music;

            // Get Clip
            int randomClip = Random.Range(0, Music.Length);

            // Start Music
            BGM.PlayOneShot(Music[randomClip], AudioManager.Singleton == null ? 1f : AudioManager.Singleton.bgmVolumeSetting.Level * SoundMultiplier);
            return;
        }

        public void Update()
        {
            // Change Clip
            if (!BGM.isPlaying)
            {
                // Get Clip
                int randomClip = Random.Range(0, Music.Length);

                // Start Music
                BGM.PlayOneShot(Music[randomClip], AudioManager.Singleton == null ? 1f : AudioManager.Singleton.bgmVolumeSetting.Level * 100);

                return;
            }
        }
    }
}

