﻿namespace ConsoleApp1.DataAccess.Entities;

public class Student
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    public string ClassName { get; set; }

    public string Address { get; set; }
}
