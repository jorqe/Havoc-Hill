using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float currentHealth;
    public float horizontalInput;
    public float verticalInput;


    public HealthBar healthBar;//reference it in the inspector > DONE

    private void Start()
    {
        currentHealth = maxHealth; //Set health to max for variable manipulation and accurate slider representation
    }



    public void TakeDamage(float amount)//method to inflict damage
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);

    }

    public void heal(float amount)//method to heal 
    {
        currentHealth += 5;
        healthBar.SetSlider(currentHealth);
    }

    private void Update()//do something every tick
    {
        if (Input.GetKeyDown(KeyCode.K))//deal damage when K is pressed
        {
            TakeDamage(20f);
        }
        if (Input.GetKeyDown(KeyCode.L))//heal when L is pressed
        {
            heal(20f);
        }

        //Player Movement for testing collisions
       /* horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput);
        transform.Translate(-Vector3.right * Time.deltaTime * horizontalInput);*/

    }

}