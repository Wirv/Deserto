using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && GameManager.Singleton.Cards.Count < 2)
        {
            PointerOverUIElement();
        }
    }
    
    private void PointerOverUIElement()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current)
        {
            position = new Vector2(Input.mousePosition.x, Input.mousePosition.y)
        };

        // Crea una lista per tenere traccia degli oggetti colpiti dal raycast
        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        // Controlla se uno degli oggetti colpiti è questa carta
        foreach (RaycastResult result in results)
        {
            if (result.gameObject.GetComponent<Animator>() && !result.gameObject.GetComponent<Animator>().GetBool("Show"))
            {
                Animator animator = result.gameObject.GetComponent<Animator>();
                animator.SetBool("Show", true);
                GameManager.Singleton.Cards.Add(result.gameObject);
            }
        }

    }
}
