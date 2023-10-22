using UnityEngine;

public class CustomBullet : MonoBehaviour
{
    //Assignables
    public Rigidbody rb;
    public GameObject explosion;
    public LayerMask whatIsEnemies;

    //Stats
    [Range(0f, 1f)]
    public float bounciness;
    public bool useGravity;

    //Damage
    public int bulletDamage;
    public int explosionDamage;
    public float explosionRange;
    public float explosionForce;

    //Lifetime
    public int maxCollisions;
    public float maxLifetime;
    public int explosionDuration;
    public bool explodeOnTouch = true;
    public bool alreadyExploded = false;

    //Static bools
    public static bool bulletExploded = false;

    //bools
    public bool directHit = false;

    int collisions;
    PhysicMaterial physics_mat;

    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        //When to explode:
        if (collisions >= maxCollisions) Explode();

        //Count down lifetime
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0)
        {
            Explode();
        }
    }
    private void Explode()
    {
        bulletExploded = true;

        //Instantiate Explosion
        if (alreadyExploded == false)
        {

            GameObject explosionObj = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            
            alreadyExploded = true;
            
            //Destroy the explosion object once it has finished
            Destroy(explosionObj, explosionDuration);

            bulletExploded = false;
        }

        //Check for enemies 
        Collider[] enemies = Physics.OverlapSphere(transform.position, explosionRange, whatIsEnemies);
        for (int i = 0; i < enemies.Length; i++)
        {
            //Get component of enemy and call the Take Damage function, if not directly hitting enemy (when directHit = false)
            if(directHit == false)
            {
                enemies[i].GetComponent<EnemyAIScript>().TakeDamage(explosionDamage);
            }
        }

        //Destroy bullet after 0.05 seconds
        Invoke("Delay", 0.05f);
    }

    private void Delay()
    {
       Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Check if bullet collides with enemy or maze geometry
        if(other.CompareTag("Enemy") || other.CompareTag("Maze"))
        {
            //Count up collisions
            collisions++;
            
            //Explode if explodeOnTouch is activated
            if (explodeOnTouch) Explode();
        }

        //Deal bullet damage to enemy if directly hit
        if(other.CompareTag("Enemy"))
        {
            //Set directHit to true when directly hitting enemy
            directHit = true;

            other.GetComponent<EnemyAIScript>().TakeDamage(bulletDamage);

            //Explode if explodeOnTouch is activated
            if (explodeOnTouch) Explode();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            //Set directHit to true when directly hitting enemy
            directHit = true;

            other.GetComponent<EnemyAIScript>().TakeDamage(bulletDamage);

            //Explode if explodeOnTouch is activated
            if (explodeOnTouch) Explode();
        }
    }

    private void Setup()
    {
        //Create a new Physic material
        physics_mat = new PhysicMaterial();
        physics_mat.bounciness = bounciness;
        physics_mat.frictionCombine = PhysicMaterialCombine.Minimum;
        physics_mat.bounceCombine = PhysicMaterialCombine.Maximum;
        //Assign material to collider
        GetComponent<SphereCollider>().material = physics_mat;

        //Set gravity
        rb.useGravity = useGravity;
    }

    //Visualise the explosion range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}
