using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[Serializable] public class StringEvent : UnityEvent<string> {}
[Serializable] public class ImageEvent : UnityEvent<Image> {}

[Serializable] public class TextEvent : UnityEvent<Text> {}
[Serializable] public class NestedEvent : UnityEvent<UnityEvent> {}

[Serializable] public class TextureEvent : UnityEvent<Texture2D> {}