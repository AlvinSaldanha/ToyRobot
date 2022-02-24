
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Domain
{
	public class DomainOperationResult
	{
		public DomainOperationResult()
		{
		}

		public DomainOperationStatus Status { get; set; }
		public List<DomainError> DomainErrors { get; private set; } = new List<DomainError>();

		public static DomainOperationResult NotFound(string error = null)
		{
			var res = new DomainOperationResult
			{
				Status = DomainOperationStatus.NotFound
			};
			if (string.IsNullOrWhiteSpace(error))
				res.DomainErrors.Add(new DomainError { Message = error });
			return res;
		}

		public static DomainOperationResult<TValue> NotFound<TValue>(string error = null)
		{
			var res = new DomainOperationResult<TValue>
			{
				Status = DomainOperationStatus.NotFound
			};
			if (string.IsNullOrWhiteSpace(error))
				res.DomainErrors.Add(new DomainError { Message = error });
			return res;
		}

		public static DomainOperationResult Success()
		{
			return new DomainOperationResult { Status = DomainOperationStatus.Success };
		}

		public static DomainOperationResult<TValue> Success<TValue>(TValue value)
		{
			return new DomainOperationResult<TValue> { Status = DomainOperationStatus.Success, Value = value };
		}

		#region Errors [PUBLIC, STATIC] ---------------------------------------

		public static DomainOperationResult Error(string message)
		{
			return Error(new[] { message });
		}
		public static DomainOperationResult<TValue> Error<TValue>(string message, TValue value = default)
		{
			return Error<TValue>(new[] { message }, value);
		}

		public static DomainOperationResult Error(ICollection<ValidationResult> validationResults)
		{
			return Error(validationResults.Select(error => error.ErrorMessage));
		}

		public static DomainOperationResult<TValue> Error<TValue>(ICollection<ValidationResult> validationResults)
		{
			return Error<TValue>(validationResults.Select(error => error.ErrorMessage));
		}

		public static DomainOperationResult Error(IEnumerable<string> messages)
		{
			return new DomainOperationResult
			{
				Status = DomainOperationStatus.Error,
				DomainErrors = messages.Select(message => new DomainError { Message = message }).ToList()
			};
		}

		public static DomainOperationResult<TValue> Error<TValue>(IEnumerable<string> messages, TValue value = default)
		{
			return new DomainOperationResult<TValue>
			{
				Status = DomainOperationStatus.Error,
				DomainErrors = messages.Select(message => new DomainError { Message = message }).ToList(),
				Value = value
			};
		}

		public static DomainOperationResult<TValue> Error<TValue>(IEnumerable<DomainError> domainError, TValue value = default)
		{
			return new DomainOperationResult<TValue>
			{
				Status = DomainOperationStatus.Error,
				DomainErrors = new List<DomainError>(domainError),
				Value = value
			};
		}
		#endregion Errors [PUBLIC, STATIC] ------------------------------------

		public DomainOperationResult<TValue> WithValue<TValue>(TValue value = default(TValue))
		{
			return new DomainOperationResult<TValue>
			{
				Status = Status,
				DomainErrors = DomainErrors,
				Value = value
			};
		}
	}

	public static class DomainOperationResultExtension
	{
		public static DomainOperationResult<TValue2> ConvertTo<TValue1, TValue2>(this DomainOperationResult<TValue1> result)
			where TValue1 : class
			where TValue2 : class
		{
			var res = new DomainOperationResult<TValue2>
			{
				Status = result.Status,
				Value = result.Value as TValue2
			};
			if (result.DomainErrors != null)
				res.DomainErrors.AddRange(result.DomainErrors);
			return res;
		}

		public static DomainOperationResult<TValue> ConvertTo<TValue>(this DomainOperationResult result)
		{
			var res = new DomainOperationResult<TValue> { Status = result.Status };
			if (result.DomainErrors != null)
				res.DomainErrors.AddRange(result.DomainErrors);
			return res;
		}

		public static DomainOperationResult Merge(this DomainOperationResult innerResult, params string[] messages)
		{
			return Merge(innerResult, (messages ?? new string[0]).Select(m => new DomainError { Message = m }).ToArray());
		}

		public static DomainOperationResult Merge(this DomainOperationResult innerResult, params DomainError[] errors)
		{
			var res = new DomainOperationResult
			{
				Status = innerResult.Status,

			};
			res.DomainErrors.AddRange(innerResult.DomainErrors.Concat(errors ?? new DomainError[0]).ToList());
			return res;
		}
	}

	public class DomainOperationResult<TValue> : DomainOperationResult
	{
		public TValue Value { get; set; }
	}

	public enum DomainOperationStatus
	{
		Success,
		NotFound,
		Error
	}

	public class DomainError
	{
		public int? Code { get; set; }
		public string Message { get; set; }
	}
}