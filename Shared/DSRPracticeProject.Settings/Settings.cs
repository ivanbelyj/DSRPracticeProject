﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSRPracticeProject.Settings
{
    public abstract class Settings
    {
        public static T? Load<T>(string key,
            IConfiguration? configuration = null)
        {
            T? settings = (T?)Activator.CreateInstance(typeof(T));
            SettingsFactory.Create(configuration)
                .GetSection(key)
                .Bind(settings, x => x.BindNonPublicProperties = true);
            return settings;
        }
    }
}


