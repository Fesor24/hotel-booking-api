﻿namespace HB.Domain.Shared;
public class Error : BaseError
{
    public readonly static Error None = new(string.Empty, string.Empty, string.Empty);

    public Error() : base()
    {
        
    }

    public Error(string code, string message) : base(code, message, message)
    {
        
    }

    public Error(string code, string message, string details) : base(code, message, details)
    {
        
    }
}


