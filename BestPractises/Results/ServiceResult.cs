using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;

namespace BestPractises.Results
{
    public class ServiceResult
    {
        public ProblemDetails? ProblemDetails { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Value { get; set; }
        [JsonIgnore] public HttpStatusCode Status { get; set; }

        public static ServiceResult<T> Success(T value, int statusCode)
        {
            return new ServiceResult<T>
            {
                Value = value,
                Status = HttpStatusCode.OK,
            };
        }
        public static ServiceResult<T> Fail(T value, int statusCode, string title)
        {
            return new ServiceResult<T>
            {
                Title = title,
                Value = value,
                Status = HttpStatusCode.NotFound,
            };
        }
        public static ServiceResult<T> ErrorNotfoundWithId(string id, int statusCode, string title)
        {
            return new ServiceResult<T>
            {
                ProblemDetails = new ProblemDetails
                {
                    Status = statusCode,
                    Title = title,
                    Detail = $"selected with id '{id}' items didnt found"
                }

            };
        }
        public static ServiceResult<T> ErrorPostBook(int statusCode, string title)
        {
            return new ServiceResult<T>
            {
                ProblemDetails = new ProblemDetails
                {
                    Status = statusCode,
                    Title = title,
                    Detail = $"Stock could be max 20"

                }
            };
        }
    }
}