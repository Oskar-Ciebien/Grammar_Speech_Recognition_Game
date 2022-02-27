using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class GrammarRecogniser : MonoBehaviour
{
    // === Private Fields ===
    private const string GRAMMAR_XML_FILE = "GameGrammar.xml";
    [SerializeField] private Text DisplayText;

    GrammarRecognizer gr;

    private void Start()
    {
        // Read the grammar file and listen for any words
        gr = new GrammarRecognizer(
                Path.Combine(Application.streamingAssetsPath, GRAMMAR_XML_FILE),
                ConfidenceLevel.Low);

        Debug.Log("[!] Grammar has loaded " + gr.GrammarFilePath + ".");

        gr.OnPhraseRecognized += GR_OnPhrasesRecognised;

        gr.Start();

        if (gr.IsRunning) Debug.Log("[!] GR is running.");
    }

    private void GR_OnPhrasesRecognised(PhraseRecognizedEventArgs args)
    {
        Debug.Log("[!] Recognised some grammar.");

        // Read the semantic meanings from the args returned
        // Put them in a string to print a message in the console
        string message = "";
        SemanticMeaning[] meanings = args.semanticMeanings;

        // Return a set of name/value pairs - keys/values
        foreach (SemanticMeaning meaning in meanings)
        {
            string keyString = meaning.key.Trim();
            string valueString = meaning.values[0].Trim();

            message = "Key: " + keyString + ", Value: " + valueString;

            // Call the Move method from PlayerBehvaviour passing the valueString
            GameManager.Listen(valueString);
        }

        DisplayText.text = message.ToString();
        Debug.Log("Text Message: " + message);
    }

    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhrasesRecognised;

            Debug.Log("[!] GR has stopped.");
            gr.Stop();
        }
    }
}