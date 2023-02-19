using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BAS24.Libs.Json;

public static class Extensions
{
    public static IMvcBuilder AddDefaultJsonOptions(this IMvcBuilder builder)
    {
        builder.AddNewtonsoftJson(o =>
        {
            o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            o.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            o.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
            o.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
            o.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            o.SerializerSettings.Formatting = Formatting.Indented;
            o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        });

        builder.Services.AddSingleton(s => s.GetRequiredService<IOptionsMonitor<MvcNewtonsoftJsonOptions>>().CurrentValue.SerializerSettings); ;
        return builder;

    }
}