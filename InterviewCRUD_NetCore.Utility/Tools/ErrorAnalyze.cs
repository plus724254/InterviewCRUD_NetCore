using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace InterviewCRUD_NetCore.Tools
{
    public static class ErrorAnalyze
    {
        public static string GetModelStateError(ModelStateDictionary modelState)
        {
            return string.Join(",", modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList());
        }
    }
}