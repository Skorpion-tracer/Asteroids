using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids
{
    public class DictionaryAdapter : MonoBehaviour
    {
        private Dictionary<int, string> _dictionaryExample;

        [SerializeField] private int _key;
        [SerializeField] private string _value = string.Empty;

        private string GetDictionary 
        { 
            get => _dictionaryExample[_key]; 
            set
            {
                _dictionaryExample[_key] = _value;
            }
        }

        private void Start()
        {
            _dictionaryExample = new Dictionary<int, string>();
            GetDictionary = string.Empty;
            Debug.Log($"Ключ: {_key}");
            Debug.Log($"Значение {_dictionaryExample[_key]}");
        }
    }
}
