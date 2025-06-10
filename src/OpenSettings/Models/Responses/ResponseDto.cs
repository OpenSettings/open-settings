using Ogu.Response;
using Ogu.Response.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json.Serialization;

namespace OpenSettings.Models.Responses
{
    public class ResponseDto : ResponseDto<object>
    {
    }

    public class ResponseDto<T>
    {
        public bool Success { get; set; }

        public HttpStatusCode Status { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T Data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ErrorDto[] Errors { get; set; } = Array.Empty<ErrorDto>();

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Dictionary<string, object> Extras { get; set; } = new Dictionary<string, object>();
    }

    public class ErrorDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Title { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Description { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Traces { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Code { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string HelpLink { get; set; }

        public ErrorType Type { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public ValidationFailureDto[] ValidationFailures { get; set; } = Array.Empty<ValidationFailureDto>();
    }

    public class ValidationFailureDto
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string PropertyName { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Message { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public object AttemptedValue { get; set; }

        public Severity Severity { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Code { get; set; }
    }

    public static class DtoExtensions
    {
        public static IResponse ToResponse(this ResponseDto responseDto)
        {
            return new Response(responseDto.Data, responseDto.Success, responseDto.Status, responseDto.Extras,
                responseDto.Errors?.Select(e => (IError)e.ToError()).ToList());
        }

        public static IResponse<TData> ToResponse<TData>(this ResponseDto<TData> responseDto)
        {
            return new Response<TData>(responseDto.Data, responseDto.Success, responseDto.Status, responseDto.Extras,
                responseDto.Errors?.Select(e => (IError)e.ToError()).ToList());
        }

        public static IResponse<TData> ToResponseOf<TData>(this ResponseDto responseDto)
        {
            TData data;

            switch (responseDto.Data)
            {
                case null:
                    data = default(TData);
                    break;
                case TData tData:
                    data = tData;
                    break;
                default:
                    data = (TData)Convert.ChangeType(responseDto.Data, typeof(TData));
                    break;
            }

            return new Response<TData>(data, responseDto.Success, responseDto.Status, responseDto.Extras, responseDto.Errors?.Select(e => (IError)e.ToError()).ToList());
        }

        //public static IActionResult ToActionDto(this ModelStateDictionary modelState)
        //{
        //    return modelState.ToResponse().ToActionDto();
        //}

        //public static IActionResult ToActionDto<T>(this ModelStateDictionary modelState)
        //{
        //    return modelState.ToResponse().ToActionDto();
        //}

        //public static IActionResult ToAction(this ResponseDto responseDto)
        //{
        //    return InternalToAction((int)responseDto.Status, responseDto);
        //}

        //public static IActionResult ToAction<T>(this ResponseDto<T> responseDto)
        //{
        //    return InternalToAction((int)responseDto.Status, responseDto);
        //}

        //private static IActionResult InternalToAction(int statusCode, object response)
        //{
        //    return ResponseDefaults.NoResponseStatusCodes.Contains(statusCode)
        //        ? (IActionResult)new StatusCodeResult(statusCode)
        //        : new ObjectResult(response);
        //}

        //public static IActionResult ToActionDto(this IResponse response)
        //{
        //    var responseDto = new ResponseDto
        //    {
        //        Success = response.Success,
        //        Status = response.Status,
        //        Data = response.Data,
        //        Errors = response.Errors.Count == 0
        //            ? null
        //            : response.Errors.Select(e => e.ToErrorDto()).ToArray(),
        //        Extras = response.Extras.Count == 0 ? null : response.Extras as Dictionary<string, object> ?? response.Extras.ToDictionary(e => e.Key, e => e.Value)
        //    };

        //    return responseDto.ToAction();
        //}

        //public static IActionResult ToActionDto<T>(this IResponse<T> response)
        //{
        //    var responseDto = new ResponseDto<T>
        //    {
        //        Success = response.Success,
        //        Status = response.Status,
        //        Data = response.Data,
        //        Errors = response.Errors.Count == 0
        //            ? null
        //            : response.Errors.Select(e => e.ToErrorDto()).ToArray(),
        //        Extras = response.Extras.Count == 0 ? null : response.Extras as Dictionary<string, object> ?? response.Extras.ToDictionary(e => e.Key, e => e.Value)
        //    };

        //    return responseDto.ToAction();
        //}

        private static Error ToError(this ErrorDto errorDto)
        {
            return new Error(errorDto.Title, errorDto.Description, errorDto.Traces, errorDto.Code, errorDto.HelpLink,
                errorDto.ValidationFailures?.Select(vf => (IValidationFailure)vf.ToValidationFailure()).ToList(), errorDto.Type);
        }

        private static ValidationFailure ToValidationFailure(this ValidationFailureDto vfDto)
        {
            return new ValidationFailure(vfDto.PropertyName, vfDto.Message, vfDto.AttemptedValue,
                vfDto.Severity, vfDto.Code);
        }

        private static ErrorDto ToErrorDto(this IError error)
        {
            return new ErrorDto
            {
                Title = error.Title,
                Description = error.Description,
                Traces = error.Traces,
                Code = error.Code,
                HelpLink = error.HelpLink,
                Type = error.Type,
                ValidationFailures = error.ValidationFailures.Count == 0
                    ? null
                    : error.ValidationFailures.Select(vf => vf.ToValidationFailureDto()).ToArray()
            };
        }

        private static ValidationFailureDto ToValidationFailureDto(this IValidationFailure vf)
        {
            return new ValidationFailureDto
            {
                PropertyName = vf.PropertyName,
                Message = vf.Message,
                AttemptedValue = vf.AttemptedValue,
                Severity = vf.Severity,
                Code = vf.Code
            };
        }
    }

}