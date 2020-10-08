using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Keymap.Runtime
{
    public class KeyMap
    {
        protected const string PathPrompts = "Prompts";
        protected const string PathTranslations = "PromptTranslations";

        private readonly Dictionary<string, Sprite> _spriteMap;
        private readonly Dictionary<string, string> _translationMap;

        public KeyMap()
        {
            _spriteMap = new Dictionary<string, Sprite>();
            _translationMap = new Dictionary<string, string>();
        }

        public void Load(string pathSprites, string pathTranslation)
        {
            LoadSprites(pathSprites);
            LoadTranslation(pathTranslation);
        }


        public bool TryGet(string name, out Sprite sprite)
        {
            sprite = null;
            var n = name.ToLower();

            if (_translationMap.ContainsKey(n))
            {
                var spriteName = _translationMap[n];
                if (_spriteMap.ContainsKey(spriteName))
                {
                    sprite = _spriteMap[spriteName];
                    return true;
                }
            }

            return false;
        }


        protected void AppendTranslationValues(string append)
        {
            var modified = _translationMap
                .Select(kv => new KeyValuePair<string, string>(kv.Key, $"{kv.Value}{append}"))
                .ToArray();

            foreach (var kv in modified)
            {
                _translationMap[kv.Key] = kv.Value;
            }
        }

        private void LoadTranslation(string path)
        {
            var textAsset = Resources.Load(path) as TextAsset;
            if (textAsset == null)
            {
                return;
            }

            try
            {
                var map = JsonConvert.DeserializeObject<Dictionary<string, string>>(textAsset.text);
                foreach (var kv in map)
                {
                    var key = kv.Key.ToLower();
                    var value = kv.Value.ToLower();

                    if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(value))
                    {
                        continue;
                    }

                    if (!_translationMap.ContainsKey(key))
                    {
                        _translationMap.Add(key, value);
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return;
            }
        }

        private void LoadSprites(string path)
        {
            var sprites = Resources.LoadAll<Sprite>(path);
            foreach (var s in sprites)
            {
                var name = s.name.ToLower();
                if (!_spriteMap.ContainsKey(name))
                {
                    _spriteMap.Add(name, s);
                }
            }
        }
    }
}