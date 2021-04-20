using UnityEngine;

namespace Portal.Kindergarten.Scenes.UrduLevels.UL1_Assets.Scripts {
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource correctAudio;
        [SerializeField] private AudioSource wrongAudio;

        public  void PlayCorrectAudio() {
            correctAudio.Play();
        }

        public void PlayWrongAudio() {
            wrongAudio.Play();
        }
    }
}
