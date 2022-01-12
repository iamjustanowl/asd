using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{	

	[Header("Attributes")]
	public float range=15f;
	public float fireRate = 1f;
	private float fireCountdown = 0f;

	[Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public Transform turret;
    public Transform target;
    public float turnSpeed = 10f;
	private SpriteRenderer mySpriteRenderer;
	public SpriteRenderer mySpriteRenderer2;

	public GameObject bulletPrefab;
	public Transform firePoint;

	
	
	private void Awake()
   {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
   }

    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    	void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
		}else
        {
            target = null;
        }

	}


    void Update()
    {
        if (target == null)
        return;

		  
        if(target.position.x > turret.position.x)
        {
            
            if(mySpriteRenderer != null)
            {
                 
                 mySpriteRenderer.flipX = true;
            }
        }else {
			mySpriteRenderer.flipX = false;
		}

		if(fireCountdown <= 0f)
		{
			Shoot();
			fireCountdown = 1f / fireRate;
		}

		fireCountdown -= Time.deltaTime;

		if(target.position.x < firePoint.position.x)
        {
            // if the variable isn't empty (we have a reference to our SpriteRenderer
            if(mySpriteRenderer2 != null)
            {
                 // flip the sprite
                 mySpriteRenderer2.flipX = true;
            }
        }else {
			mySpriteRenderer2.flipX = false;
		}

	}

	void Shoot ()
	{
		GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet>();

		if (bullet != null)
			bullet.Seek(target);
	}

    
	 void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
    
}
