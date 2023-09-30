using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONDataImporter : MonoBehaviour
{
    // Start is called before the first frame update
    public TextAsset jsonFile;
    public Stack blocks = new Stack();

    public List<Block> grade6;
    public List<Block> grade7;
    public List<Block> grade8;
    public List<Block> beyond;

    void Awake()
    {
        blocks = JsonUtility.FromJson<Stack>(jsonFile.text);

        //send to relevant stack
        for (int i = 0; i < blocks.pieces.Length; i++)
        {
            switch (blocks.pieces[i].grade)
            {
                case "6th Grade":
                    grade6.Add(blocks.pieces[i]);
                    break;
                case "7th Grade":
                    grade7.Add(blocks.pieces[i]);
                    break;
                case "8th Grade":
                    grade8.Add(blocks.pieces[i]);
                    break;
                default:
                    beyond.Add(blocks.pieces[i]);
                    break;
            }
        }

        SortGrade(grade6);
        SortGrade(grade7);
        SortGrade(grade8);
    }

    void SortGrade(List<Block> grade)
    {
        grade.Sort((x, y) => x.standardid.CompareTo(y.standardid));
        grade.Sort((x, y) => x.cluster.CompareTo(y.cluster));
        grade.Sort((x, y) => x.domain.CompareTo(y.domain));
    }
}

[System.Serializable]
public class Stack
{
    public Block[] pieces;
}
[System.Serializable]
public class Block
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
}