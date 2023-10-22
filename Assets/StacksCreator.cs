using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StacksCreator : MonoBehaviour
{
    public GameObject glassPiecePrefab;
    public GameObject woodPiecePrefab;
    public GameObject stonePiecePrefab;

    public JSONDataImporter data;

    public GameObject stack1;
    public GameObject stack2;
    public GameObject stack3;
    
    
    private void Start()
    {
        CreateStack(data.grade6, stack1);
        CreateStack(data.grade7, stack2);
        CreateStack(data.grade8, stack3);
    }

    void CreateStack(List<Block> grade, GameObject stack)
    {
        for (int i = 0; i < grade.Count; i++)
        {
            float offsetY = Mathf.FloorToInt(i / 3);
            float offsetX = Mathf.FloorToInt(i % 3);

            Vector3 pos;
            Quaternion spawnRotation;

            GameObject newPiece;
            //Adjusts position and rotation according to stack level and piece count
            if (offsetY % 2 == 0)
            {
                spawnRotation = Quaternion.identity;
                pos = new Vector3(offsetX, offsetY);
            }
            else
            {
                spawnRotation = Quaternion.Euler(0, 90, 0);
                pos = new Vector3(1, offsetY, offsetX-1);
            }

            //Adjusts which prefab to instantiate, because it's more costly to change material on runtime
            //instead of instantiating the correct prefab from the start
            if (grade[i].mastery == 0)
            {
                newPiece = Instantiate(glassPiecePrefab, stack.transform.position + pos, spawnRotation, stack.transform);
            }
            else if (grade[i].mastery == 1)
            {
                newPiece = Instantiate(woodPiecePrefab, stack.transform.position + pos, spawnRotation, stack.transform);
            }
            else
            {
                newPiece = Instantiate(stonePiecePrefab, stack.transform.position + pos, spawnRotation, stack.transform);
            }

            //Sets new piece data
            SetPieceData(grade[i], newPiece.GetComponent<PieceData>());
        }
    }
    void SetPieceData(Block piece, PieceData newPieceData)
    {
        newPieceData.blockData.id = piece.id;
        newPieceData.blockData.subject = piece.subject;
        newPieceData.blockData.grade = piece.grade;
        newPieceData.blockData.mastery = piece.mastery;
        newPieceData.blockData.domainid = piece.domainid;
        newPieceData.blockData.domain = piece.domain;
        newPieceData.blockData.cluster = piece.cluster;
        newPieceData.blockData.standardid = piece.standardid;
        newPieceData.blockData.standarddescription = piece.standarddescription;
    }
}
    
