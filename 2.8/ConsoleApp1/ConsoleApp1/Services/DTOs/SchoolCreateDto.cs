namespace ConsoleApp1.Services.DTOs;

public class SchoolCreateDto : SchoolBaseDto
{
    public Guid Id { get; set; }

    public int ZipCode { get; set; }
}
