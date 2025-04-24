using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace VRQuestionnaireToolkit
{
    public class StudySetup : MonoBehaviour
    {
        public string ParticipantId;
        public string Condition;

        [Tooltip("Switch on/off tactile feedback.")]
        public bool ControllerTactileFeedbackOnOff = true;
        [Tooltip("Switch on/off sound feedback.")]
        public bool SoundOnOff = true;
        [Tooltip("When checked, use + and - keys to resize the questionnaire panel.\nPress 0 to reset to default.")]
        public bool ConfigurationMode = true;
        [Tooltip("Also write the result of the current participant to a summary table which contains the results of ALL participants.")]
        public bool AlsoConsolidateResults = true;

        [Header("Customize feedback parameters on hovering:")]
        [Range(0, 1)]
        public float VibratingDurationForHovering = 0.05f;
        [Range(0, 100)]
        public float VibratingAmplitudeForHovering = 0.5f;
        [Tooltip("Choose the audio file to play upon hovering over a button.")]
        public AudioClip SoundClipForHovering;
        [Range(0.0f, 1.0f)]
        public float HoveringVolume = 1.0f;

        [Header("Customize feedback parameters on selecting:")]
        [Range(0, 1)]
        public float VibratingDurationForSelecting = 0.05f;
        [Range(0, 100)]
        public float VibratingAmplitudeForSelecting = 1.0f;
        [Tooltip("Choose the audio file to play upon selecting on a button.")]
        public AudioClip SoundClipForSelecting;
        [Range(0.0f, 1.0f)]
        public float SelectingVolume = 1.0f;

        private string _path; // file path to write the remembered transform values to

        void Start()
        {
            _path = Path.Combine(Application.dataPath, "Resources", "saved_transform_values.txt");

            if (ConfigurationMode && File.Exists(_path))
                SetTransformToSavedValues();
            else
                SetTransformToDefault();
        }

        void Update()
        {
            if (ConfigurationMode) AdjustTransform();
        }

        void OnApplicationQuit()
        {
            if (ConfigurationMode)
                SaveCurrentValues();
        }

        /// <summary>
        /// Resize the questionnaire panel by hitting keys + and -.
        /// </summary>
        void AdjustTransform()
        {
            // Press + to scale up
            if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.KeypadPlus))
                this.transform.localScale = Vector3.Scale(this.transform.localScale, new Vector3(1.1f, 1.1f, 1.0f));
            // Press - to scale down
            if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.KeypadMinus))
                this.transform.localScale = Vector3.Scale(this.transform.localScale, new Vector3(0.9f, 0.9f, 1.0f));

            // Press UpArrow to push the panel farther away
            if (Input.GetKeyDown(KeyCode.UpArrow))
                this.transform.Translate(new Vector3(0.0f, 0.0f, 0.2f));
            // Press DownArrow to bring the panel closer
            if (Input.GetKeyDown(KeyCode.DownArrow))
                this.transform.Translate(new Vector3(0.0f, 0.0f, -0.2f));

            // Press 0 to reset transform (position, rotation & scale)
            if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
                SetTransformToDefault();
        }

        /// <summary>
        /// Write a string to a file at a specified path.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="filePath"></param>
        void WriteStringToFile(string str, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(str);
            }
        }

        /// <summary>
        /// Read the content of a file as a string.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        string ReadStringFromFile(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                return sr.ReadToEnd();
            }
        }

        /// <summary>
        /// Write the current position/rotation/scale values to a .txt file under the Resources folder.
        /// </summary>
        void SaveCurrentValues()
        {
            string thingsToWrite = string.Join(",",
                transform.localPosition.x.ToString(CultureInfo.InvariantCulture),
                transform.localPosition.y.ToString(CultureInfo.InvariantCulture),
                transform.localPosition.z.ToString(CultureInfo.InvariantCulture),
                transform.localRotation.x.ToString(CultureInfo.InvariantCulture),
                transform.localRotation.y.ToString(CultureInfo.InvariantCulture),
                transform.localRotation.z.ToString(CultureInfo.InvariantCulture),
                transform.localRotation.w.ToString(CultureInfo.InvariantCulture),
                transform.localScale.x.ToString(CultureInfo.InvariantCulture),
                transform.localScale.y.ToString(CultureInfo.InvariantCulture),
                transform.localScale.z.ToString(CultureInfo.InvariantCulture)
            );

            WriteStringToFile(thingsToWrite, _path);
        }

        /// <summary>
        /// Read the saved values from the .txt file and set the transform accordingly.
        /// </summary>
        void SetTransformToSavedValues()
        {
            string[] strings = ReadStringFromFile(_path).Split(',');
            if (strings.Length == 10)
            {
                this.transform.localPosition = new Vector3(
                    float.Parse(strings[0], CultureInfo.InvariantCulture),
                    float.Parse(strings[1], CultureInfo.InvariantCulture),
                    float.Parse(strings[2], CultureInfo.InvariantCulture)
                );
                this.transform.localRotation = new Quaternion(
                    float.Parse(strings[3], CultureInfo.InvariantCulture),
                    float.Parse(strings[4], CultureInfo.InvariantCulture),
                    float.Parse(strings[5], CultureInfo.InvariantCulture),
                    float.Parse(strings[6], CultureInfo.InvariantCulture)
                );
                this.transform.localScale = new Vector3(
                    float.Parse(strings[7], CultureInfo.InvariantCulture),
                    float.Parse(strings[8], CultureInfo.InvariantCulture),
                    float.Parse(strings[9], CultureInfo.InvariantCulture)
                );
            }
            else
            {
                Debug.LogWarning("Saved transform values are corrupted or incomplete.");
                SetTransformToDefault();
            }
        }

        /// <summary>
        /// Set the questionnaire panel to its default position, rotation and scale.
        /// </summary>
        void SetTransformToDefault()
        {
            this.transform.localPosition = new Vector3(0.0f, 1.0f, 6.0f);
            this.transform.localRotation = Quaternion.identity;
            this.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        }
    }
}
