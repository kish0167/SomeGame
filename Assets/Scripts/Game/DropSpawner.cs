using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Game
{
    public class DropSpawner : MonoBehaviour
    {
        #region Variables

        [SerializeField] private List<PickUpAndProbability> _pickUpsVariants;

        #endregion

        #region Private methods

        private Drop GetRandomDrop()
        {
            float sum = 0f;

            foreach (PickUpAndProbability p in _pickUpsVariants)
            {
                sum += p.probability;
            }

            float cumulative = 0f;
            float randomValue = Random.Range(0f, sum);

            foreach (PickUpAndProbability pickup in _pickUpsVariants)
            {
                cumulative += pickup.probability;
                if (randomValue < cumulative)
                {
                    return pickup.dropPrefab;
                }
            }

            return null;
        }

        private Vector3 GetRandomPos()
        {
            float randomShiftX = gameObject.transform.lossyScale.x;
            randomShiftX = Random.Range(-randomShiftX / 2, randomShiftX / 2);
            Vector3 vector3 = gameObject.transform.position;
            vector3.x += randomShiftX;
            return vector3;
        }
    
        [Button]
        private void SpawnDrop()
        {
            Drop dropPrefab = GetRandomDrop();
            Instantiate(dropPrefab, GetRandomPos(), quaternion.identity);
        }

        #endregion

        #region Local data

        [Serializable] private struct PickUpAndProbability
        {
            #region Variables

            [SerializeField] public Drop dropPrefab;
            [Header("relative probability, not actual percentage")]
            [Range(0f, 100f)]
            [SerializeField] public float probability;

            #endregion
        }

        #endregion
    }
}