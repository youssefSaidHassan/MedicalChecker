using System.Net;

namespace MedicalChecker.Core.Bases
{
    public class ResponseHandler
    {
        public ResponseHandler()
        {

        }

        public Response<T> Success<T>(T entity, object Meta = null)
        {

            return new Response<T>()
            {
                Data = entity,
                Succeeded = true,
                StatusCode = HttpStatusCode.OK,
                Meta = Meta,
                Message = "Operation Completed Successfully"
            };
        }

        public Response<T> Created<T>(T entity, object Meta = null)
        {
            return new Response<T>
            {
                Data = entity,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Meta = Meta,
                Message = "Created Successfully"
            };
        }
        public Response<T> Deleted<T>()
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Deleted Successfully"
            };
        }

        public Response<T> Updated<T>()
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = "Updated Successfully"
            };
        }

        public Response<T> Unauthorized<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = true,
                Message = Message == null ? "Unauthorized User" : Message
            };
        }

        public Response<T> BadRequest<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message == null ? "Bad Request" : Message
            };
        }
        public Response<T> UnprocessableEntity<T>(string Message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = Message == null ? "Validation Error" : Message
            };
        }

        public Response<T> NotFound<T>(string message = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message == null ? "Not Found" : message
            };
        }


    }

}
