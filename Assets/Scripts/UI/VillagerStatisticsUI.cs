using UnityEngine;

[RequireComponent(typeof(CanvasRenderer))]
public class VillagerStatisticsUI : MonoBehaviour {
  private CanvasRenderer render;
  private GameObject selectedVillager;
  private Villager villagerScript;

  private void Start() {
    render = gameObject.GetComponent<CanvasRenderer>();
    render.gameObject.SetActive(false);
  }

  private void Update() {
    if (selectedVillager && villagerScript) {
      Renderer render = villagerScript.villager.GetComponent<Renderer>();
      if (render.material.shader.name != "Custom/OutlineShader") {
        villagerScript.setCustomOutlineShader();
      }
    }
  }

  public void OpenStatistics(GameObject villager) {
    selectedVillager = villager;
    villagerScript = new ObjectScript<Villager>(villager).script;
    villagerScript.setCustomOutlineShader();

    render.gameObject.SetActive(true);
  }

  public void CloseStatistics() {
    villagerScript.resetToDefaultShader();
    render.gameObject.SetActive(false);
  }
}
