using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed = 10f;
    Rigidbody rb;
    [SerializeField]Transform orientation;
    AudioClip HitSound;
    AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        HitSound = Resources.Load<AudioClip>("hitHurt");
        audioSrc = GetComponent<AudioSource>();
        
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Vector3 move = transform.right * x + transform.forward * z;
        rb.AddForce(orientation.right * x * Speed * Time.deltaTime * 1000);
        rb.AddForce(orientation.forward * z * Speed * Time.deltaTime * 1000);

        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionEnter(Collision other) {
        audioSrc.PlayOneShot(HitSound);
    }
}
