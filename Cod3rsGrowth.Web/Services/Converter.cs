﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cod3rsGrowth.Web.MetodosAuxiliares
{
    public class Converter<T> : JsonConverter<T> where T : Enum
    {
        public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            int value = reader.GetInt32();
            return (T?)Enum.ToObject(typeof(T), value);
        }

        public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(DescricaoEnum.PegarDescricaoEnum(value));
        }
    }
}
