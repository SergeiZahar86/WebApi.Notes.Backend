using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Notes.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly)
        {
            ApplyMappingFromAssembly(assembly);
        }

        private void ApplyMappingFromAssembly(Assembly assembly)
        {
            // сканирует сборку и ищем любые типы реализующие интерфейс IMapWith
            List<Type> types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();

            // вызываес метод Mapping() от унаследуемого типа или из интерфейса 
            // если этот тип не реализует этот интерфейс
            foreach (var type in types)
            {
                // Создает экземпляр указанного типа, используя конструктор этого типа.
                var instance = Activator.CreateInstance(type);
                // Поиск общего метода с указанным именем.
                var methodInfo = type.GetMethod("Mapping");
                // Invoke - Вызывает метод или конструктор, представленный текущим экземпляром, используя
                // указанные параметры.
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
