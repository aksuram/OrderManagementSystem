using System.Text.Json;

namespace OrderManagementSystem.Application.Common.Models
{
    public class Result<T> where T : class
    {
        public ResultType Type { get; set; }
        public ResultErrors Errors { get; set; }
        public T? Value { get; set; }

        private Result(ResultType type, IEnumerable<FieldError>? errors, T? value)
        {
            Type = type;
            Errors = new ResultErrors(errors?.ToList());
            Value = value;
        }

        public ResultErrors? GetErrors()
        {
            return Errors.Errors == null ? null : Errors;
        }

        //Success
        public static Result<T> Success(T value)
        {
            return new Result<T>(ResultType.Success, null, value);
        }

        //NotFound
        public static Result<T> NotFound(IEnumerable<FieldError> errors)
        {
            return new Result<T>(ResultType.NotFound, errors, null);
        }

        public static Result<T> NotFound(string field, string error)
        {
            return NotFound(new List<FieldError> { new FieldError(field, error) });
        }

        //BadData
        public static Result<T> BadData()
        {
            return new Result<T>(ResultType.BadData, null, null);
        }

        public static Result<T> BadData(IEnumerable<FieldError> errors)
        {
            return new Result<T>(ResultType.BadData, errors, null);
        }

        public static Result<T> BadData(string field, string error)
        {
            return BadData(new List<FieldError> { new FieldError(field, error) });
        }
    }

    public class Result
    {
        public ResultType Type { get; set; }
        public ResultErrors Errors { get; set; }

        private Result(ResultType type, IEnumerable<FieldError>? errors)
        {
            Type = type;
            Errors = new ResultErrors(errors?.ToList());
        }

        public ResultErrors? GetErrors()
        {
            return Errors.Errors == null ? null : Errors;
        }

        //Success
        public static Result Success()
        {
            return new Result(ResultType.Success, null); ;
        }

        //NotFound
        public static Result NotFound(IEnumerable<FieldError> errors)
        {
            return new Result(ResultType.NotFound, errors);
        }

        public static Result NotFound(string field, string error)
        {
            return NotFound(new List<FieldError> { new FieldError(field, error) });
        }

        //BadData
        public static Result BadData()
        {
            return new Result(ResultType.BadData, null);
        }

        public static Result BadData(IEnumerable<FieldError> errors)
        {
            return new Result(ResultType.BadData, errors);
        }

        public static Result BadData(string field, string error)
        {
            return BadData(new List<FieldError> { new FieldError(field, error) });
        }
    }

    public class FieldError
    {
        public string Field { get; set; }
        public string Error { get; set; }

        public FieldError(string field, string error)
        {
            Field = JsonNamingPolicy.CamelCase.ConvertName(field);
            Error = error;
        }
    }

    public class ResultErrors
    {
        public List<FieldError>? Errors { get; set; }

        public ResultErrors(List<FieldError>? errors)
        {
            Errors = errors;
        }
    }
}
