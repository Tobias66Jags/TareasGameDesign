using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private void Update()
    {
        // Mover el objeto "ObjetoSeguidor" junto con el mouse.
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        transform.position = mousePosition;

        // Detectar si se hizo clic en un objeto.
        if (Input.GetMouseButtonDown(0)) // 0 representa el botón izquierdo del ratón.
        {
            // Rayo desde la cámara hasta la posición del ratón.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Comprobar si el rayo golpeó un objeto.
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
          
            StopAllCoroutines();
        } 
    }







}