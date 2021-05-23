using UnityEngine;

public class RaycastCharacter : MonoBehaviour
{
  //raycast para gestionar la posicion de un nuevo mob
  // Start is called before the first frame update

  public LayerMask groundLayer;
  public GameObject currentObject;
  
  public bool objectToPlace;

  Ray ray;
  RaycastHit hit;

  // Update is called once per frame
  void Update() 
  {
    if(objectToPlace)
    {
      ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if(Physics.Raycast(ray,out hit,100,groundLayer))
      {
        currentObject.transform.position = hit.point;
      }
      PlaceObject();
    }
  }
  void PlaceObject()
  {
    if (Input.GetKeyDown(KeyCode.Mouse1))
    {
      objectToPlace = false;
      currentObject.GetComponent<Hero>().ChangeToFinalMaterial();
      currentObject.GetComponent<AllyMovement>().enabled = true;
      currentObject = null;
    }
  }
}
