using System;
using System.Collections.Generic;
using System.Text;

namespace MoshaverAmlak.DataLayer.Common
{
    public class Result
    {
        private static Result _result = null;

        public int StatusResult { get; set; }

        public enum Status
        {
            OK,
            Failed,
        }

        private Result(Status status)
        {
            StatusResult = (int)status;
        }

        public static Result GenerateResult(Status status)
        {
            if (_result == null) return new Result(status);
            return _result;
        }

        public string GetMessage(Status status)
        {
            switch (status)
            {
                case Status.OK:
                    return "عملیات با موفقیت انجام شد.";
                case Status.Failed:
                    return "عملیات با خطا رو به رو شد.";
                default:
                    return "وضعیت عملیات نامعلوم است.";
            }
        }

    }
}
