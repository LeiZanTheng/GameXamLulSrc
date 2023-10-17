using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float spinningSpeed = 2f;
     AudioSource audioSrc;
     AudioClip coinPickUp;
     AudioClip LauDaiTinhAi;
     UIManager uiManager;
    private void Start() {
        audioSrc = GetComponent<AudioSource>();
        audioSrc.enabled = false;
        coinPickUp = Resources.Load<AudioClip>("pickupCoin");
        LauDaiTinhAi = Resources.Load<AudioClip>("LDTA");
        uiManager = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
    }
    private void Update() {
        transform.Rotate(0f, spinningSpeed * Time.deltaTime  * 100f, 0f, Space.Self);
    }
    private void OnTriggerEnter(Collider other) {
        audioSrc.enabled = true;
        if(other.CompareTag("Player") && gameObject.tag == "DamCoin")
        {
            audioSrc.loop = true;
            Transform TpDestination = GameObject.FindGameObjectWithTag("TPPoint").GetComponent<Transform>();
            Transform player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            player.position = TpDestination.position;
            uiManager.HaveLost = true; 
        }
        else if(other.CompareTag("Player") && gameObject.tag == "NormalCoin")
        {
            uiManager.coinCounter++;
            audioSrc.PlayOneShot(coinPickUp);
            Destroy(gameObject, coinPickUp.length);
        }
    }
}
