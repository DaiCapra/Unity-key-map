using UnityEngine;

namespace Keymap.Runtime
{
    public class KeyboardDarkMap : KeyMap
    {
        public KeyboardDarkMap()
        {
            var pathTranslation = $"{PathTranslations}/Keyboard";
            var pathSprites = $"{PathPrompts}/Keyboard & Mouse/Dark";
            
            Load(pathSprites, pathTranslation);

            AppendTranslationValues("_dark");
        }
    }
}