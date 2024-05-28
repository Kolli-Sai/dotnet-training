namespace Authentication.Core.Dtos;

public class ErrorResponseDto
{
    public bool Success { get; set; } = false;
    public string Message { get; set; }
}
