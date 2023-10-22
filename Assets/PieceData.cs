using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceData : MonoBehaviour
{
    public Block blockData;
    public MeshRenderer _renderer;
    private Color startcolor;
    UIManager uiManager;

    string gradeDomainText;
    string idDescriptionText;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        uiManager = FindObjectOfType<UIManager>();

        gradeDomainText = blockData.grade + " : " + blockData.domain;
        idDescriptionText = blockData.standardid + " : " + blockData.standarddescription;

    }

    void OnMouseEnter()
    {
        startcolor = _renderer.material.color;
        _renderer.material.color = Color.magenta;
    }
    void OnMouseExit()
    {
        _renderer.material.color = startcolor;
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            uiManager.SetDescriptionPanel(gradeDomainText, blockData.cluster, idDescriptionText);
            uiManager.ShowDescriptionPanel();
        }
    }
}
