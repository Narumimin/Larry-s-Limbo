using Unity.VisualScripting;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed; //Velocidad de las plataformas
    public int startingPoint; //Punto inicial para la paltaforma
    public Transform upPoint;
    public Transform downPoint;
    private int i; //incrementador
    private bool platformMoving = false;

    private void Start()
    {
        transform.position = downPoint.position; //Teleporta el objeto al punto inicial
    }

    private void Update()
    {
        if (platformMoving == false)
        {
            MovePlatformDown();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        MovePlatformUp();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        platformMoving = false;
    }

    public void MovePlatformUp()
    {
        platformMoving = true;
        transform.position = Vector2.MoveTowards(transform.position, upPoint.position, speed * Time.deltaTime); //Mueve el onjeto hacia uno de los puntos donde va a pasar
    }

    public void MovePlatformDown()
    {
        transform.position = Vector2.MoveTowards(transform.position, downPoint.position, speed * Time.deltaTime);
    }


    //public void MovePlatform()
    //{
    //if (Vector2.Distance(transform.position, aa ddpoints[i].position) < 0.1f) //compara la distancia entre el objeto y uno de los puntos donde va a pasar
    //{
    //    i++; // cuenta para arriba para pasar al siguiente punto
    //    if (i == points.Length) //compara cuantos por cuantos puntos ha pasado el objeto al numero de puntos totales
    //    {
    //        i = 0; //reinicia los puntos al inicio para que el objeto regrese a su lugar inicial
    //    }
    //}
    //transform.position = Vector2.MoveTowards(transform.position, points[1].position, speed * Time.deltaTime); //Mueve el onjeto hacia uno de los puntos donde va a pasar
    //}

}