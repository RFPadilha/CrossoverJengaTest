using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject mainCamera;
    public StacksCreator stacksCreator;
    CameraControl cam;
    public GameObject descriptionPanel;
    public TextMeshProUGUI gradeDomain;
    public TextMeshProUGUI cluster;
    public TextMeshProUGUI idDescription;


    private void Awake()
    {
        Physics.gravity = Vector3.zero;
        cam = mainCamera.GetComponent<CameraControl>();
    }
    public void SelectStack(int stack)
    {
        if (stack == 0)
        {
            cam.FocusOnStack(stacksCreator.stack1);
        }else if (stack == 1)
        {
            cam.FocusOnStack(stacksCreator.stack2);
        }
        else cam.FocusOnStack(stacksCreator.stack3);
    }
    public void TestStack()
    {
        List<Transform> toDestroy = new List<Transform>();
        Physics.gravity = new Vector3(0, -9.81f, 0);
        foreach (Transform child in cam.focusedStack.transform)
        {
            if (child.GetComponent<PieceData>().mastery==0)
            {
                toDestroy.Add(child);
            }
        }
        for (int i = 0; i < toDestroy.Count; i++)
        {
            Destroy(toDestroy[i].gameObject);
        }
    }
    public void ShowDescriptionPanel()
    {
        descriptionPanel.SetActive(true);
    }
    public void SetDescriptionPanel(string gradeDomainText, string clusterText, string idDescriptionText)
    {
        gradeDomain.text = gradeDomainText;
        cluster.text = clusterText;
        idDescription.text = idDescriptionText;
    }
}
