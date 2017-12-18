using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;using UnityEngine.EventSystems;


public class ClickAction : MonoBehaviour, IPointerClickHandler
{ 
	public void OnPointerClick(PointerEventData eventData)
	{
		SceneManager.LoadScene (2);
	}
}