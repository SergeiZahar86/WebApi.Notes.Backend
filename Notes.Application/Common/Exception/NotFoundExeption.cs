using System;

namespace Notes.Application.Common.Exception
{
    public class NotFoundExeption : SystemException
    {
        public NotFoundExeption(string name, object key)
            : base($"Entity \"{name}\" ({key}) not found.") { }
    }
}
