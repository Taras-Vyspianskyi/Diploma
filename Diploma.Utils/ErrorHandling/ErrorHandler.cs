using Diploma.Interfaces.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Diploma.Utils.ErrorHandling
{
    public static class ErrorHandler
    {
        public static async Task<T> HandleRequestAsync<T>(Func<Task<T>> resultFunc)
            where T : BaseResponseDto, new()
        {
            T result = default;

            try
            {
                result = await resultFunc();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                result.SetErrorMessage(ex.Message);
            }

            return await Task.FromResult(result);
        }
    }
}
