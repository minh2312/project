using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProjectAPI.Response
{
    public class ResponseData
    {
        public Code Code { get; set; } = Code.Success;

        public string Message { get; set; } = "Thành công";

        public ResponseData(Code code, string message)
        {
            Code = code;
            Message = message;
        }

        public ResponseData(string message)
        {
            Message = message;
        }

        public ResponseData()
        {
        }
    }

    /// <summary>
    /// Trả về lỗi 
    /// </summary>

    public class ResponseError : ResponseData
    {
        public IList<Dictionary<string, string>> ErrorDetail { get; set; }

        public ResponseError(Code code, string message, IList<Dictionary<string, string>> errorDetail = null) : base(code, message)
        {
            ErrorDetail = errorDetail;
        }
    }

    public class ResponseEr : ResponseData
    {
        public Code Code { get; set; } = Code.Success;

        public string Message { get; set; } = "Thành công";

        public int Count { get; set; }

        public ResponseEr(Code code, string message, int count)
        {
            Code = code;
            Message = message;
            Count = count;
        }

    }
    /// <summary>
    /// Trả về đối tượng 
    /// </summary>
    public class ResponseObject<T> : ResponseData
    {
        /// <summary>
        ///     Dữ liệu trả về
        /// </summary>
        public T Data { get; set; }

        public ResponseObject(T data)
        {
            Data = data;
        }

        public ResponseObject(T data, string message)
        {
            Data = data;
            Message = message;
        }

        public ResponseObject(T data, string message, Code code)
        {
            Code = code;
            Data = data;
            Message = message;
        }
    }


    /// <summary>
    /// max loi
    /// </summary>KD
    public enum Code
    {
        Success = 200, // OK
        Created = 201, // xác nhận trạng thái đã hoạt động 
        BadRequest = 400, // lỗi dữ liệu do người dùng chuyền lên 
        Unauthorized = 401, // từ chối truy cập khi header ko chứa mã xác thực (Token) 
        Forbidden = 403, // từ chối người dùng truy cập vào API này 
        NotFound = 404, // không tìm thấy đường dẫn trên API 
        MethodNotAllowed = 405, // truy cập file không dược cho phép 
        Conflict = 409, // quá nhiều yêu cầu cho một file 
        ServerError = 500 // Server Error 
    }
}

