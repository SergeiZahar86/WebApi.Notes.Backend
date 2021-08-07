using System;

namespace Notes.Application.Common.Exception
{
    public class NotFoundException : SystemException
    {
        public NotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) not found.") { }
    }
}
