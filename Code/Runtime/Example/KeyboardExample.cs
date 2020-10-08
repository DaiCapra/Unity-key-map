using System;
using UnityEngine;
using UnityEngine.UI;

namespace Keymap.Runtime.Example
{
    public class KeyboardExample : MonoBehaviour
    {
        [SerializeField] private Image image;

        private KeyboardDarkMap _map;

        public void Start()
        {
            _map = new KeyboardDarkMap();

            var key = KeyCode.Escape;
            if (_map.TryGet(key.ToString(), out var sprite))
            {
                image.sprite = sprite;
            }
        }

        public void Update()
        {
            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    if (_map.TryGet(key.ToString(), out var sprite))
                    {
                        image.sprite = sprite;
                    }
                }
            }
        }
    }
}