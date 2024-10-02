using UnityEngine;
using WaterSystem;
using Unity.Mathematics;
using System.Collections;
using System.Collections.Generic;

namespace BoatAttack
{
    /// <summary>
    /// This controls the logic for the wind surfer
    /// </summary>
    public class WindsurferLogic : MonoBehaviour
    {
        private float3[] points = new float3[1]; // Points to sample wave height
        private float3[] heights = new float3[1]; // Height sample from water system
        private float3[] waveNormals = new float3[1]; // Normal of the wave
        private Vector3 smoothPosition; // The smoothed position
        private int _guid; // The object's GUID for wave height lookup

        // Use this for initialization
        void Start()
        {
            _guid = gameObject.GetInstanceID();
            smoothPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            // Set current position to sample wave height
            points[0] = transform.position;

           

            // Ambil data termasuk heights dan normals, gunakan 'ref' hanya untuk heights dan waveNormals
            GerstnerWavesJobs.GetData(_guid, ref heights, ref waveNormals); // Tiga argumen dengan 'ref' hanya untuk heights dan waveNormals

            // Smoothly move the windsurfer to match the wave height
            smoothPosition = transform.position;
            smoothPosition.y = Mathf.Lerp(smoothPosition.y, heights[0].y, Time.deltaTime * 2.0f); // Adjust smoothing speed

            transform.position = smoothPosition;
        }
    }
}
