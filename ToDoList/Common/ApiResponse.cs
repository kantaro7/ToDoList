namespace Common;

public class ApiResponse<T>
{
    public Enums.ResponsesID Code { get; set; }
    public string Description { get; set; }
    public T Structure { get; set; }

    public ApiResponse()
    {
    }

    public ApiResponse(Enums.ResponsesID code, string description, T structure)
    {
        this.Code = code;
        this.Description = description;
        this.Structure = structure;
    }
}
