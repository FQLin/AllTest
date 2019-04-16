using System;
using System.Collections.Generic;
using System.Diagnostics;
using FluentValidation.Resources;

namespace FulentGlobalSite.FluentValidation
{
    internal abstract class LanguageResources: LanguageManager
    {
        /// <summary>
        /// Name of language (culture code)
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Adds a translation for a type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        public void Translate<T>(string message)
        {
            AddTranslation(Name,typeof(T).Name, message);
        }
    }
}