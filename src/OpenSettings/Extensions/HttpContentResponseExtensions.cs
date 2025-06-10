using Ogu.Response.Abstractions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OpenSettings.Models.Responses;

namespace OpenSettings.Extensions
{
    public static class HttpContentResponseExtensions
    {
        public static async Task<IResponse> ToResponseAsync(this HttpContent content, JsonSerializerOptions serializerOptions = null, CancellationToken cancellationToken = default)
        {
            var responseDto = await content.ReadFromJsonAsync<ResponseDto>(serializerOptions, cancellationToken);

            return responseDto.ToResponse();
        }

        public static async Task<IResponse<T>> ToResponseAsync<T>(this HttpContent content, JsonSerializerOptions serializerOptions = null, CancellationToken cancellationToken = default)
        {
            var responseDto = await content.ReadFromJsonAsync<ResponseDto<T>>(serializerOptions, cancellationToken);

            return responseDto.ToResponse();
        }
    }
}