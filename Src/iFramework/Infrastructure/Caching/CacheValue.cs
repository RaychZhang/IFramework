﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFramework.Infrastructure.Caching
{

    public class CacheValue<T>
    {
        public CacheValue(T value, bool hasValue)
        {
            Value = value;
            HasValue = hasValue;
        }

        public bool HasValue { get; }
        public bool IsNull => Value == null;
        public T Value { get; }
        public static CacheValue<T> Null => new CacheValue<T>(default(T), true);
        public static CacheValue<T> NoValue => new CacheValue<T>(default(T), false);
    }
}
