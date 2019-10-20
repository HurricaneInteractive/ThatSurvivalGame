using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Villager : MonoBehaviour
{
    public GameObject villager;
    private Renderer villagerRenderer;
    private Shader outlineShader;
    private Shader defaultShader;

    // Start is called before the first frame update
    void Start()
    {
        villagerRenderer = villager.GetComponent<Renderer>();
        outlineShader = Shader.Find("Custom/OutlineShader");
        defaultShader = villagerRenderer.material.shader;
    }

    private void OnMouseOver() {
        setCustomOutlineShader();
    }

    private void OnMouseExit() {
        resetToDefaultShader();
    }

    public void setCustomOutlineShader() {
        villagerRenderer.material.shader = outlineShader;
    }

    public void resetToDefaultShader() {
        villagerRenderer.material.shader = defaultShader;
    }
}
