using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SVS.FeedbackSystem
{
    public class AudioFeedback : MonoBehaviour
    {
        [SerializeField]
        private AudioSource source;

        [SerializeField]
        private AudioClip audioClip;

        private void Awake()
        {
            source = GetComponent<AudioSource>();
        }

        private void Start()
        {
            source.PlayOneShot(audioClip);
            StartCoroutine(DestroyAfterFinishedPlaying());
        }

        private IEnumerator DestroyAfterFinishedPlaying()
        {
            yield return new WaitForSeconds(audioClip.length);
            Destroy(gameObject);
        }
    }
}