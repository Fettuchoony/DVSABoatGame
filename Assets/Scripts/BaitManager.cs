using UnityEngine;

// When changing the positions of stuff you have to subtract the current pos 
// from the parents pos and then add that difference to the part
public class BaitManager : MonoBehaviour
{
    // How long the bait is going to stay present.
    public float baitDuration = 0f;
    // How long after bait despawns the player waits to place another.
    public float coolDown = 0f;
    // For the salmon manager so it knows if bait is present or not
    public bool isBaitPresent = false;
    // The bait's curr x pos
    public float baitXPos = 0f;
    // The current amount of baits the player has
    public int totalBaits = 0;
    // The time bait has been present
    private float baitTime = 0f;
    // The time colldown time started
    private float coolDownTime = 0f;
    private SpriteRenderer sprite;

    //The min and max value for this cur sprite in screen: -27.3 to -11.9. This is gonna change later with the real one;
    // The min and max value for fish in screen: -1 to 14
    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    public void FixedUpdate()
    {
        if (Time.time - baitTime <= baitDuration)
        {
            //Adjust this later for the real sprite.
            transform.position = new Vector2(baitXPos, -3 + Mathf.Sin(Time.time * 4) / 4);
        }
        else if(isBaitPresent)
        {
            // gameObject.SetActive(false);
            sprite.enabled = false;
            isBaitPresent = false;
            coolDownTime = Time.time;
        }
    }
    public void spawnBait()
    {
        Debug.Log("Ran before if statement, "+!isBaitPresent+", "+(totalBaits > 0)+", "+(Time.time - coolDownTime >= coolDown));
        Debug.Log("Ran: " + Time.time +", "+coolDownTime);
        if (!isBaitPresent && totalBaits > 0 && Time.time - coolDownTime >= coolDown)
        {
            Debug.Log("Ran past if statement");
            totalBaits -= 1;
            isBaitPresent = true;
            transform.position = new Vector2(Random.Range(-1.04f, 14.36f), -3);
            baitXPos = transform.position.x;
            baitTime = Time.time;
            // gameObject.SetActive(true);
            sprite.enabled = true;
        }
    }
}
