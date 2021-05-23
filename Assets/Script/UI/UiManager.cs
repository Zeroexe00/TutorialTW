using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{
  public RectTransform panelAlly;
  public RaycastCharacter raycastCharacter;
  public float CooldownRespawnTime = 0.5f;

  [Header("Allies availables")]
  public int numHero = 2;
  public int numLich = 2;
  public TextMeshProUGUI textAllyAvailableHero;
  public TextMeshProUGUI textAllyAvailableLich;
  public Image imageHero;
  public Image imageLich;

  [Header("Slot Manager")]
  public Color colorAvailable;
  public Color colorUnavailable;
  public Image[] slotsHero;
  public Image[] slotsLich;

  GameObject currentObject;
  
  int direction = 1;
  private void Awake()
  {
        
  }
  private void Start()
  {
    ResetSlots(slotsHero);
    ResetSlots(slotsLich);
    textAllyAvailableHero.text = "x " + numHero.ToString();
    textAllyAvailableLich.text = "x " + numLich.ToString();
  }
  private void Update()
  {
    if(Input.GetKeyDown(KeyCode.Tab))
    {
        direction = direction * -1;
        panelAlly.DOAnchorPosX(direction * 120, 2).SetEase(Ease.OutCubic);
    }
  }
  public void SelectCharacter(string character)
  {
    switch (character)
    {
      case "Hero":
        AddSlotToAlly(slotsHero, ref numHero, textAllyAvailableHero,imageHero);
        break;
      case "Lich":
        AddSlotToAlly(slotsLich, ref numLich, textAllyAvailableLich,imageLich);
        break;
      default:
        break;
    }
  }
  public void AddSlotToAlly(Image[] slots ,ref int n ,TextMeshProUGUI _text,Image img)
  {
    int i;
    for (i = 0; i < slots.Length; i++)
    {
      if (slots[i].color == colorAvailable)
        break;
    }
    if(i == slots.Length - 1)
    {
      n++;
      StartCoroutine("fillAmount", img);
      _text.text = "x " + n.ToString();
      ResetSlots(slots);
    }
    else
    {
      slots[i].color = colorUnavailable;
    }

  }
  public void CreateAllyCharacter(GameObject character)
  {

    currentObject = Instantiate(character) as GameObject;
    raycastCharacter.currentObject = currentObject;
    raycastCharacter.objectToPlace = true;

  }
  public void WaitForNextAlly(GameObject _button)
  {
    _button.GetComponent<Button>().interactable = false;
    _button.GetComponent<Image>().fillAmount = 0;
    if(CheckAllies() != 0)
    {
      StartCoroutine("fillAmount", _button.GetComponent<Image>());
    }
  }
  //corrutina para llevar la imagen de nuevo con el paso del tiempo
  IEnumerator fillAmount(Image img)
  {
    while(img.fillAmount < 1)
    {
      img.fillAmount += CooldownRespawnTime * Time.deltaTime;
      yield return null;
    }
     img.GetComponent<Button>().interactable = true;
  }
  int CheckAllies()
  {
    int n;
    switch (currentObject.GetComponent<Hero>().allyType)
    {
      case Hero.AllyType.Hero:
        numHero--;
        textAllyAvailableHero.text = "x " + numHero.ToString();
        n = numHero;
        break;
      case Hero.AllyType.Lich:
        numLich--;
        textAllyAvailableLich.text = "x " + numLich.ToString();
        n = numLich;
        break;
      default:
        n = 0;
        break;
    }
    return n;
  }
  void ResetSlots(Image[] slots)
  {
    for (int i = 0; i < slots.Length; i++)
    {
      slots[i].color = colorAvailable;
    }
  }
}
