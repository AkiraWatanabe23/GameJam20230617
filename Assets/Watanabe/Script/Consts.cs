﻿using System.Collections.Generic;

namespace Constants
{
    public static class Consts
    {
        public static readonly Dictionary<SceneNames, string> Scenes = new()
        {
            [SceneNames.TITLE_SCENE] = "Title",
            [SceneNames.GAME_SCENE] = "InGame",
            [SceneNames.RESULT_SCENE] = "Result",
        };
    }

    public enum SceneNames
    {
        TITLE_SCENE,
        GAME_SCENE,
        RESULT_SCENE,
    }
}