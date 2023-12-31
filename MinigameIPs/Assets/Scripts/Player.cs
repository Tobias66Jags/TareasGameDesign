using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static float newC=10;

    public Manager manager;
    private void Update()
    {
        // Mover el objeto "ObjetoSeguidor" junto con el mouse.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = mousePosition;

        // Detectar si se hizo clic en un objeto.
        if (Input.GetMouseButtonDown(0)) // 0 representa el bot�n izquierdo del rat�n.
        {
            // Rayo desde la c�mara hasta la posici�n del rat�n.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Comprobar si el rayo golpe� un objeto.
            if (hit.collider != null)
            {
                // Desactivar el objeto golpeado.
                /*hit.collider.gameObject.SetActive(false);
                Animator anim;
               hit.collider.gameObject.GetComponent<Animator>().Play("Death");*/

                StartCoroutine(SetDeath(hit));

            }
        }

         IEnumerator SetDeath(RaycastHit2D hit)
        {
            Animator anim;
            hit.collider.gameObject.GetComponent<Animator>().Play("Death");
            yield return new WaitForSecondsRealtime(0.10f);
            hit.collider.gameObject.SetActive(false);
            newC= hit.collider.gameObject.GetComponent<Counter>().counter;

            if (newC < manager.numeroRespuesta)
            {
                Debug.Log("Se pudo");
                StartCoroutine(manager.HacerPeticion("http://172.16.48.37:5000/serv/tobias/tiro/" + newC.ToString()));

            }
         


            StopAllCoroutines();
        } 
    }







}