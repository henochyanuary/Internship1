using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class RoundData  {

    public string name;
    public int timeLimit;
    public int pointsAddedForCorrectAnswer;
    public QuestionData[] questions;
}
