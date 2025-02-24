using UnityEngine;

public class GemBehaviour : MonoBehaviour
{
    private int index;
    public TMPro.TMP_Text statusText;

    public GameObject[] prefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        statusText = GameObject.Find("Status").GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.name == "Ground")
        {
            if (gameObject.tag == "GemPickUp")
            {
                statusText.text = "Gem Missed";
            }
        }

        if (collision.gameObject.name == "Ground" || collision.gameObject.name == "boundary")
        {
            Destroy(gameObject);
            float randomX = Random.Range(-4f, 6f);
            float randomZ = Random.Range(-15f, -5f);
            Vector3 spawnPosition = new Vector3(randomX, 10, randomZ);
            index = Random.Range(0, prefabs.Length); 
            Instantiate(prefabs[index], spawnPosition, Quaternion.identity);
        }
    }
    
}

