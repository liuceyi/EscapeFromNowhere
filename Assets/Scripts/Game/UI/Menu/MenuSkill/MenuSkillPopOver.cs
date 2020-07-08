using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSkillPopOver : MonoBehaviour
{
    public Text skillNameText;
    public Text skillContentText;
    // Start is called before the first frame update
    public void Init(string skillName, string skillContent)
    {
        skillNameText.text = skillName;
        skillContentText.text = skillContent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
