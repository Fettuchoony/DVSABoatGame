using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{

    public GameObject mudParticle;
    [Range (1, 20)] public int subdivisions;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 topLeftAnchor = transform.position;
        // Y scrolling
        for (int i = 0; i < 8 * subdivisions; i++) {
            // X scrolling
            for (int j = 0; j < 14 * subdivisions; j++) {
                GameObject currParticle = GameObject.Instantiate(mudParticle);
                currParticle.transform.position = new Vector3(
                (topLeftAnchor.x + j) / subdivisions, 
                (topLeftAnchor.y - i) / subdivisions, 
                0);
                currParticle.transform.localScale = currParticle.transform.localScale / subdivisions;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
