using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.IO;
using System.Text;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script is used to recognise the speech
public class GrammarRecogniser : MonoBehaviour
{
    const string SIMPLE_G = "Grammar.xml";
    [SerializeField] private Text DisplayText;
    private string speech;
    GrammarRecognizer gr;

    private void Start()
    {
        // Read the grammar and listen
        gr = new GrammarRecognizer(
                Path.Combine(Application.streamingAssetsPath, SIMPLE_G),
                //TIC_G),
                ConfidenceLevel.Low);

        Debug.Log("Grammar is loaded " + gr.GrammarFilePath);
        gr.OnPhraseRecognized += GR_OnPhrasesRecognised;
        gr.Start();
        if (gr.IsRunning) Debug.Log("GR is running.");
    }

    private void GR_OnPhrasesRecognised(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Recognised Something...");
        // Read the semantic meanings from the args returned
        // Put them in a string to print a message in the console
        StringBuilder message = new StringBuilder();

        SemanticMeaning[] meanings = args.semanticMeanings;

        // Returned a set of name/value pairs - keys/values
        foreach (SemanticMeaning meaning in meanings)
        {
            string keyString = meaning.key.Trim();
            string valueString = meaning.values[0].Trim();

            message.Append("Key: " + keyString + ", Value: " + valueString +
                    System.Environment.NewLine);

            speech = valueString;
        }

        DisplayText.text = message.ToString();
        Debug.Log(message);
        WordAction(speech);
        
    }

    private void WordAction(string speech)
    {
        switch(speech)
        {
            case "start":
                if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("MainMenu")) 
                {
                    FindObjectOfType<LevelSceneController>().Start_Game();
                }
                break;
            case "instructions":
                if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("MainMenu")) 
                {
                    FindObjectOfType<LevelSceneController>().Show_Instructions();
                }
                break;
            case "exit":
                if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("MainMenu")) 
                {
                    FindObjectOfType<LevelSceneController>().Quit_Game();
                }
                break;
            case "back":
                if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName ("MainMenu")) 
                {
                    FindObjectOfType<LevelSceneController>().Show_Menu();
                }
                break;
            case "pause":
                FindObjectOfType<SceneController>().Pause_Game();
                break;
            case "resume":
                FindObjectOfType<SceneController>().Resume_Game();
                break;
            case "mainmenu":
                FindObjectOfType<SceneController>().Main_Menu();
                break;
             case "restart":
                FindObjectOfType<SceneController>().Restart_Game();
                break;
            default:
                break;
        }
    }

    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhrasesRecognised;

            Debug.Log("GR has stopped.");
            gr.Stop();
        }
    }
}