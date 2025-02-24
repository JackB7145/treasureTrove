using Unity.VisualScripting;
using UnityEngine;

public class TreasureBoxBehaviour : MonoBehaviour
{
    CharacterController controller;
    private Vector3 moveInput;
    public TMPro.TMP_Text scoreText;
    public TMPro.TMP_Text statusText;
    public float moveSpeed = 3f;
    
    public GameObject[] prefabs;

    private int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        moveInput.z = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        controller.Move(moveInput);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GemPickUp" || collision.gameObject.tag == "Decoy")
        {
            if (collision.gameObject.name.StartsWith("Gem"))
            {
                scoreText.text = (int.Parse(scoreText.text) + 2).ToString();
            }
            else if (collision.gameObject.name.StartsWith("Coin"))
            {
                scoreText.text = (int.Parse(scoreText.text) + 1).ToString();
            }

            if (collision.gameObject.tag == "GemPickUp")
            {
                statusText.text = "Gem Captured";
            }
            else if (collision.gameObject.tag == "Decoy")
            {
                statusText.text = "DECOY";
            }
            Destroy(collision.gameObject);
            spawnItem();
        }
    }

    private void spawnItem()
    {
        float randomX = Random.Range(-4f, 6f);
        float randomZ = Random.Range(-15f, -5f);
        Vector3 spawnPosition = new Vector3(randomX, 10, randomZ);
        index = Random.Range(0, prefabs.Length); 
        Instantiate(prefabs[index], spawnPosition, Quaternion.identity);

    }
}
