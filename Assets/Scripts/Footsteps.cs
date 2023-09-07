using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    private PlayerController cc;
    public AudioClip step;
    private AudioSource audioSource;
    private float timebetween;

    // // void Awake(){
//     // //     cc = GameObject.Find("Player").GetComponent<PlayerController>();
//     // //     // cc = GetComponent<CharacterController>();
//     // //     audio = GetComponent<AudioSource>();
//     // // }
//     // //Start is called before the first frame update
//     // void Start()
//     // {
//     //     // cc = GetComponent<CharacterController>();
//     //     cc = GameObject.Find("Player").GetComponent<PlayerController>();
//     //     audio = GetComponent<AudioSource>();
//     // }

//     // // Update is called once per frame
//     // void Update()
//     // {
//     //     if (cc.isGrounded == true && cc.velocity.magnitude > 2f && audio.isPlaying == false) {
//     //         audio.Play();
//     //     }
//     // }
    void Start(){
        audioSource = GetComponent<AudioSource>();
        cc = GetComponent<PlayerController>();
    }
    void Update(){
        if (cc.walking && timebetween <= 0) {
            timebetween = 0.5f;
            audioSource.volume = Random.Range(0.3f, 0.3f);
            audioSource.pitch = Random.Range(0.3f, 0.5f);
            audioSource.PlayOneShot(step);
        }
        if (cc.running && timebetween <= 0){
            timebetween = 0.34f;
            audioSource.volume = Random.Range(0.5f, 1.0f);
            audioSource.pitch = Random.Range(0.5f, 1.0f);
            audioSource.PlayOneShot(step);
        }
        timebetween -= Time.deltaTime;

        // bool isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.33f);
        // if (isGrounded && !audioSource.isPlaying) {
        //     audioSource.PlayOneShot(step);
        // }
    }
}
