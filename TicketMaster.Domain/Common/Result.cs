using System.Collections.Generic;

namespace TicketMaster.Domain.Common
{
    public class Result
    {
        public bool IsSuccess { get; protected set; }
        public bool IsFailure => !IsSuccess;
        public string Error { get; protected set; }
        protected List<string> _errors;
        public IReadOnlyList<string> Errors => _errors.AsReadOnly();

        protected Result()
        {
            IsSuccess = true;
            _errors = new List<string>();
        }

        protected Result(string error)
        {
            IsSuccess = false;
            Error = error;
            _errors = new List<string> { error };
        }

        protected Result(List<string> errors)
        {
            IsSuccess = false;
            Error = string.Join(", ", errors);
            _errors = errors;
        }

        public static Result Success()
        {
            return new Result();
        }

        public static Result Failure(string error)
        {
            return new Result(error);
        }

        public static Result Failure(List<string> errors)
        {
            return new Result(errors);
        }
    }

    public class Result<T> : Result
    {
        private readonly T _value;
        public T Value
        {
            get
            {
                if (IsFailure)
                    throw new InvalidOperationException("Cannot access Value when Result is a failure.");
                return _value;
            }
        }

        protected internal Result(T value) : base()
        {
            _value = value;
        }

        protected internal Result(string error) : base(error)
        {
            _value = default;
        }

        protected internal Result(List<string> errors) : base(errors)
        {
            _value = default;
        }

        public static Result<T> Success(T value)
        {
            return new Result<T>(value);
        }

        public new static Result<T> Failure(string error)
        {
            return new Result<T>(error);
        }

        public new static Result<T> Failure(List<string> errors)
        {
            return new Result<T>(errors);
        }
    }
} 