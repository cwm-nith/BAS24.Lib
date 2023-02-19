using Swashbuckle.AspNetCore.Filters;

namespace BAS24.Libs.Swagger;

public abstract class TestExample : IExamplesProvider<object>
{
    public object GetExamples()
    {
        return "";
    }
}
