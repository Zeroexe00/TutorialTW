using UnityEngine;

public class Hero : MonoBehaviour
{
  public Renderer[] renderers;
  public Material finalMaterial;
  public Material initMaterial;
  public enum AllyType {Hero, Lich };
  public AllyType allyType;

  private void Awake()
  {
    ChangeMaterial(initMaterial);
  }

  //cambia el material segundo el que le pasemos
  void ChangeMaterial(Material mat)
  {
    for (int i = 0; i < renderers.Length ; i++)
    {
        renderers[i].material = mat;
    }
  }

  public void ChangeToFinalMaterial()
  {
    ChangeMaterial(finalMaterial);
  }
}
