using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAnimationScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Animator animator;

    public void OnPointerEnter(PointerEventData eventData)
    {
        animator.SetBool("isSelected",true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        animator.SetBool("isSelected",false);
    }
}
