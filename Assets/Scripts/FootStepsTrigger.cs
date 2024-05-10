using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class FootStepsTrigger : MonoBehaviour
{
    public float minPitch;
    public float maxPitch;
    
    private AudioSource _footstepSound ;
    private float _lastPlay;

    private Player player;
    
    
    private void Start()
    {
        _footstepSound = GetComponent<AudioSource>();
        player = Player.Instance.GetComponent<Player>();
    }
    

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && player.CheckVelocity() && Time.time - _lastPlay > _footstepSound.clip.length)
        {
            _lastPlay = Time.time;
            _footstepSound.Play();
            _footstepSound.pitch = Random.Range(minPitch, maxPitch);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _footstepSound.Stop();
    }
}
