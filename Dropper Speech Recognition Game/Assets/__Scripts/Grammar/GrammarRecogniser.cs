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
    [SerializeField] private Text DisplayText;
    private const string GRAMMAR_XML_FILE = "GameGrammar.xml";

    // Grammar Recogniser
    GrammarRecognizer gr;

    private void Start()
    {
        // Read the grammar file and listen for any words
        gr = new GrammarRecognizer(
                Path.Combine(Application.streamingAssetsPath, GRAMMAR_XML_FILE),
                ConfidenceLevel.Low);

        // print("[!] Grammar has loaded " + gr.GrammarFilePath + "."); // Used for testing

        gr.OnPhraseRecognized += GR_OnPhrasesRecognised;

        // Start the grammar recogniser
        gr.Start();

        // Inform if grammar recogniser is running
        if (gr.IsRunning) print("[!] GR is running.");
    }

    private void GR_OnPhrasesRecognised(PhraseRecognizedEventArgs args)
    {
        // print("[!] Recognised some grammar."); // Used for testing

        // An empty message string
        string message = "";

        // Read the semantic meanings from the args returned
        SemanticMeaning[] meanings = args.semanticMeanings;

        // Return a set of name/value pairs - keys/values
        foreach (SemanticMeaning meaning in meanings)
        {
            // Set key
            string keyString = meaning.key.Trim();

            // Set value
            string valueString = meaning.values[0].Trim();

            // Set message
            message = "Your command was: " + valueString;

            // Call the Move method from PlayerBehvaviour passing the valueString
            GameManager.Listen(valueString);
        }

        DisplayText.text = message.ToString();
        // print("Text Message: " + message); // Used for testing
    }

    private void OnApplicationQuit()
    {
        if (gr != null && gr.IsRunning)
        {
            gr.OnPhraseRecognized -= GR_OnPhrasesRecognised;

            // Inform of Grammar Recogniser being stopped
            print("[!] GR has stopped.");

            // Stop the grammar recogniser
            gr.Stop();
        }
    }
} // Class - END