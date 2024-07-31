using System.ComponentModel.DataAnnotations;

namespace Health_Insurance_Application.DTO
{
    public class ErrorDTO
    {
        [Required]
        public int Code { get; set; }
        [Required]
        public string Message { get; set; } = string.Empty;

        public ErrorDTO(int code, string msg)
        {
            Code = code;
            Message = msg;
        }
    }
}
