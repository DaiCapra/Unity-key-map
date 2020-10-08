using UnityEngine;

namespace Keymap.Runtime
{
    public class KeyboardMouseDarkMap : KeyMap
    {
        public KeyboardMouseDarkMap()
        {
            var pathTranslation = $"{PathTranslations}/Keyboard";
            var pathSprites = $"{PathPrompts}/Keyboard & Mouse/Dark";
            
            Load(pathSprites, pathTranslation);

            AppendTranslationValues("_dark");
        }
    }
}