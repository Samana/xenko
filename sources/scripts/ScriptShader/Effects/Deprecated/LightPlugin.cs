﻿// Copyright (c) 2011 Silicon Studio

using SiliconStudio.Paradox.Rendering;

namespace SiliconStudio.Paradox.Rendering
{
    public class LightPlugin : EffectPlugin
    {
        public override void SetupPasses(EffectMesh effectMesh)
        {
            Effect.Parameters.RegisterParameter(LightKeys.LightColor);
            Effect.Parameters.RegisterParameter(LightKeys.LightPosition);
            Effect.Parameters.RegisterParameter(LightKeys.LightIntensity);
            Effect.Parameters.RegisterParameter(LightKeys.LightRadius);
        }
    }
}
