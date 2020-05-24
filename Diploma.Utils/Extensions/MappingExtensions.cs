using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Diploma.Utils.Extensions
{
    public static class MappingExtensions
    {
        public static T To<T>(this object from)
        {
            if (from == null)
            {
                return default(T);
            }

            return (T)Mapper.Map(from, from.GetType(), typeof(T));
        }
    }
}
