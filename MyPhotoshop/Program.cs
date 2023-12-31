﻿/*
 * Para usar este código debes instalar "imagesharp"
 * https://docs.sixlabors.com/articles/imagesharp/index.html
 * Instalar esta librería es realmente fácil. Yo usé NuGet que aparece en la barra
 * de abajo en Rider. Luego busqué la librería "SixLabors.ImageSharp" y puse instalar.
 */

using MyPhotoshop;
using MyPhotoshop.Effects;

IPhotoEffect[] availableEffects = new IPhotoEffect[] { new BlackAndWhiteEffect(), new Darken(), new Lighten(), new Rotate(), new Reflect(), new Blur(), new ShowBorders()};
string folder = "imgs";
Controller.Run(folder, availableEffects);