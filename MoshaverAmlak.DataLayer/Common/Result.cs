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
            NotRecognizedUser,
            NotRecognizedRole,
            LoginOk,
            LoginFailed
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

        public static string GetMessage(string status)
        {
            switch (status)
            {
                case "OK":
                    return "عملیات با موفقیت انجام شد.";
                case "Failed":
                    return "عملیات با خطا رو به رو شد.";
                default:
                    return "وضعیت عملیات نامعلوم است.";
            }
        }

    }
}
