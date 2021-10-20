using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
	[SerializeField] AudioClip crack;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] GameObject smokeParticles;
	int timesHit;
    Level level;
	
	void Start()
    {
        level = FindObjectOfType<Level>();
        CountBreakableBricks();
    }

    private void CountBreakableBricks()
    {
        if (tag == "Breakable")
        {
            level.RegisterBreakableBrick();
        }
    }

    void OnCollisionEnter2D()
    {
        if (tag == "Breakable")
        {
            HandleHit();
		}
	}
	
	private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) 
        {
            DestroyBrick();
        }
        else
        {
			ShowNextHitSprites();
		}
	}

    private void DestroyBrick()
    {
        PuffSmoke();
        level.BrickDestoyed();
        Destroy(gameObject);
    }

    private void PuffSmoke()
    {
		GameObject smokePuff = Instantiate (smokeParticles, transform.position, transform.rotation);
        Destroy(smokePuff, 2f);
        var mainParticleSystem = smokePuff.GetComponent<ParticleSystem>().main;
        mainParticleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
	}
	
	void ShowNextHitSprites()
    {
		int spriteIndex = timesHit - 1;
		
		if (hitSprites[spriteIndex] != null)
        {
			GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}
	}
}
