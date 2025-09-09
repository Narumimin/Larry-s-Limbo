using UnityEngine;

public class Attack2 : MonoBehaviour
{
    int speed = 10;
    public Transform point_l;
    public Transform point_r;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Auch"); // Función de Daño Larry
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Atack_left();
                
        }
        if (Input.GetMouseButton(1))
        {
            Atack_right();

        }
    }

    public void Atack_left()
    {
        transform.position = Vector3.MoveTowards(transform.position, point_l.position, speed*Time.deltaTime);
        transform.localScale = new Vector3(-1f, 1f, 1f);
    }
    public void Atack_right()
    {
        transform.position = Vector3.MoveTowards(transform.position, point_r.position, speed * Time.deltaTime);
        transform.localScale = new Vector3(1f, 1f, 1f);
    }


}
