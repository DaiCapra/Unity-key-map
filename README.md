# Unity key map
Maps unity keycodes to key prompts.

Example:
```csharp
    var map = new KeyboardDarkMap();

    var key = Keycode.Escape;
    map.TryGet(key.ToString(), out Sprite sprite);
```
returns
![Key](image.png)

## Limitations
Only translation for keyboard exist and it is missing a few key images.