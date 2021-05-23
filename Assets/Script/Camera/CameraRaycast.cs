using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraRaycast : MonoBehaviour
{
  public PlayerMovement playerMovement;
  public LayerMask groundLayer;
  public LayerMask enemyLayer;
  public int stopingDistance;

  Ray ray;
  RaycastHit hit;

  void Start()
  {
        
  }

  // Update is called once per frame
  void Update()
  {
    if(Input.GetMouseButtonDown(0) && (!EventSystem.current.IsPointerOverGameObject()))
    {
      ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      if(Physics.Raycast(ray, out hit, 100, enemyLayer))
      {
        GoToEnemy(hit.collider.transform.position);
      }
      else if(Physics.Raycast(ray, out hit, 100, groundLayer))
      {
        GoToFloorPoint(hit.point);
      }
    }
  }
  void GoToFloorPoint(Vector3 hit)
  {
    playerMovement.posToGo = hit;
    playerMovement.Turning(hit);
  }
  void GoToEnemy(Vector3 enemyPos)
  {
    Vector3 dirEnemytoPlayer = playerMovement.transform.position - enemyPos;
    Vector3 posToGoPlayer = enemyPos + dirEnemytoPlayer.normalized * stopingDistance;
    playerMovement.attackingEnemy = true;
    playerMovement.posToGo = posToGoPlayer;
    playerMovement.Turning(hit.point);
  }
}
