using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceData : MonoBehaviour
{
    public int id;
    public string subject;
    public string grade;
    public int mastery;
    public string domainid;
    public string domain;
    public string cluster;
    public string standardid;
    public string standarddescription;
    public MeshRenderer _renderer;
    private Color startcolor;
    UIManager uiManager;

    string gradeDomainText;
    string idDescriptionText;

    private void Start()
    {
        _renderer = GetComponent<MeshRenderer>();
        uiManager = FindObjectOfType<UIManager>();

        gradeDomainText = grade + " : " + domain;
        idDescriptionText = standardid + " : " + standarddescription;

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
            uiManager.SetDescriptionPanel(gradeDomainText, cluster, idDescriptionText);
            uiManager.ShowDescriptionPanel();
        }
    }
}
