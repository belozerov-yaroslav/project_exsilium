using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class FootStepsTrigger : MonoBehaviour
{
    [SerializeField] private List<AudioSource> footstepsSound = new List<AudioSource>();
    [SerializeField] private Animator vasiliyAnimator;
    private float _lastPlay;
    private float _lengthLastPlay;

    private Player player;


    private void Start()
    {
        player = Player.Instance.GetComponent<Player>();
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.CompareTag("Player") && player.CheckVelocity()) ||
            (Vasil.Instance is not null && vasiliyAnimator is not null && vasiliyAnimator.gameObject.activeInHierarchy &&
             vasiliyAnimator.GetCurrentAnimatorClipInfo(0)
                 .FirstOrDefault().clip.name ==
             "New Animation"))
        {
            var randomSound = footstepsSound[RandomNumberGenerator.GetInt32(footstepsSound.Count)];
            if (Time.time - _lastPlay - _lengthLastPlay > 0)
            {
                _lastPlay = Time.time;
                randomSound.Play();
                _lengthLastPlay = randomSound.clip.length + 0.2f;
            }
        }
    }
}