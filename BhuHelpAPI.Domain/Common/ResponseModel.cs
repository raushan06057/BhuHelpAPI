﻿namespace BhuHelpAPI.Domain.Common;

public class ResponseModel
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public object? Data { get; set; }
    public string? RoleName { get; set; }
    public long? OrganizationId { get; set; }
}
